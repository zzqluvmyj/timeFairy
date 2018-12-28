using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace timeFairy
{
    /// <summary>
    /// MenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MenuWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MenuWindow()
        {
            InitializeComponent();
            viewModel.ThingsList = new ObservableCollection<Thing>
            {
                new Thing("上厕所",DateTime.Now,DateTime.Now),
                new Thing("睡觉",DateTime.Now,DateTime.Now),
                new Thing("吃饭",DateTime.Now,DateTime.Now),
                new Thing("玩游戏",DateTime.Now,DateTime.Now)
            };
            this.AllThings.DataContext = viewModel;
        }


        //防止出现打开新窗口关闭后无法再次打开新窗口的问题
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
