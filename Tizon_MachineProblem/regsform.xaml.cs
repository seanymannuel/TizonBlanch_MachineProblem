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
using System.Windows.Shapes;

namespace Tizon_MachineProblem
{

    public partial class regsform : Window
    {
        private Dictionary<string, string> userCredentials;

        public regsform(Dictionary<string, string> userCredentials)
        {
            InitializeComponent();
            this.userCredentials = userCredentials;
        }
        public event EventHandler<RegisterEventArgs> RegisterSuccess;

        private void OnRegisterSuccess(Dictionary<string, string> updatedUserCredentials)
        {
            RegisterSuccess?.Invoke(this, new RegisterEventArgs(updatedUserCredentials));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string user = username.Text;
            string pass = pass1.Text;
            if (fullname.Text == "" || username.Text == "" || student.Text == "" || email.Text == "" || pass1.Text == "")
            {
                errorname.Content = Visibility.Visible;
                erroruser.Content = Visibility.Visible;
                studenterror.Content = Visibility.Visible;
                emailerror.Content = Visibility.Visible;
                passworderror.Content = Visibility.Visible;
                errorname.Content = "This is Required";
                erroruser.Content = "This is Required";
                studenterror.Content = "This is Required";
                emailerror.Content = "This is Required";
                passworderror.Content = "This is Required";
            }

            else if (!email.Text.EndsWith("@sgen.edu.ph"))
            {

                emailerror.Content = "Email must end with @sgen.edu.ph";

            }
            else if (pass1.Text.Length < 8)
            {

                MessageBox.Show("Password must be at least 8 characters long");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(student.Text, @"^\d{2}-\d{3}[sS]$"))
            {

                MessageBox.Show("S number must be in the format 00-000s");
            }

            else
            {
                userCredentials.Add(user, pass);
                OnRegisterSuccess(userCredentials);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }


        }
        public class RegisterEventArgs : EventArgs
        {
            public Dictionary<string, string> UserCredentials { get; }

            public RegisterEventArgs(Dictionary<string, string> userCredentials)
            {
                UserCredentials = userCredentials;
            }
        }
    }
}
