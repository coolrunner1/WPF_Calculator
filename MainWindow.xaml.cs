using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double current = 0;
        public double next = 0;
        public double temp = 0;
        public bool plusPressed = false;
        public bool minusPressed = false;
        public bool multiplyPressed = false;
        public bool dividePressed = false;
        public bool powerPressed = false;
        public bool equalPressed = false;
        public bool currentUsed = true;
        public string container = "";
        public MainWindow()
        {
            InitializeComponent();
            MainText.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addDigit('1');
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addDigit('2');
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addDigit('3');
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addDigit('4');
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            addDigit('5');
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            addDigit('6');
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            addDigit('7');
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            addDigit('8');
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            addDigit('9');
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (container != "")
            {
                checkZero();
                container += "0";
                MainText.Text = container;
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(container, @"^\d*\.\d*$"))
            {
                if (container == "")
                {
                    container += "0";
                }
                container += ".";
                MainText.Text = container;
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            setFalse();
            equalPressed = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            container = "0";
            MainText.Text = container;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            currentUsed = false;
            current = 0;
            next = 0;
            setFalse();
            container = "0";
            MainText.Text = container;
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (container != "")
            {
                container = container.Remove(container.Length - 1);
                if (container == "")
                {
                    container += 0;
                }
                MainText.Text = container;
            }
        }

        private void checkZero()
        {
            if (container!="" && container[0] == '0' && container.Length==1)
            {
                container = container.Remove(container.Length - 1);
            }
        }
        
        private void addDigit(char digit)
        {
            checkZero();
            container += digit;
            MainText.Text = container;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (container != "")
            {
                temp = float.Parse(container) * (-1);
                container = temp.ToString();
                MainText.Text = container;
            }  
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            setFalse();
            plusPressed = true;
            MainText.Text = "+";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            setFalse();
            minusPressed = true;
            MainText.Text = "-";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            setFalse();
            multiplyPressed = true;
            MainText.Text = "*";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            setFalse();
            dividePressed = true;
            MainText.Text = "/";
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            if (!checkExpression())
            {
                return;
            }
            else if (currentUsed)
            {
                setFalse();
                powerPressed = true;
                MainText.Text = "^";
                return;
            }
            setFalse();
            powerPressed = true;
            MainText.Text = "^";
        }

        private void setFalse()
        {
            equalPressed = powerPressed = multiplyPressed = minusPressed = plusPressed = dividePressed = false;
        }

        private bool checkExpression()
        {
            if (container == "")
            {
                return false;
            }
            next = double.Parse(container);
            if (plusPressed)
            {
                current += next;
            }
            else if (minusPressed)
            {
                current -= next;
            }
            else if (multiplyPressed)
            {
                current *= next;
            }
            else if (dividePressed)
            {
                current /= next;
            }
            else if (powerPressed)
            {
                current = Math.Pow(current, next);
            }
            else if (equalPressed)
            {
                currentUsed = true;
            }
            else
            {
                current = double.Parse(container);
                container = "0";
                return true;
            }
            next = 0;
            
            container = "0";
            currentUsed = true;
            MainText.Text=current.ToString();
            return true;
        }
    }
}