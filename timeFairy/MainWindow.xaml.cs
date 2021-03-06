﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace timeFairy
{
    /// <summary>
    /// 时钟的后台类
    /// </summary>
    public partial class MainWindow : Window
    {
        //Timer 组件是基于服务器的计时器，它使您能够指定在应用程序中引发 Elapsed 事件的周期性间隔。然后可通过处理这个事件来提供常规处理。
        //这里是设定一千毫秒的计时器，必须为全局变量，负责有可能被系统回收
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        private MenuWindow menuWindow = new MenuWindow();//创建菜单窗口的实例
        public MainWindow()
        {
            InitializeComponent();
            InitClock();
        }
        private void PressAndDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void InitClock()
        {
            
            secondPointer.Angle = DateTime.Now.Second * 6;
            minutePointer.Angle = DateTime.Now.Minute * 6;
            hourPointer.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            this.mytime.Content = DateTime.Now.ToString("HH:mm");
            this.mydate.Content = DateTime.Now.ToString("d");
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
         {
            //UI异步更新
             this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
             {
                 //秒针转动,秒针绕一圈360度，共60秒，所以1秒转动6度
                 secondPointer.Angle = DateTime.Now.Second* 6;
                 //分针转动,分针绕一圈360度，共60分，所以1分转动6度
                 minutePointer.Angle = DateTime.Now.Minute* 6;
                 //时针转动,时针绕一圈360度，共12时，所以1时转动30度。
                 //另外同一个小时内，随着分钟数的变化(绕一圈60分钟），时针也在缓慢变化（转动30度，30/60=0.5)
                 hourPointer.Angle = (DateTime.Now.Hour* 30)+ (DateTime.Now.Minute* 0.5);
                 //更新时间值
                 this.mytime.Content = DateTime.Now.ToString("HH:mm");
                 this.mydate.Content = DateTime.Now.ToString("d");
             }));
         }
        //关闭当前应用程序的所有窗口
        private void ApplicationClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //判断是否存在menu窗口，如果存在，则激活即可，不用多次打开
        private void OpenMenuWindow(object sender, RoutedEventArgs e)
        {
            if (menuWindow == null || menuWindow.IsVisible == false)
            {
                menuWindow.Show();
            }
            else
            {
                menuWindow.Activate();
                menuWindow.WindowState = System.Windows.WindowState.Normal;
            }
        }
    }
}
