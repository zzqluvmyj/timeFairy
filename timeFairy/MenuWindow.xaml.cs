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

            ObservableCollection<Thing> t = new ObservableCollection<Thing>();
            t.Add(new Thing(t.Count, "吃饭", DateTime.Now, DateTime.Now, "习惯", "重要", "每天三顿"));
            t.Add(new Thing(t.Count, "吃饭", DateTime.Now, DateTime.Now, "习惯", "重要", "每天三顿"));
            t.Add(new Thing(t.Count, "看电影", DateTime.Now, DateTime.Now, "计划", "重要", "带女朋友去看"));
            t.Add(new Thing(t.Count, "玩游戏",DateTime.Now,DateTime.Now,"目标","普通","别玩太久"));
            t.Add(new Thing(t.Count, "学习", DateTime.Now, DateTime.Now, "一次", "紧急", "期末考试到了"));

            //ObservableCollection<Thing> t = FileMethod.ReadThings("..//..//storage//things.dat");
            //ObservableCollection<Note> n = FileMethod.ReadNotes("..//..//storage//notes.dat");
            ObservableCollection<Note> n = new ObservableCollection<Note>();

            n.Add(new Note(n.Count,"吃饭", 10,DateTime.Now, DateTime.Now,1));

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
            var win = new AddThing();
            win.Show();
            win.CallBackThing = addThing;
        }
        private void addThing(Thing thing)
        {
            if (thing.Name.Length!=0) {
                thing.Thingid = viewModel.ThingsList.Count;
                viewModel.ThingsList.Add(thing);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("事件名称不能为空");
            }
               
        }
        private void EditThing(Thing thing)
        {
            viewModel.ThingsList.Add(thing);
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
             
            if (AllThings.SelectedItem == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("No item is selected");
                return;
            }

            var win = new ChangeThing();
            var temp = AllThings.SelectedItem as Thing;//原来的
            win.DataContext = temp;
            win.CallBackThing = EditThing;

            // If the user submits the new item, commit the changes.
            // If the user cancels the edits, discard the changes. 
            if ((bool)win.ShowDialog())
            {
                viewModel.ThingsList.Remove(AllThings.SelectedItem as Thing);
                win.CallBackThing = EditThing;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var temp = AllThings.SelectedItem as Thing;
            if (temp == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("No Item is selected");
                return;
            }


            if (Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to remove " + temp.Name,
                "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                viewModel.ThingsList.Remove(temp);
                //FileMethod.SaveThings("..//..//storage//things.dat",CollectionToList(viewModel.ThingsList));
            }
        }
        //回调函数添加新的note到noteslist
        private void PassTimeLength(double time,Thing thing)
        {
            viewModel.NotesList.Add(new Note(viewModel.NotesList.Count,thing.Name,time,DateTime.Now,thing.EndTime,thing.Thingid));
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
            win.CallBackTime = PassTimeLength;
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.Children.Clear();
            this.wrap.Children.Clear();
            DrawPre.ClearUp();
            DrawPre.getList(viewModel.NotesList);
            var shapes = DrawPre.GetShapes();
            var labels = DrawPre.getLabel();

            foreach (var shape in shapes)
            {
                this.canvas.Children.Add(shape);
            }

            foreach (var item in labels)
            {
                this.wrap.Children.Add(item);
            }

        }
    }
}
