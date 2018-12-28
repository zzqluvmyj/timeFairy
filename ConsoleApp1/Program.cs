using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThing
{
    class Program
    {
        [Serializable]
        public class Thing
        {
            private string name;
            private string etc;
            private DateTime startTime;
            private DateTime endTime;
            private string flag;
            private byte priority;

            public Thing(string name, string etc, DateTime startTime, DateTime endTime, string flag, byte priority)
            {
                this.name = name;
                this.etc = etc;
                this.startTime = startTime;
                this.endTime = endTime;
                this.flag = flag;
                this.priority = priority;
            }

            public string Name { get => name; set => name = value; }
            public string Etc { get => etc; set => etc = value; }
            public DateTime StartTime { get => startTime; set => startTime = value; }
            public DateTime EndTime { get => endTime; set => endTime = value; }
            public string Flag { get => flag; set => flag = value; }
            public byte Priority { get => priority; set => priority = value; }
        }

            static void Main(string[] args)
        {
            List<Thing> things = new List<Thing>();
            string dir = @"D:\cangku\c#program\timeFairy\timeFairy\data";
            string serializationFile = Path.Combine(dir, "things.bin");

            //serialize

            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                List<Thing> salesman = (List<Thing>)bformatter.Deserialize(stream);
            }
        }
    }
}
