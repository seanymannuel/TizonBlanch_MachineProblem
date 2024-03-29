using System;
using System.Windows;
using System.Windows.Controls;

namespace Tizon_MachineProblem
{
    public partial class Calculator : Window
    {
        private string username;
        private string currentInput = ""; // Variable to hold current input
        private double currentResult = 0; // Variable to hold current result
        private char currentOperator = ' '; // Variable to hold current operator

        public Calculator(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            InputTextBox.Text = currentInput;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            char newOperator = button.Content.ToString()[0];

            if (!string.IsNullOrEmpty(currentInput))
            {
                if (currentOperator != ' ')
                {
                    Calculate(); // If there's already an operator, calculate previous operation
                }

                currentOperator = newOperator;
                currentResult = double.Parse(currentInput);
                currentInput = "";
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && currentOperator != ' ')
            {
                Calculate(); // Calculate the final result
                currentInput = currentResult.ToString();
                currentOperator = ' ';
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            currentResult = 0;
            currentOperator = ' ';
            InputTextBox.Text = "";
        }

        private void Calculate()
        {
            double inputValue = double.Parse(currentInput);

            switch (currentOperator)
            {
                case '+':
                    currentResult += inputValue;
                    break;
                case '-':
                    currentResult -= inputValue;
                    break;
                case '*':
                    currentResult *= inputValue;
                    break;
                case '/':
                    if (inputValue != 0)
                    {
                        currentResult /= inputValue;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero!");
                    }
                    break;
            }

            InputTextBox.Text = currentResult.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome(username);
            welcome.Show();
            this.Close();
        }
    }
}