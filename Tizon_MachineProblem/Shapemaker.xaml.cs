using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tizon_MachineProblem
{
    public partial class Shapemaker : Window
    {
        private string username;

        public Shapemaker(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcomeWindow = new Welcome(username); // Replace "Username goes here" with the actual username
            welcomeWindow.Show();
            this.Close();
        }

        private void shapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (canvas != null)
            {
                // Clear existing shapes
                canvas.Children.Clear();

                // Get the selected shape
                ComboBoxItem selectedItem = (ComboBoxItem)shapeComboBox.SelectedItem;
                string shape = selectedItem.Content.ToString();

                // Draw the selected shape
                switch (shape)
                {
                    case "Rectangle":
                        DrawRectangle();
                        break;
                    case "Circle":
                        DrawCircle();
                        break;
                    case "Triangle":
                        DrawTriangle();
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }


        private void DrawRectangle()
        {
            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 50,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            Canvas.SetLeft(rectangle, 50);
            Canvas.SetTop(rectangle, 50);

            canvas.Children.Add(rectangle);
        }


        private void DrawCircle()
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            Canvas.SetLeft(ellipse, 50);
            Canvas.SetTop(ellipse, 50);

            canvas.Children.Add(ellipse);
        }

        private void DrawTriangle()
        {
            Polygon triangle = new Polygon
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            PointCollection points = new PointCollection
            {
                new Point(50, 50),
                new Point(150, 50),
                new Point(100, 150)
            };

            triangle.Points = points;

            canvas.Children.Add(triangle);
        }
    }
}
