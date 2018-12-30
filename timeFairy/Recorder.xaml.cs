using System;
using System.Windows;
using System.Windows.Threading;

namespace timeFairy
{
    //使用回调函数返回子窗口的计时数据
    
   
    public partial class Recorder : Window
    {
        public DelegateClass.delegateTime CallBackTime;
        enum State
        {
            Start,
            Pause,
            End
        }
        State state = State.End;
        private TimeSpan timeLength = new TimeSpan(0, 0, 0, 0);
        private Thing thing;
        public TimeSpan TimeLength
        {
            get { return timeLength; }
            set { timeLength = value; }
        }

        public Recorder(Thing thing)
        {
            
            InitializeComponent();
            var t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0, 1);
            t.Tick += OnTimer;
            t.IsEnabled = true;
            t.Start();
            this.thing = thing;
        }

        void OnTimer(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.Start:
                    {
                        timeLength += new TimeSpan(0, 0, 0, 1);
                    }
                    break;
                case State.Pause:
                    {

                    }
                    break;
                case State.End:
                    {

                        timeLength = new TimeSpan();
                    }
                    break;
            }

            var time = string.Format("{0:D2}:{1:D2}:{2:D2}", timeLength.Hours, timeLength.Minutes, timeLength.Seconds);
            textBox.Text = time;
            label.Content = time;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CallBackTime(timeLength.TotalSeconds,thing);
            Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            state = State.Start;
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            state = State.Pause;
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            state = State.End;
        }

    }
}
