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

    //List<Thing> t = new List<Thing>
    //{
    //new Thing("吃饭",DateTime.Now,DateTime.Now,"习惯","重要","每天三顿"),
    //new Thing("看电影",DateTime.Now,DateTime.Now,"计划","重要","带女朋友去看"),
    //new Thing("玩游戏",DateTime.Now,DateTime.Now,"目标","普通","别玩太久"),
    //new Thing("学习",DateTime.Now,DateTime.Now,"一次","紧急","期末考试到了")
    //};
    //保存事件集合到things.dat
    //转换list到observableCollection并赋值给viewModel.ThingsList
    //可以不用转换，转换是在修改bug时所加，以为可以改正bug，后发现没有
    //bug是PropertyChanged未序列化
    //ObservableCollection<Thing> t = new ObservableCollection<Thing>
    //{
    //new Thing("吃饭",DateTime.Now,DateTime.Now,"习惯","重要","每天三顿"),
    //new Thing("看电影",DateTime.Now,DateTime.Now,"计划","重要","带女朋友去看"),
    //new Thing("玩游戏",DateTime.Now,DateTime.Now,"目标","普通","别玩太久"),
    //new Thing("学习",DateTime.Now,DateTime.Now,"一次","紧急","期末考试到了")
    //};
    //ObservableCollection<Thing> t = FileMethod.ReadThings("..//..//storage//things.dat");
    //ObservableCollection<Note> n = new ObservableCollection<Note>
    //{
    //    new Note("chifan",5,DateTime.Now,DateTime.Now)
    //};

    //FileMethod.SaveNotes("..//..//storage//notes.dat", n);
    public static class FileMethod
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
