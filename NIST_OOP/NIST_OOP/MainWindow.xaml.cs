﻿using System;
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
        private string binaryStr,binaryStrLong;
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

            this.FillCheckBox();
        }
        
    }
}
