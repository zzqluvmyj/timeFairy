using System;
using System.Windows;

namespace timeFairy
{
    /// <summary>
    /// 编辑事件窗口
    /// </summary>
    public partial class ChangeThing : Window
    {
        //和addthing类大同小异
        private Thing thing;
        public DelegateClass.delegateThing CallBackThing;
        public ChangeThing()
        {
            InitializeComponent();
            thing = new Thing();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            thing.Name = name.Text;
            thing.Kind = kind.Text;
            thing.Priority = priority.Text;
            thing.StartTime = Convert.ToDateTime(starttime.Text);
            thing.Etc = etc.Text;
            thing.EndTime = Convert.ToDateTime(endtime.Text);

            CallBackThing(thing);
            Close();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
