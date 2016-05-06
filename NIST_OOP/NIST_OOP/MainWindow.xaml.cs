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
        private string mainString;
        private const double standardP = 0.01;
        private string binaryStr;
        private List<int> digitStr = new List<int>();

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
            mainString = TextBox0.Text.Length == 0 ? File.ReadAllText("NIST.txt") : TextBox0.Text;
            mainString = StringOperation.FilterText(mainString);
            TextBox0.Text = mainString;

            digitStr = StringOperation.FormDigitString(mainString);
            binaryStr = StringOperation.FormBinaryString(digitStr);

            Tests.Test1 test1 = new Tests.Test1(binaryStr);
            test1.PerformTest(); TextBox1.Text = test1.PVALUE.ToString("F6");

            Tests.Test2 test2 = new Tests.Test2(binaryStr);
            test2.PerformTest(); TextBox2.Text = test2.PVALUE.ToString("F6");

            Tests.Test3 test3 = new Tests.Test3(binaryStr);
            test3.PerformTest(); TextBox3.Text = test3.PVALUE.ToString("F6");

            this.FillCheckBox();
        }
        
    }
}
