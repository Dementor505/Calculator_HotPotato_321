using System;
using System.Collections.Generic;
using System.Data;
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
using Calculator.Components;

using WpfAnimatedGif;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageBehavior.SetAnimatedSource(StyleGif, new BitmapImage(new Uri("/Resources/BackGroundCalculator.gif", UriKind.Relative)));
            resultField.Text = "";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Content as Grid;
            TextBlock buttonTextBlock = grid.Children.OfType<TextBlock>().FirstOrDefault();
            resultField.Text += buttonTextBlock.Text;

            resultField.ScrollToHorizontalOffset(resultField.ExtentWidth);
            resultField.CaretIndex = resultField.Text.Length;
        }

        private void NumberBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Content as Grid;
            Image buttonImage = grid.Children.OfType<Image>().FirstOrDefault();
            ImageBehavior.SetAnimatedSource(buttonImage, new BitmapImage(new Uri("/Resources/NumberTileAnimation.gif", UriKind.Relative)));
        }
        private void NumberBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Content as Grid;
            Image buttonImage = grid.Children.OfType<Image>().FirstOrDefault();
            ImageBehavior.SetAnimatedSource(buttonImage, null);
            buttonImage.Source = new BitmapImage(new Uri("/Resources/NumberTile.png", UriKind.Relative));
        }
        
        private void Equalse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate clc = new Calculate();
                resultField.Text = clc.ConvertToMath(resultField.Text).ToString();
            }
            catch
            {
                MessageBox.Show("ОШИБОЧКА. РЕЗУЛЬТАТ СЛИШКОМ БОЛЬШОЙ ИЛИ ПРОСТО НЕКОРРЕКТНЫЙ ! ! ! =)");
            }
        }

        private void HelperBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageBehavior.SetAnimatedSource(HelperImage, new BitmapImage(new Uri("/Resources/HelpTileAnimation.gif", UriKind.Relative)));
        }

        private void HelperBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageBehavior.SetAnimatedSource(HelperImage, null);
            HelperImage.Source = new BitmapImage(new Uri("/Resources/HelpBtn.png", UriKind.Relative));
        }

        private void HelperBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данный калькулятор пазиционируетсяя как ЦЕЛОЧИСЛЕННЫЙ (по правилам округляет дробные значения до целых). Программа разработана Хабибуллиным Дмитрием и Сирачовой Азалией. 321П группа ГАПОУ МЦК-КТИТС. Весь дизайн и анимации были нарисованы вручную. Все совпадения с реальными калькуляторами являются случайными. =)");
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            resultField.Text = "";
        }

        private void OperationsBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Content as Grid;
            TextBlock buttonTextBlock = grid.Children.OfType<TextBlock>().FirstOrDefault();
            resultField.Text += buttonTextBlock.Text;

            resultField.ScrollToHorizontalOffset(resultField.ExtentWidth);
            resultField.CaretIndex = resultField.Text.Length;
        }
    } 
}
