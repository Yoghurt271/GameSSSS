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
using System.Windows.Threading;

namespace GameSSSS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool goLeft, goRight, goUp, goDown;
        int speed = 3;
        Rectangle wall = new Rectangle();
        const int Size = 50;
        static int ochki;
        static int point;
        Ellipse bonus;

        DispatcherTimer gameTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Canvas1.Focus();
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(5);
            gameTimer.Start();
            DrawGameArea();

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(player) > 5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }

            if (goRight == true && Canvas.GetLeft(player) + (player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }

            if (goUp == true && Canvas.GetTop(player) > 5)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - speed);
            }

            if (goDown == true && Canvas.GetTop(player) + (player.Height + 40) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            }
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = true;
            }

            if (e.Key == Key.D)
            {
                goRight = true;
            }

            if (e.Key == Key.W)
            {
                goUp = true;
            }

            if (e.Key == Key.S)
            {
                goDown = true;
            }
        }
        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = false;
            }

            if (e.Key == Key.D)
            {
                goRight = false;
            }

            if (e.Key == Key.W)
            {
                goUp = false;
            }

            if (e.Key == Key.S)
            {
                goDown = false;
            }
        }
        private void DrawGameArea() //рисует игровое поле
        {
            Ellipse V = new Ellipse();
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            Random random = new Random();
            if (player == null)
                player = V;
            else
            {
                Canvas1.Children.Add(V);
                Canvas.SetTop(V, 10);
                Canvas.SetLeft(V, 10);
            }
            while (doneDrawingBackground == false)
            {
                int rand0 = random.Next(1, 10);
                int rand1 = random.Next(1, 11);
                Rectangle rect = new Rectangle
                {
                    Width = Size,
                    Height = Size,
                    Stroke = Brushes.Gray
                };
                bonus = new Ellipse
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Green
                };
                wall = new Rectangle
                {
                    Width = Size,
                    Height = Size,
                    Fill = Brushes.Red
                };
                Canvas1.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);
                nextX += Size;
                if (nextX >= 750)
                {
                    nextX = 0;
                    nextY += Size;
                    rowCounter++;
                }
                if (nextY >= 550)
                    doneDrawingBackground = true;
                if (rand0 > 7)
                {
                    Canvas1.Children.Add(wall);
                    Canvas.SetTop(wall, nextY);
                    Canvas.SetLeft(wall, nextX);
                }
                if (rand1 > 8)
                {
                    if (Canvas.GetTop(wall) != nextY && Canvas.GetLeft(wall) != nextX)
                    {
                        Canvas1.Children.Add(bonus);
                        Canvas.SetTop(bonus, nextY + 15);
                        Canvas.SetLeft(bonus, nextX + 15);
                        ochki++;
                    }
                }

            }

        }

    }
}
