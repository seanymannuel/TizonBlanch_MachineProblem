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
using System.Windows.Shapes;

namespace Tizon_MachineProblem
{

    public partial class CellTransfer : Window
    {
        private string username;
        private string[] leftNames; // Array to store names in left text box
        private string[] rightNames; // Array to store names in right text box
        public CellTransfer(string username)
        {
            InitializeComponent();
            this.username = username;

            leftNames = new string[] { "John", "Alice", "Bob", "Emma", "Michael" };
            rightNames = new string[0]; // Initialize rightNames as an empty array

            // Set the initial text of the left text box
            leftTextBox.Text = string.Join(Environment.NewLine, leftNames);
        }

        private void MoveTextRight_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected text from the left text box
            string selectedText = leftTextBox.SelectedText.Trim();

            // Check if any text is selected
            if (!string.IsNullOrEmpty(selectedText))
            {
                // Append selected text with a new line if right text box is not empty
                if (!string.IsNullOrEmpty(rightTextBox.Text))
                {
                    rightTextBox.Text += Environment.NewLine + selectedText;
                }
                else
                {
                    rightTextBox.Text = selectedText;
                }

                // Remove the selected text from the left text box
                leftTextBox.Text = leftTextBox.Text.Remove(leftTextBox.SelectionStart, leftTextBox.SelectionLength).Trim();

                // Update the arrays
                leftNames = leftTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                rightNames = rightTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Update the left text box text
                leftTextBox.Text = string.Join(Environment.NewLine, leftNames);
            }
        }


        private void MoveTextLeft_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected text from the right text box
            string selectedText = rightTextBox.SelectedText.Trim();

            // Check if any text is selected
            if (!string.IsNullOrEmpty(selectedText))
            {
                // Move the selected text from right to left
                leftTextBox.Text += Environment.NewLine + selectedText;

                // Remove the selected text from the right text box
                rightTextBox.Text = rightTextBox.Text.Remove(rightTextBox.SelectionStart, rightTextBox.SelectionLength).Trim();

                // Update the arrays
                leftNames = leftTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                rightNames = rightTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Update the right text box text
                rightTextBox.Text = string.Join(Environment.NewLine, rightNames);
            }
        }



        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcomeWindow = new Welcome(username); // Replace "Username goes here" with the actual username
            welcomeWindow.Show();
            this.Close();
        }
    }
}
