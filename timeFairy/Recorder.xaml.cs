using System;
using System.Windows;
using System.Windows.Threading;

namespace timeFairy
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Recorder : Window
    {
        /// <summary>
        /// 状态
        /// </summary>
        enum State
        {
            Start,
            Pause,
            End
        }

        /// <summary>
        /// 状态
        /// </summary>
        State _state = State.End;

        /// <summary>
        /// 计时用
        /// </summary>
        TimeSpan _timeSpan = new TimeSpan(0, 0, 0, 0, 0);

        public Recorder()
        {
            InitializeComponent();
            var t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0, 1);
            t.Tick += OnTimer;
            t.IsEnabled = true;
            t.Start();
        }

        /// <summary>
        /// 时钟回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnTimer(object sender, EventArgs e)
        {
            switch (_state)
            {
                case State.Start:
                    {
                        _timeSpan += new TimeSpan(0, 0, 0, 1);
                    }
                    break;
                case State.Pause:
                    {

                    }
                    break;
                case State.End:
                    {
                        _timeSpan = new TimeSpan();
                        //_timeSpan = new TimeSpan(0, 23, 12, 45, 54);
                    }
                    break;
            }

            var time = string.Format("{0:D2}:{1:D2}:{2:D2}", _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds);
            textBox.Text = time;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _state = State.Start;
        }
        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            _state = State.Pause;
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Click(object sender, RoutedEventArgs e)
        {
            _state = State.End;
        }
    }
}
