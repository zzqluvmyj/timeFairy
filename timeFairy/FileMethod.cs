using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    class FileMethod
    {
        //实例化对象列表,保存到文件
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
        //实例化对象列表,保存到文件
        public static void SaveNotes(string filename, ObservableCollection<Note> notes)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, notes);
            fs.Close();
        }
        //反实例化对象列表，读出文件到对象
        public static ObservableCollection<Note> ReadNotes(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ObservableCollection<Note> notes = bf.Deserialize(fs) as ObservableCollection<Note>;
            fs.Close();
            return notes;
        }
    }
}
