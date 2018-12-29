using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    [Serializable]
    public class Thing : INotifyPropertyChanged, IEditableObject
    {
        //分别为名称，备注，开始时间，结束时间，种类，优先级
        [Serializable]
        private struct ThingItem
        {
            internal string Name;
            internal string Etc;
            internal DateTime StartTime;
            internal DateTime EndTime;
            internal string Kind;
            internal string Priority;
        }
        private ThingItem copyThing;
        private ThingItem currentThing;
        public Thing()
            :this("",DateTime.Now,DateTime.Now)
        { }

        public Thing(string name, DateTime startTime, DateTime endTime, string kind="备忘", string priority="普通", string etc="")
        {
            Name = name;
            Etc = etc;
            StartTime = startTime;
            EndTime = endTime;
            Kind = kind;
            Priority = priority;
        }

        public string Name {
            get { return currentThing.Name; }
            set
            {
                if(currentThing.Name!=value)
                {
                    currentThing.Name = value;
                    Notify("Name");
                }
            }
        }
        public string Etc
        {
            get { return currentThing.Etc; }
            set
            {
                if (currentThing.Etc != value)
                {
                    currentThing.Etc = value;
                    Notify("Etc");
                }
            }
        }
        public DateTime StartTime
        {
            get { return currentThing.StartTime; }
            set
            {
                if (currentThing.StartTime != value)
                {
                    currentThing.StartTime = value;
                    Notify("StartTime");
                }
            }
        }
        public DateTime EndTime
        {
            get { return currentThing.EndTime; }
            set
            {
                if (currentThing.EndTime != value)
                {
                    currentThing.EndTime = value;
                    Notify("EndTime");
                }
            }
        }
        public string Kind
        {
            get { return currentThing.Kind; }
            set
            {
                if (currentThing.Kind != value)
                {
                    currentThing.Kind = value;
                    Notify("Kind");
                }
            }
        }
        public string Priority
        {
            get { return currentThing.Priority; }
            set
            {
                if (currentThing.Priority != value)
                {
                    currentThing.Priority = value;
                    Notify("Priority");
                }
            }
        }


        public override string ToString() => $"{Name}, {Etc}, {StartTime:D},{EndTime:D},{Kind},{Priority}";

        //实现了事件提醒的接口，用于数据绑定
        //为了防止报错：未实现Inotify接口的PropertyChanged属性
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void BeginEdit()
        {
            copyThing = currentThing;
        }

        public void EndEdit()
        {
            copyThing = new ThingItem();
        }

        public void CancelEdit()
        {
            currentThing = copyThing;
            Notify("");
        }
    }

}
