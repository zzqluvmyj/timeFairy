using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            ObservableCollection<Thing> t = FileMethod.ReadThings("..//..//storage//things.dat");
            ObservableCollection<Note> n = FileMethod.ReadNotes("..//..//storage//notes.dat");
            viewModel.ThingsList = t;
            viewModel.NotesList = n;

            
        }


        //防止出现打开新窗口关闭后无法再次打开新窗口的问题
        //同时保存事件列表到文件
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            FileMethod.SaveThings("..//..//storage//things.dat", viewModel.ThingsList);
            FileMethod.SaveNotes("..//..//storage//notes.dat", viewModel.NotesList);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editableCollectionView = AllThings.Items as IEditableCollectionView;

            if (!editableCollectionView.CanAddNew)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("You cannot add items to the list.");
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
                Xceed.Wpf.Toolkit.MessageBox.Show("No item is selected");
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
                Xceed.Wpf.Toolkit.MessageBox.Show("No Item is selected");
                return;
            }

            var editableCollectionView =
                AllThings.Items as IEditableCollectionView;

            if (!editableCollectionView.CanRemove)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("You cannot remove items from the list.");
                return;
            }

            if (Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to remove " + item.Name,
                "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                editableCollectionView.Remove(AllThings.SelectedItem);
                //FileMethod.SaveThings("..//..//storage//things.dat",CollectionToList(viewModel.ThingsList));
            }
        }
        //回调函数添加新的note到noteslist
        private void PassTimeLength(TimeSpan span,Thing thing)
        {
            viewModel.NotesList.Add(new Note(thing.Name,span.TotalSeconds,DateTime.Now,thing.EndTime));
        }
        private void Record_Click(object sender, RoutedEventArgs e)
        {
            var item = AllThings.SelectedItem as Thing;

            if (item == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("No Item is selected");
                return;
            }
            var win = new Recorder(item);
            win.Show();
            win.CallBackMethod = PassTimeLength;
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            DrawPre.getList(viewModel.NotesList);
            var shapes = DrawPre.GetShapes();
            var labels = DrawPre.getLabel();

            foreach (var shape in shapes)
            {
                this.canvas.Children.Add(shape);
            }

            foreach (var item in labels)
            {
                this.stack.Children.Add(item);
            }

        }
    }
}
