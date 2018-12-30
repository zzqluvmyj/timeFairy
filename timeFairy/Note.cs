using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    [Serializable]
    public class Note : INotifyPropertyChanged
    {
        //事件名称，序号，时长，实际结束时间，预期结束时间
        //时长为秒，因为在实际测试中等不了太长时间
        //后期有空可以在显示的时候将秒转换为时分，但实际的单位仍然是秒
        private string name;
        private static double id=0;
        private double m;
        private DateTime actualTime;
        private DateTime expectTime;



        public Note(string name,double m, DateTime actualTime, DateTime expectTime)
        {
            Name = name;
            Id = id+1;
            M = m;
            ActualTime = actualTime;
            ExpectTime = expectTime;
        }

        public string Name
        {
            get { return name; }
            set { name = value;Notify("Name"); }
        }
        public double Id
        {
            get { return id; }
            set { id = value;Notify("Id"); }
        }
        public double M
        {
            get { return m; }
            set { m = value; Notify("M"); }
        }
        public DateTime ActualTime
        {
            get { return actualTime; }
            set { actualTime = value; Notify("ActualTime"); }
        }
        public DateTime ExpectTime
        {
            get { return expectTime; }
            set { expectTime = value; Notify("ExpectTime"); }
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
