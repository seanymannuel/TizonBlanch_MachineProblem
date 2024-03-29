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

namespace Tizon_MachineProblem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string StudentNo { get; set; }
        public string Password { get; set; }
        public static Dictionary<string, string> UserCredentials { get; } = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OpenUserDetails(string fullName, string username, string email, string studentNo, string password)
        {
            UserDetails userDetailsWindow = new UserDetails(fullName, username, email, studentNo, password);
            userDetailsWindow.Show();
        }
        public static void AddUserCredentials(string username, string password)
        {
            UserCredentials[username] = password;
        }
        public static bool AreValidCredentials(string username, string password)
        {
            return UserCredentials.ContainsKey(username) && UserCredentials[username] == password;
        }
        private void RegForm_Closed(object sender, EventArgs e)
        {
            this.Show();
        }


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            regsform regs = new regsform(UserCredentials);
            regs.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            error.Visibility = Visibility.Hidden;
        }

        private void USERNAME1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string user = username1.Text;
            string pass = password1.Password;
            if (username1.Text == "blanch" && password1.Password == "123")
            {
                MessageBox.Show("Login successful!");
                Welcome welcome = new Welcome("blanch"); // Pass the username
                welcome.Show();
                this.Close();
            }
            else if (UserCredentials.ContainsKey(user) && UserCredentials[user] == pass)
            {
                Welcome welcome = new Welcome(user); // Pass the username
                welcome.Show();
                this.Close();
            }
            else
            {
                error.Content = "Invalid username or password.";
                error.Visibility = Visibility.Visible;
            }
        }

    }
}
