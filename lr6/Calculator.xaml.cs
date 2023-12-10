using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace lr6
{
    public sealed partial class Calculator : Page
    {
        private double a, b, c;
        private string operation;
        public Calculator()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            text_history.Text = String.Empty;
        }
        private void textbox_main_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox_main.Text == "") textbox_main.Text = "0";
            if ((Convert.ToDouble(textbox_main.Text) > 4000000) || (Convert.ToDouble(textbox_main.Text) < -2000000))
            {
                textbox_main.Text = textbox_main.Text.Substring(0, textbox_main.Text.Length - 1);
            }
            if (textbox_main.Text.Contains(','))
            {
                if ((textbox_main.Text.Length - textbox_main.Text.IndexOf(',')) > 4)
                {
                    textbox_main.Text = textbox_main.Text.Substring(0, textbox_main.Text.IndexOf(',') + 5);
                }
            }
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textbox_main.Text = "0";
            text_history.Text = String.Empty;
        }

        private void button_sign_Click(object sender, RoutedEventArgs e)
        {
            textbox_main.Text = Convert.ToString(Convert.ToDouble(textbox_main.Text) * -1);
        }
        private void button_digit_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_main.Text == "0")
            {
                textbox_main.Text = (string)(sender as Button).Content;
                return;
            }
            textbox_main.Text += (sender as Button).Content;
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(textbox_main.Text) != 0) textbox_main.Text += (sender as Button).Content;
            if (textbox_main.Text.Contains(',')) textbox_main.Text += (sender as Button).Content;
        }

        private void button_minus_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = a.ToString();
            textbox_main.Text = String.Empty;
            operation = "-";
        }

        private void button_sin_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"sin{a}";
            c = sin(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = a.ToString();
            textbox_main.Text = String.Empty;
            operation = "/";
        }

        private void button_cos_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"cos{a}";
            c = cos(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_root_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"√{a}";
            c = root(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_1_div_x_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(textbox_main.Text) == 0)
            {
                var msg = new MessageDialog("Деление на ноль!");
                msg.ShowAsync();
                return;
            }
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"1/{a}";
            c = one_div_x(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_square_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"sqr{a}";
            c = square(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_fact_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_main.Text.Contains(','))
            {
                var msg = new MessageDialog("Введите целое число!");
                msg.ShowAsync();
                return;
            }
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = $"!{a}";
            c = fact(a);
            textbox_main.Text = c.ToString("G5");
        }

        private void button_equal_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    b = Convert.ToDouble(textbox_main.Text);
                    text_history.Text += operation + b.ToString();
                    c = plus(a, b);
                    textbox_main.Text = c.ToString("G5");
                    break;
                case "-":
                    b = Convert.ToDouble(textbox_main.Text);
                    text_history.Text += operation + b.ToString();
                    c = minus(a, b);
                    textbox_main.Text = c.ToString("G5");
                    break;
                case "/":
                    b = Convert.ToDouble(textbox_main.Text);
                    text_history.Text += operation + b.ToString();
                    if (b == 0)
                    {
                        var msg = new MessageDialog("Деление на ноль!");
                        msg.ShowAsync();
                        return;
                    }
                    c = div(a, b);
                    textbox_main.Text = c.ToString("G5");
                    break;
                case "*":
                    b = Convert.ToDouble(textbox_main.Text);
                    text_history.Text += operation + b.ToString();
                    c = mul(a, b);
                    textbox_main.Text = c.ToString("G5");
                    break;
            }
            operation = "";
            a = 0;
            b = 0;
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            textbox_main.Text = textbox_main.Text.Substring(0, textbox_main.Text.Length - 1);
        }

        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = a.ToString();
            textbox_main.Text = String.Empty;
            operation = "+";
        }
        private double plus(double a, double b)
        {
            return a + b;
        }
        private double minus(double a, double b)
        {
            return a - b;
        }
        private double div(double a, double b)
        {
            return a / b;
        }
        private double mul(double a, double b)
        {
            return a * b;
        }
        private double root(double a)
        {
            return Math.Sqrt(a);
        }
        private double square(double a)
        {
            return a * a;
        }
        private double sin(double a)
        {
            return Math.Sin((a * Math.PI) / 180); ;
        }
        private double cos(double a)
        {
            return Math.Cos((a * Math.PI) / 180);
        }

        private void button_mul_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(textbox_main.Text);
            text_history.Text = a.ToString();
            textbox_main.Text = String.Empty;
            operation = "*";
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private double one_div_x(double a)
        {
            return 1 / a;
        }
        private double fact(double a)
        {
            if (a == 0) return 1;
            else
            {
                if (a < 0) return a * fact(a + 1);
                else return a * fact(a - 1);
            }
        }
    }
}
