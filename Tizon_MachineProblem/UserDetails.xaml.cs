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
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        public UserDetails(string fullName, string username, string email, string studentNo, string password)
        {
            InitializeComponent();

            // Set DataContext to this instance
            DataContext = this;

            // Set user details properties
            FullName = fullName;
            Username = username;
            Email = email;
            StudentNo = studentNo;
            Password = password;

            // Call DisplayUserDetails to display user details
            DisplayUserDetails();
        }

        // Properties to hold user details
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string StudentNo { get; set; }
        public string Password { get; set; }

        // Method to display user details
        private void DisplayUserDetails()
        {
            // Set the content of labels to display user details
            tblFullName.Text = "Full Name: " + FullName;
            tblUsername.Text = "Username: " + Username;
            tblEmail.Text = "Email: " + Email;
            tblStudentNo.Text = "Student No: " + StudentNo;
            tblPassword.Text = "Password: " + Password;
        }
    }


}
