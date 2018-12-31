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
    /// 包含事件，记录，绘图三大功能块，具体见注释
    /// </summary>
    public partial class MenuWindow : Window
    {

        ViewModel viewModel = new ViewModel();
        //以下为测试数据
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
            //设置上下文
            this.DataContext = viewModel;
            //读取事件和事件记录到两个ObservableCollection列表
            try {
                ObservableCollection<Thing> t = FileMethod.ReadThings("..//..//storage//things.dat");
                ObservableCollection<Note> n = FileMethod.ReadNotes("..//..//storage//notes.dat");
                //ObservableCollection<Note> n = new ObservableCollection<Note>();
                viewModel.ThingsList = t;
                viewModel.NotesList = n;
            }
            catch (System.IO.FileNotFoundException) {
                viewModel.ThingsList = new ObservableCollection<Thing>();
                viewModel.NotesList = new ObservableCollection<Note>();
            }
            
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
        //增加事件
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddThing();
            win.Show();
            win.CallBackThing = addThing;
        }
        //增加时间的回调函数
        private void addThing(Thing thing)
        {
            if (thing.Name.Length!=0) {
                thing.Thingid = viewModel.ThingsList.Count;
                viewModel.ThingsList.Add(thing);
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("事件名称不能为空！");
            }
               
        }
        //编辑事件的回调函数
        private void EditThing(Thing thing)
        {
            viewModel.ThingsList.Add(thing);
        }
        //
        private void Edit_Click(object sender, RoutedEventArgs e)
        {             
            if (AllThings.SelectedItem == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("没有事件被选中！");
                return;
            }
            var win = new ChangeThing();
            var temp = AllThings.SelectedItem as Thing;//原来的事件
            win.DataContext = temp;
            win.CallBackThing = EditThing;
            if ((bool)win.ShowDialog())
            {
                viewModel.ThingsList.Remove(AllThings.SelectedItem as Thing);
                win.CallBackThing = EditThing;
            }
        }
        //
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var temp = AllThings.SelectedItem as Thing;
            if (temp == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("没有事件被选中！");
                return;
            }


            if (Xceed.Wpf.Toolkit.MessageBox.Show("确定要移除事件 " + temp.Name,
                "？", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                viewModel.ThingsList.Remove(temp);
                //FileMethod.SaveThings("..//..//storage//things.dat",CollectionToList(viewModel.ThingsList));
            }
        }
        //回调函数添加新的note到noteslist
        private void PassTimeLength(double time,Thing thing)
        {
            if(time>0)
            viewModel.NotesList.Add(new Note(viewModel.NotesList.Count,thing.Name,time,DateTime.Now,thing.EndTime,thing.Thingid));
        }
        private void Record_Click(object sender, RoutedEventArgs e)
        {
            var item = AllThings.SelectedItem as Thing;

            if (item == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("没有记录被选中！");
                return;
            }
            var win = new Recorder(item);
            win.Show();
            win.CallBackTime = PassTimeLength;
        }
        //画所有的
        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            DrawPre.getList(viewModel.NotesList);
            Draw();
        }
        //清空画板，重置列表
        private void ClearCanvas()
        {
            this.canvas.Children.Clear();
            this.wrap.Children.Clear();
            DrawPre.ClearUp();
        }
        //将扇形和图例添加到画板中
        private void Draw()
        {
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
        //改变日历的显示模式
        private void Change_Pattern(object sender, RoutedEventArgs e)
        {
            calendar.DisplayMode = CalendarMode.Month;
        }
        //当前月份的画图
        private void DrawMonth(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            DrawPre.getListm(viewModel.NotesList, DateTime.Now);
            Draw();
        }
        //选中日期的月份画图
        private void DrawTheMonth(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            try
            {
                DrawPre.getListm(viewModel.NotesList, calendar.SelectedDate.Value);
                Draw();
            }
            catch (System.InvalidOperationException)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("必须要选中某个日期！");
            }

        }
        //当前日期画图
        private void DrawDay(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            DrawPre.getListd(viewModel.NotesList, DateTime.Now);
            Draw();
        }
        //根据选中日期画图
        private void DrawTheDay(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            try
            {
                DrawPre.getListd(viewModel.NotesList, calendar.SelectedDate.Value);
                Draw();
            }
            catch (System.InvalidOperationException)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("必须要选中某个日期！");
            }

        }
    }
}
