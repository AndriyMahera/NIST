using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace NIST_OOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string mainString,mainStringLong;
        private const double standardP = 0.01;
        private string binaryStr,binaryStrLong,theLongest,realTheLongest;
        private List<int> digitStr = new List<int>(),digitStrLong=new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void FillCheckBox()
        {
            List<CheckBox> checkboxes = controls.Children.OfType<CheckBox>().ToList();
            List<TextBox> textboxes = controls.Children.OfType<TextBox>().ToList();
            double toCon;
            for (int i = 0; i < checkboxes.Count; i++)
            {
                try
                {
                    toCon = Convert.ToDouble(textboxes[i + 1].Text);
                    if (toCon > standardP)
                    {
                        checkboxes[i].IsChecked = true;
                    }
                }
                catch (Exception) { }
            }
        }

        private void Perform_Click(object sender, RoutedEventArgs e)
        {
            this.mainString = TextBox0.Text.Length == 0 ? File.ReadAllText("NIST.txt") : TextBox0.Text;
            this.mainString = StringOperation.FilterText(this.mainString);
            TextBox0.Text = this.mainString;

            this.mainStringLong = File.ReadAllText("ForNIST.txt");

            this.digitStr = StringOperation.FormDigitString(this.mainString);
            this.binaryStr = StringOperation.FormBinaryString(this.digitStr);
            this.digitStrLong = StringOperation.FormDigitString(this.mainStringLong);
            this.binaryStrLong = StringOperation.FormBinaryString(this.digitStrLong);

            for (int i = 0; i < 6; i++)
                this.theLongest += this.binaryStrLong;

            for (int i = 0; i < 20; i++)
                this.realTheLongest += this.binaryStrLong;

            Tests.Test1 test1 = new Tests.Test1(this.binaryStr);
            test1.PerformTest(); TextBox1.Text = test1.PVALUE.ToString("F6");

            Tests.Test2 test2 = new Tests.Test2(this.binaryStr);
            test2.PerformTest(); TextBox2.Text = test2.PVALUE.ToString("F6");

            Tests.Test3 test3 = new Tests.Test3(this.binaryStr);
            test3.PerformTest(); TextBox3.Text = test3.PVALUE.ToString("F6");

            Tests.Test4 test4 = new Tests.Test4(this.binaryStr);
            test4.PerformTest(); TextBox4.Text = test4.PVALUE.ToString("F6");

            Tests.Test5 test5 = new Tests.Test5(this.binaryStrLong);
            test5.PerformTest(); TextBox5.Text = test5.PVALUE.ToString("F6");

            Tests.Test6 test6 = new Tests.Test6(this.binaryStr);
            test6.PerformTest(); TextBox6.Text = test6.PVALUE.ToString("F6");

            Tests.Test7 test7 = new Tests.Test7(this.binaryStr);
            test7.PerformTest(); TextBox7.Text = test7.PVALUE.ToString("F6");

            Tests.Test8 test8 = new Tests.Test8(this.binaryStr);
            test8.PerformTest(); TextBox8.Text = test8.PVALUE.ToString("F6");

            Tests.Test9 test9 = new Tests.Test9(this.theLongest);
            test9.PerformTest(); TextBox9.Text = test9.PVALUE.ToString("F6");

            Tests.Test10 test10 = new Tests.Test10(this.binaryStr);
            test10.PerformTest(); TextBox10.Text = test10.PVALUE.ToString("F6");

            Tests.Test11 test11 = new Tests.Test11(this.binaryStr);
            test11.PerformTest(); TextBox11.Text = test11.PVALUE.ToString("F6");

            Tests.Test12 test12 = new Tests.Test12(this.binaryStr);
            test12.PerformTest(); TextBox12.Text = test12.PVALUE.ToString("F6");

            Tests.Test13 test13 = new Tests.Test13(this.realTheLongest);
            test13.PerformTest(); TextBox13.Text = test13.PVALUE.ToString("F6");

            Tests.Test14 test14 = new Tests.Test14(this.realTheLongest);
            test14.PerformTest(); TextBox14.Text = test14.PVALUE.ToString("F6");

            Tests.Test15 test15 = new Tests.Test15(this.realTheLongest);
            test15.PerformTest(); TextBox15.Text = test15.PVALUE.ToString("F6");

            this.FillCheckBox();
        }
        
    }
}
