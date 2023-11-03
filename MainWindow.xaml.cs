using MaterialDesignColors.ColorManipulation;
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

namespace keyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pos = 0;
        List<char> chars = new() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
        List<char> chars2 = new() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
        List<char> chars3 = new() { 'z', 'x', 'c', 'v', 'b', 'n', 'm'};
        int fails = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreateButtons(chars,SPBase);
            CreateButtons(chars2, SPBase2);
            CreateButtons(chars3, SPBase3);


        }
        private void CreateButtons(List<char> chars,StackPanel stackPanel)
        {
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            for (int i = 0; i < chars.Count; i++)
            {   var b = new Button() { Content = chars[i], Width = 50, Height = 50};
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
           
            char sign;
            string key = e.Key.ToString();
            if (key == "Space")
            {
                sign = ' ';
            }
            else
            {
                sign = char.ToLower(key[0]);
            }
           
            if (sign == tbText.Text.First())
            {
                foreach (var item in SPBase.Children)
                {
                    if (item is StackPanel)
                    {
                        foreach (var item2 in (item as StackPanel).Children)
                        {
                            if (item2 is Button)
                            {
                                if ((item2 as Button).Content.ToString() == char.ToLower(key[0]).ToString())
                                {
                                    (item2 as Button).Background = new SolidColorBrush(Colors.LemonChiffon);
                                    break;
                                }
                            }
                        }
                    }
                }

                StringBuilder stringBuilder = new StringBuilder(tbText.Text);
                stringBuilder.Remove(0, 1);
                tbText.Text = stringBuilder.ToString();
                tbText.UpdateLayout();
            }
            else
            {
                fails++;
                TBFails.Text = fails.ToString();
            }
            
        }


     

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var item in SPBase.Children)
            {
                if (item is StackPanel)
                {
                    foreach (var item2 in (item as StackPanel).Children)
                    {
                        if (item2 is Button)
                        {
                            if ((item2 as Button).Content.ToString() == char.ToLower(e.Key.ToString()[0]).ToString())
                            {
                                (item2 as Button).Background = new SolidColorBrush(Colors.White);
                                (item2 as Button).UpdateLayout();
                            }
                        }
                    }
                }
            }

        }
    }
}
