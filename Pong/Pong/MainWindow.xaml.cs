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

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ballSpeed = 8;
        int ballSpeedX = 1;
        int ballSpeedY = 1;
        int ballX = 0;
        int ballY = 0;

        int centerX = 410;
        int centerY = 300;
        int botBoundary;

        int playerSpeed = 8;
        bool movingUp = false;
        bool movingDown = false;
        bool movingUpB = false;
        bool movingDownB = false;

        int spaceBar = 1;
        int player1score = 0;
        int player2score = 0;

        Random random = new Random();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            field.Focus();
            botBoundary = (int)(field.Height - paddle1.Height);

            Canvas.SetLeft(ball, centerX - ball.Width/2);
            Canvas.SetTop(ball, centerY-ball.Height/2);

            timer.Tick += PongTimer;
            timer.Interval = TimeSpan.FromMilliseconds(10);
        }

        private void PongTimer(object sender, EventArgs e)
        {
            ball.Visibility = Visibility.Visible;

            ballX = (int)Canvas.GetLeft(ball);
            ballY = (int)Canvas.GetTop(ball);

            ballX += ballSpeed * ballSpeedX;
            ballY += ballSpeed * ballSpeedY;

            Canvas.SetLeft(ball, ballX);
            Canvas.SetTop(ball, ballY);

            if (movingDown && Canvas.GetTop(paddle1) < botBoundary)
            {
                int n = (int)Canvas.GetTop(paddle1);
                Canvas.SetTop(paddle1, n + playerSpeed);
            }
            if (movingUp && Canvas.GetTop(paddle1) > 0)
            {
                int n = (int)Canvas.GetTop(paddle1);
                Canvas.SetTop(paddle1, n - playerSpeed);
            }

            if (movingDownB && Canvas.GetTop(paddle2) < botBoundary)
            {
                int n = (int)Canvas.GetTop(paddle2);
                Canvas.SetTop(paddle2, n + playerSpeed);
            }
            if (movingUpB && Canvas.GetTop(paddle2) > 0)
            {
                int n = (int)Canvas.GetTop(paddle2);
                Canvas.SetTop(paddle2, n - playerSpeed);
            }

            if (Canvas.GetLeft(ball) <= Canvas.GetLeft(paddle1) + paddle1.Width + 10 && (Canvas.GetTop(ball) + paddle1.Height >= Canvas.GetTop(paddle1) && Canvas.GetTop(ball) <= Canvas.GetTop(paddle1) + paddle1.Height))
            {
                ballSpeedX *= -1;
            }

            if (Canvas.GetLeft(ball) + ball.Width >= Canvas.GetLeft(paddle2) && (Canvas.GetTop(ball) + paddle2.Height >= Canvas.GetTop(paddle2) && Canvas.GetTop(ball) <= Canvas.GetTop(paddle2) + paddle2.Height))
            {
                ballSpeedX *= -1;
            }

            if (Canvas.GetLeft(ball) < 10)
            {
                player2score += 1;
                p2score.Text = "" + player2score;
                ResetField();
            }

            if (Canvas.GetLeft(ball) > field.Width - 10)
            {
                player1score += 1;
                p1score.Text = "" + player1score;
                ResetField();
            }

            //Ball bounces off top and bottom boundaries
            if (Canvas.GetTop(ball) <= 0 || Canvas.GetTop(ball) + ball.Height >= field.Height)
            {
                ballSpeedY *= -1;
            }

        }

        private void ResetField() 
        {
            status.Visibility = Visibility.Visible;
            ball.Visibility = Visibility.Hidden;

            timer.Stop();
            ballSpeed *= -1;
            int newPositionY = random.Next(100,300);

            Canvas.SetLeft(ball, centerX);
            Canvas.SetTop(ball, newPositionY);

            spaceBar++;
        }

        private void win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Z)
            {
                movingDown = true;
            }
            if (e.Key == Key.A)
            { 
                movingUp = true;
            }
              
            if (e.Key == Key.M)
            {
                movingDownB = true;
            }
            if (e.Key == Key.K)
            {
                movingUpB = true;
            }

            if (e.Key == Key.Space)
            {
                spaceBar++;
                if (spaceBar % 2 == 1)
                {
                    status.Visibility = Visibility.Visible;
                    timer.Stop();
                }
                else
                {
                    status.Visibility = Visibility.Hidden;
                    timer.Start();
                }
            }

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                timer.Interval = TimeSpan.FromMilliseconds(50);
            }
            if (e.Key == Key.S || e.Key == Key.J)
            {
                paddle1.Height = paddle2.Height = 150;
            }
        }

        private void win_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Z)
            {
                movingDown = false;

            }
            if (e.Key == Key.A)
            {
                movingUp = false;
            }

            if (e.Key == Key.M)
            {
                movingDownB = false;
            }

            if (e.Key == Key.K)
            {
                movingUpB = false;
            }

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                timer.Interval = TimeSpan.FromMilliseconds(20);
            }

            if (e.Key == Key.S || e.Key == Key.J)
            {
                paddle1.Height = paddle2.Height = 110;
            }
        }
    }
}
