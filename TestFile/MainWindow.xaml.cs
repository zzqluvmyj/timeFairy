using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestFile
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public enum PriorityType
    {
        NN, IN, NE, IE
    }
        [Serializable]
        public class Thing
        {
            //分别为名称，备注，开始时间，结束时间，标记，优先级

                private string Name;
                private string Etc;
                private DateTime StartTime;
                private DateTime EndTime;
                private string Kind;
                private PriorityType Priority;

        public Thing(string name, DateTime startTime, DateTime endTime, string kind="", PriorityType priority=PriorityType.NN, string etc=" ")
        {
            Name1 = name;
            Etc1 = etc;
            StartTime1 = startTime;
            EndTime1 = endTime;
            Kind1 = kind;
            Priority1 = priority;
        }

        public string Name1 { get => Name; set => Name = value; }
        public string Etc1 { get => Etc; set => Etc = value; }
        public DateTime StartTime1 { get => StartTime; set => StartTime = value; }
        public DateTime EndTime1 { get => EndTime; set => EndTime = value; }
        public string Kind1 { get => Kind; set => Kind = value; }
        public PriorityType Priority1 { get => Priority; set => Priority = value; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Thing> things1 = new ObservableCollection<Thing>
            {
                new Thing("上厕所",DateTime.Now,DateTime.Now),
                new Thing("睡觉",DateTime.Now,DateTime.Now),
                new Thing("吃饭",DateTime.Now,DateTime.Now),
                new Thing("玩游戏",DateTime.Now,DateTime.Now)
            };
            List<Thing> things = new List<Thing>
            {
                new Thing("上厕所",DateTime.Now,DateTime.Now),
                new Thing("睡觉",DateTime.Now,DateTime.Now),
                new Thing("吃饭",DateTime.Now,DateTime.Now),
                new Thing("玩游戏",DateTime.Now,DateTime.Now)
            };
            FileStream fs = new FileStream("f.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, things1);
            fs.Close();
        }
        public static void SaveThings(string filename, ObservableCollection<Thing> things)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, things);
            fs.Close();
        }
        //反实例化对象列表，读出文件到对象
        public static ObservableCollection<Thing> ReadThings(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ObservableCollection<Thing> things = bf.Deserialize(fs) as ObservableCollection<Thing>;
            fs.Close();
            return things;
        }
    }
}
