using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rectangle rect;
        List<Rectangle> rectangles;
        Input input= new Input();
        Storyboard storyboard;   //建立故事畫板
        int preX = 0;
        int midX = 300;
        int endX = 800;
        int nowPackage;
        List<int> packages = new List<int>{ 4,3, 3, 3, 0,0,5,1,7 };
        List<int> leftBabels = new List<int>();
        int CAP=8;
        int leftCAP=8;
        int rate = 3;
        public MainWindow()
        {
            InitializeComponent();
            rectangles = new List<Rectangle>();
            leftBabels.Add(leftCAP);
            var t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0,1);
            t.Tick += OnTimer;
            t.IsEnabled = true;
            t.Start();
        }

        private void DrawBucket(int n)
        {
            Rectangle rect1 = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.BurlyWood),   //矩形的填充顏色為綠色!

                Width = 120,  //矩形的寬度、高度各為80!
                Height = 120,
                RadiusX = 5,   //矩形的四周圓角為8!
                RadiusY = 5
            };
            Canvas.SetLeft(rect1, midX);
            Canvas.SetTop(rect1, 0);
            this.canvas.Children.Add(rect1);
            for(int i = 0; i < leftBabels[n]; i++)
            {
                Rectangle rect2 = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Black),   //矩形的填充顏色為綠色!

                    Width = 20,  //矩形的寬度、高度各為80!
                    Height = 20,
                    RadiusX = 5,   //矩形的四周圓角為8!
                    RadiusY = 5
                };
                Canvas.SetLeft(rect2,midX+i%4*30);
                Canvas.SetTop(rect2, Convert.ToInt32(i/4)*30);
                this.canvas.Children.Add(rect2);
            }
        }
        private void OnTimer(object sender, EventArgs e)
        {
            if (leftCAP < CAP)
            {
                leftCAP += rate;
                if (leftCAP > 8) leftCAP = CAP;
            }
            
            if (nowPackage < packages.Count) {
                
                Move(300,preX, new SolidColorBrush(Colors.Black),new TimeSpan(0,0,nowS));
                
                rectangles.Clear();
                if (packages[nowPackage] > CAP)
                {
                    Move(800,midX, new SolidColorBrush(Colors.Red), new TimeSpan(0, 0, nowS+1));
                    DrawBucket(nowPackage);
                    //Rectangle rect1 = new Rectangle
                    //{
                    //    Fill = new SolidColorBrush(Colors.BurlyWood),   //矩形的填充顏色為綠色!

                    //    Width = 120,  //矩形的寬度、高度各為80!
                    //    Height = 90,
                    //    RadiusX = 5,   //矩形的四周圓角為8!
                    //    RadiusY = 5
                    //};
                    //Canvas.SetLeft(rect1, 300);
                    //Canvas.SetTop(rect1,0);
                    //this.canvas.Children.Add(rect1);
                    rectangles.Clear();
                }
                else
                {
                    leftCAP = leftCAP - packages[nowPackage];
                    Move(700, midX, new SolidColorBrush(Colors.Green), new TimeSpan(0, 0, nowS+1));
                    DrawBucket(nowPackage);
                    rectangles.Clear();
                }
                leftBabels.Add(leftCAP);
                nowPackage++;
            }
            
        }

        private void Create_Recs(int num,int X, SolidColorBrush color)
        {
            for(int i = 0; i < num; i++)
            {
                rect = new Rectangle
                {
                    Fill = color,   //矩形的填充顏色為綠色!

                    Width = 20,  //矩形的寬度、高度各為80!
                    Height = 20,
                    RadiusX = 5,   //矩形的四周圓角為8!
                    RadiusY = 5
            };    //建立一個新的矩形!

                Canvas.SetLeft(rect,X+(i%4)*30);
                int j = Convert.ToInt32(i / 4);
                if (j>0)
                Canvas.SetTop(rect, j*30);
                rectangles.Add(rect);
            }
        }

        private void Move(int endPonint,int startPoint, SolidColorBrush color,TimeSpan begin)
        {
            storyboard = new Storyboard();
            int i = 0;
            int p = 0;
            Create_Recs(packages[nowPackage], startPoint, color);
            foreach (Rectangle rec in rectangles)
            {
                this.canvas.Children.Add(rec);
                if (i >= 4)
                {
                    p =  i % 4 * 30;
                }
                else
                {
                    p = i * 30;
                }
                DoubleAnimation MyDoubleAnimation = new DoubleAnimation(     
                Canvas.GetLeft(rec),
                endPonint+p,
                new Duration(TimeSpan.FromMilliseconds(1000)));
                Storyboard.SetTarget(MyDoubleAnimation, rec);  
                Storyboard.SetTargetProperty(MyDoubleAnimation, new PropertyPath("(Canvas.Left)"));
                storyboard.Children.Add(MyDoubleAnimation);  
                i++;
            }
            storyboard.BeginTime=begin;
            storyboard.Begin();   
        }
    }

}