using System;
using System.Collections.Generic;
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
        public static void SaveThings(string filename, List<Thing> things)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, things);
            fs.Close();
        }
        //反实例化对象列表，读出文件到对象
        public static List<Thing> ReadThings(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Thing> things = bf.Deserialize(fs) as List<Thing>;
            fs.Close();
            return things;
        }
    }
}
