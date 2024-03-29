using System.Collections.Generic;
using System.Windows;

namespace Tizon_MachineProblem
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        private string username; // Define the username variable at the class level

        public Welcome(string username)
        {
            InitializeComponent();
            this.username = username; // Assign the passed username to the class variable
            welcomeLabel.Content = "Welcome, " + username + "!";
        }

        private void shapeMaker_Click(object sender, RoutedEventArgs e)
        {
            Shapemaker shape = new Shapemaker(username); // Pass the username to the Shapemaker window
            shape.Show();
            this.Close();
        }

        private void basicCalcu_Click(object sender, RoutedEventArgs e)
        {
            Calculator calcu = new Calculator(username); // Pass the username to the Shapemaker window
            calcu.Show();
            this.Close();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve user details from the regsform
            string fullName = ""; // Retrieve the value from the corresponding text field
            string username = ""; // Retrieve the value from the corresponding text field
            string email = ""; // Retrieve the value from the corresponding text field
            string studentNo = ""; // Retrieve the value from the corresponding text field
            string password = ""; // Retrieve the value from the corresponding text field

            // Open the UserDetails window passing all the user details
            UserDetails userDetailsWindow = new UserDetails(fullName, username, email, studentNo, password);
            userDetailsWindow.Show();
            this.Close();
        }

        private void CTransfer_Click(object sender, RoutedEventArgs e)
        {
            CellTransfer cell = new CellTransfer(username); // Pass the username to the Cell Transfer window
            cell.Show();
            this.Close();
        }


        private void Programmer_Click(object sender, RoutedEventArgs e)
        {
            ProgrammerDetails prog = new ProgrammerDetails(username); // Pass the username to the Cell Transfer window
            prog.Show();
            this.Close();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }
    }
}
