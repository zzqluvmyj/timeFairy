using System.Windows;

namespace timeFairy
{
    /// <summary>
    /// 添加时间窗口
    /// </summary>
    public partial class AddThing : Window
    {
        
        private Thing thing;//用于回调的thing
        public DelegateClass.delegateThing CallBackThing;//回调函数声明
        public AddThing()
        {
            InitializeComponent();
            thing = new Thing();
            this.DataContext = thing; 
        }
        //回调thing并关闭
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CallBackThing(thing);
            Close();
        }
        //
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
