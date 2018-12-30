﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    [Serializable]
    public class Thing : INotifyPropertyChanged
    {
        //分别为名称，备注，开始时间，结束时间，种类，优先级

        private int thingid;
        private string name;
        private string etc;
        private DateTime startTime;
        private DateTime endTime;
        private string kind;
        private string priority;

        public Thing()
        {
            Name = "";
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Kind = "备忘";
            Priority = "普通";
            Etc = "";
        }
        public Thing(int thingid,string name, DateTime startTime, DateTime endTime, string kind="备忘", string priority="普通", string etc="")
        {
            Name = name;
            Etc = etc;
            StartTime = startTime;
            EndTime = endTime;
            Kind = kind;
            Priority = priority;
            Thingid = thingid;
        }

        public string Name {
            get { return name; }
            set
            {
                if(name!=value)
                {
                    name = value;
                    Notify("Name");
                }
            }
        }
        public string Etc
        {
            get { return etc; }
            set
            {
                if (etc != value)
                {
                    etc = value;
                    Notify("Etc");
                }
            }
        }
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if (startTime != value)
                {
                    startTime = value;
                    Notify("StartTime");
                }
            }
        }
        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    Notify("EndTime");
                }
            }
        }
        public string Kind
        {
            get { return kind; }
            set
            {
                if (kind != value)
                {
                    kind = value;
                    Notify("Kind");
                }
            }
        }
        public int Thingid
        {
            get { return thingid; }
            set
            {
                if (thingid != value)
                {
                    thingid = value;
                    Notify("Thingid");
                }
            }
        }
        public string Priority
        {
            get { return priority; }
            set
            {
                if (priority != value)
                {
                    priority = value;
                    Notify("Priority");
                }
            }
        }


        public override string ToString() => $"{Name}, {Etc}, {StartTime:d},{EndTime:d},{Kind},{Priority}";

        //实现了事件提醒的接口，用于数据绑定
        //为了防止报错：未实现Inotify接口的PropertyChanged属性
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
