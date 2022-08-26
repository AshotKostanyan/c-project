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
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Data.Entity;
using System.Windows.Media.Animation;

namespace SignIn


{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(3);
            */
        }

        public class person
        {
            public string Email { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public int Id { get; set; }
        }
        public class PersonContext : DbContext
        {
            public PersonContext()
                : base("DBConnection") { }
            public DbSet<person> Persons { get; set; }
        }

        private async void Button_Reg_Click(object sender, RoutedEventArgs e)
        {

            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass2 = PassBox_2.Password.Trim();
            string Email = textBoxEmail.Text.Trim();

            if (login.Length >= 5 && pass.Length >= 5 && pass == pass2 && (Email.Contains("@bk.ru") || Email.Contains("@gmail.com") || Email.Contains("@mail.ru")))
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox_2.ToolTip = "";
                PassBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                Window1 window = new Window1();
                await Task.Run(() =>
                {
                    using (var p = new AppContext()) //Создание подключения
                    {
                        //Объявление объектов
                        var user = new Users() { Login = login, Password = pass, Email = Email };
                        p.Users.Add(user);
                        p.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                    }

                    
                    window.Show();
                    Hide();
                });            

            }
            else
            {
                if (login.Length < 5)
                {
                    textBoxLogin.ToolTip = "The login symbols can't be lower 5";
                    textBoxLogin.Background = Brushes.LightCoral;
                }
                else
                {
                    textBoxLogin.ToolTip = "";
                    textBoxLogin.Background = Brushes.Transparent;
                }
                if (pass.Length < 5)
                {
                    PassBox.ToolTip = "The password symbols can't be lower 5";
                    PassBox.Background = Brushes.LightCoral;
                }
                else
                {
                    PassBox.ToolTip = "";
                    PassBox.Background = Brushes.Transparent;
                }
                if (pass != pass2)
                {
                    PassBox_2.ToolTip = "Repeat password";
                    PassBox_2.Background = Brushes.LightCoral;
                }
                else
                {
                    PassBox_2.ToolTip = "";
                    PassBox_2.Background = Brushes.Transparent;
                }
                if (Email.Contains("@bk.ru") || Email.Contains("@gmail.com") || Email.Contains("@mail.ru"))
                {
                    textBoxEmail.ToolTip = "";
                    textBoxEmail.Background = Brushes.Transparent;
                }
                else
                {
                    textBoxEmail.ToolTip = "Write real Email";
                    textBoxEmail.Background = Brushes.LightCoral;                   
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            signIn signIn = new signIn();
            signIn.Show();
            Hide();
        }

       
    }
}
