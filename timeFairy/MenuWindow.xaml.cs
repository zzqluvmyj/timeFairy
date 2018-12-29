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
        ObservableCollection<Thing> ListToCollection(List<Thing> tempList)
        {
            ObservableCollection<Thing> tempCollection = new ObservableCollection<Thing>();
            tempList.ForEach(p => tempCollection.Add(p));
            return tempCollection;
        }
        List<Thing> CollectionToList(ObservableCollection<Thing> tempCollection)
        {
            List<Thing> tempList = new List<Thing>();
            tempList = tempCollection.ToList();
            return tempList;
        }

        public MenuWindow()
        {
            InitializeComponent();

            this.AllThings.DataContext = viewModel;
            //viewModel.ThingsList = new ObservableCollection<Thing>() {
            //new Thing("SDF",DateTime.Now,DateTime.Now),
            //new Thing("DB",DateTime.Now,DateTime.Now),
            //new Thing("DSF",DateTime.Now,DateTime.Now),
            //new Thing("SFB",DateTime.Now,DateTime.Now)
            //};
            
            List<Thing> tlist = new List<Thing>
            {
            new Thing("SDF",DateTime.Now,DateTime.Now),
            new Thing("DB",DateTime.Now,DateTime.Now),
            new Thing("DSF",DateTime.Now,DateTime.Now),
            new Thing("SFB",DateTime.Now,DateTime.Now)
            };
            FileMethod.SaveThings("..//..//storage//file.dat", tlist);
            List<Thing> tlist1= FileMethod.ReadThings("..//..//storage//file.dat");
            viewModel.ThingsList = ListToCollection(tlist1);






        }


        //防止出现打开新窗口关闭后无法再次打开新窗口的问题
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            List<Thing> tlist = CollectionToList(viewModel.ThingsList);
            FileMethod.SaveThings("..//..//storage//f1.dat", tlist);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
