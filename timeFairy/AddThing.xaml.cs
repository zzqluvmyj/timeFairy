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
using System.Windows.Shapes;

namespace timeFairy
{
    /// <summary>
    /// ChangeThing.xaml 的交互逻辑
    /// </summary>
    public partial class AddThing : Window
    {
        private Thing thing;
        public DelegateClass.delegateThing CallBackThing;
        public AddThing()
        {
            InitializeComponent();
            thing = new Thing();
            this.DataContext = thing;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CallBackThing(thing);
            Close();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
