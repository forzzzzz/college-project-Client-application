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
using System.Windows.Media.Animation;

namespace EasyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            DoubleAnimation bthAnimation = new DoubleAnimation();
            bthAnimation.From = 0;
            bthAnimation.To = 450;
            bthAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty, bthAnimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim();
            int a = 1;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Це поле введено невiрно!";
                textBoxLogin.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }

            if (pass.Length < 5)
            {
                passBox.ToolTip = "Це поле введено невiрно!";
                passBox.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
            }

            if(pass != pass_2)
            {
                passBox2.ToolTip = "Паролi не cпiвпадають";
                passBox2.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Це поле введено невiрно!";
                textBoxEmail.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
            }

            if (a == 1)
            {
                MessageBox.Show("Все добре!");

                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, EventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
