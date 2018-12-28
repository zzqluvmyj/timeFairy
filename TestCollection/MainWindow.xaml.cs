using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestCollection
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>

    public class Students : INotifyPropertyChanged
    {
        string _name;
        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public int Age { get; set; }
        protected internal virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Students> studentList;
        public ObservableCollection<Students> StudentList
        {
            get
            {
                return this.studentList;
            }
            set
            {
                if (this.studentList != value)
                {
                    this.studentList = value;
                    NotifyPropertyChanged("StudentList");
                }
            }
        }
        //通知绑定属性的改变
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
    public partial class MainWindow : Window
    {
        //ObservableCollection<Students> infos = new ObservableCollection<Students>() {
        //    new Students(){ Id=1, Age=11, Name="Tom"},
        //    new Students(){ Id=2, Age=12, Name="Darren"},
        //    new Students(){ Id=3, Age=13, Name="Jacky"},
        //    new Students(){ Id=4, Age=14, Name="Andy"}
        //    };
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();

            //this.lbStudent.ItemsSource = infos;
            //创建依赖属性
            //this.txtStudentId.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Id") { Source = lbStudent });

            viewModel.StudentList = new ObservableCollection<Students>() {
            new Students(){ Id=1, Age=11, Name="Tom"},
            new Students(){ Id=2, Age=12, Name="Darren"},
            new Students(){ Id=3, Age=13, Name="Jacky"},
            new Students(){ Id=4, Age=14, Name="Andy"}
            };
            this.lbStudent.DataContext = viewModel;

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            viewModel.StudentList[1] = new Students() { Id = 4, Age = 14, Name = "这是一个集合改变" };

            viewModel.StudentList = new ObservableCollection<Students>() {
            new Students(){ Id=19, Age=111, Name="这是变化后的几何"},
            new Students(){ Id=29, Age=121, Name="这是变化后的几何"},
            new Students(){ Id=39, Age=131, Name="这是变化后的几何"},
            new Students(){ Id=49, Age=141, Name="这是变化后的几何"}
            };
            viewModel.StudentList[2].Name = "这是一个属性改变";
        }        
    }
}
