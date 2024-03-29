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
    /// Interaction logic for ProgrammerDetails.xaml
    /// </summary>
    public partial class ProgrammerDetails : Window
    {
        private string username;
        public ProgrammerDetails(string username)
        {
            InitializeComponent();
            this.username = username;
            // Set initial details
            NameLabel.Text = "Blanch Tizon";
            EmailLabel.Text = "Email: 23-013s@sgen.edu.ph";
            SubjectLabel.Text = "Subject: Programming 2";
            TeacherLabel.Text = "Teacher: Jairuz Saure";
            LearningLabel.Text = "I have learned that programming is so sensitive. For me, this field is really hard, but I try my best to make it fun and to learn more. My message to sir Jai is thank you for being patient.";

        }

        private void MessageToTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dear Sir Jai,\n\nThank you for your patience and guidance throughout the Programming 2 course. Your dedication has made the learning process enjoyable and rewarding. I appreciate all the effort you've put into helping us understand the complexities of programming.\n\nSincerely,\nBlanch Tizon");
        }

        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcomeWindow = new Welcome(username);
            welcomeWindow.Show();
            this.Close();
        }
    }
}
