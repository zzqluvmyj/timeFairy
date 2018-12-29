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
        //ObservableCollection<Thing> ListToCollection(List<Thing> tempList)
        //{
        //    ObservableCollection<Thing> tempCollection = new ObservableCollection<Thing>();
        //    tempList.ForEach(p => tempCollection.Add(p));
        //    return tempCollection;
        //}
        //List<Thing> CollectionToList(ObservableCollection<Thing> tempCollection)
        //{
        //    List<Thing> tempList = new List<Thing>();
        //    tempList = tempCollection.ToList();
        //    return tempList;
        //}

        public MenuWindow()
        {
            InitializeComponent();

            this.DataContext = viewModel;

            //List<Thing> t = new List<Thing>
            //{
            //new Thing("吃饭",DateTime.Now,DateTime.Now,"习惯","重要","每天三顿"),
            //new Thing("看电影",DateTime.Now,DateTime.Now,"计划","重要","带女朋友去看"),
            //new Thing("玩游戏",DateTime.Now,DateTime.Now,"目标","普通","别玩太久"),
            //new Thing("学习",DateTime.Now,DateTime.Now,"一次","紧急","期末考试到了")
            //};
            //保存事件集合到things.dat
            //转换list到observableCollection并赋值给viewModel.ThingsList
            //可以不用转换，转换是在修改bug时所加，以为可以改正bug，后发现没有
            //bug是PropertyChanged未序列化
            ObservableCollection<Thing> t = new ObservableCollection<Thing>
            {
            new Thing("吃饭",DateTime.Now,DateTime.Now,"习惯","重要","每天三顿"),
            new Thing("看电影",DateTime.Now,DateTime.Now,"计划","重要","带女朋友去看"),
            new Thing("玩游戏",DateTime.Now,DateTime.Now,"目标","普通","别玩太久"),
            new Thing("学习",DateTime.Now,DateTime.Now,"一次","紧急","期末考试到了")
            };
            FileMethod.SaveThings("..//..//storage//things.dat", t);
            //ObservableCollection<Thing> t = FileMethod.ReadThings("..//..//storage//things.dat");
            ObservableCollection<Note> n = new ObservableCollection<Note>
            {
                new Note("chifan",5,DateTime.Now,DateTime.Now)
            };

            viewModel.ThingsList = t;
            viewModel.NotesList = n;

            //FileMethod.SaveThings("..//..//storage//things.dat", t);

        }


        //防止出现打开新窗口关闭后无法再次打开新窗口的问题
        //同时保存事件列表到文件
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            FileMethod.SaveThings("..//..//storage//things.dat", viewModel.ThingsList);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editableCollectionView = AllThings.Items as IEditableCollectionView;

            if (!editableCollectionView.CanAddNew)
            {
                MessageBox.Show("You cannot add items to the list.");
                return;
            }

            // Create a window that prompts the user to enter a new
            // item to sell.
            var win = new ChangeThing { DataContext = editableCollectionView.AddNew() };

            //Create a new item to be added to the collection.

            // If the user submits the new item, commit the new
            // object to the collection.  If the user cancels 
            // adding the new item, discard the new item.
            if ((bool)win.ShowDialog())
            {
                editableCollectionView.CommitNew();
                //FileMethod.SaveThings("..//..//storage//things.dat", CollectionToList(viewModel.ThingsList));
            }
            else
            {
                editableCollectionView.CancelNew();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (AllThings.SelectedItem == null)
            {
                MessageBox.Show("No item is selected");
                return;
            }

            var editableCollectionView =
                AllThings.Items as IEditableCollectionView;

            // Create a window that prompts the user to edit an item.
            var win = new ChangeThing();
            editableCollectionView.EditItem(AllThings.SelectedItem);
            win.DataContext = AllThings.SelectedItem;

            // If the user submits the new item, commit the changes.
            // If the user cancels the edits, discard the changes. 
            if ((bool)win.ShowDialog())
            {
                editableCollectionView.CommitEdit();
                //FileMethod.SaveThings("..//..//storage//things.dat", CollectionToList(viewModel.ThingsList));
            }
            else
            {
                editableCollectionView.CancelEdit();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var item = AllThings.SelectedItem as Thing;
            if (item == null)
            {
                MessageBox.Show("No Item is selected");
                return;
            }

            var editableCollectionView =
                AllThings.Items as IEditableCollectionView;

            if (!editableCollectionView.CanRemove)
            {
                MessageBox.Show("You cannot remove items from the list.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove " + item.Name,
                "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                editableCollectionView.Remove(AllThings.SelectedItem);
                //FileMethod.SaveThings("..//..//storage//things.dat",CollectionToList(viewModel.ThingsList));
            }
        }
        //回调函数添加新的note到noteslist
        private void PassTimeLength(TimeSpan span,Thing thing)
        {
            viewModel.NotesList.Add(new Note(thing.Name,span.TotalMinutes,DateTime.Now,thing.EndTime));
        }
        private void Record_Click(object sender, RoutedEventArgs e)
        {
            var item = AllThings.SelectedItem as Thing;

            if (item == null)
            {
                MessageBox.Show("No Item is selected");
                return;
            }
            var win = new Recorder(item);
            win.Show();
            win.CallBackMethod = PassTimeLength;
        }
    }
}
