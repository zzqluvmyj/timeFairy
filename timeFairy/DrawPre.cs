using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace timeFairy
{
    //FileMethod.SaveThings("..//..//storage//things.dat", t);

    //var sectorParts = new List<SectorPart>();
    //sectorParts.Add(new SectorPart(90, Brushes.Red));
    //sectorParts.Add(new SectorPart(30, Brushes.Green));
    //sectorParts.Add(new SectorPart(120, Brushes.GreenYellow));
    //sectorParts.Add(new SectorPart(70, Brushes.HotPink));
    //sectorParts.Add(new SectorPart(50, Brushes.Yellow));
    //var ringParts = new List<RingPart>();
    //ringParts.Add(new RingPart(0, 0, 0, 0, Brushes.White));
    //Point p = new Point(240, 180);
    //var shapes = PieChartDrawer.GetPieChartShapes(p, 150, 0,sectorParts, ringParts);
    class DrawPre
    {
        public static List<double> listd=new List<double>();//时间
        public static List<String> lists = new List<String>();//名称
        public static List<double> lista=new List<double>();//角度
        public static List<int> listn = new List<int>();//事件序号
        public static int l=0;//扇形的数量
        public static void ClearUp()
        {
            listd.Clear();
            lists.Clear();
            lista.Clear();
            listn.Clear();
            l = 0;
        }
        public static List<SolidColorBrush> color = new List<SolidColorBrush>
            {
                Brushes.Red,
                Brushes.Blue,
                Brushes.Cornsilk,
                Brushes.Firebrick,
                Brushes.MediumSeaGreen,
                Brushes.PaleGoldenrod,
                Brushes.OrangeRed,
                Brushes.Silver,
                Brushes.SpringGreen,
                Brushes.Tomato,
                Brushes.White,
                Brushes.Yellow
            };

        public static void getList(ObservableCollection<Note> notes)
        {
            double max = 0;
            int index1;
            int index2;
            //在记录中找重复的，重复的条件是名称和事件序号相同
            foreach (Note item in notes)
            {
                max += item.M;
                index1 = lists.IndexOf(item.Name);
                if (index1 > -1)
                {
                    index2 = listn.IndexOf(item.Thingid);
                    if (index2 > -1)
                    {
                        if (index1 == index2)
                        {
                            listd[index1] += item.M;
                        }
                    }
                }
                else
                {
                    listd.Add(item.M);
                    lists.Add(item.Name);
                    listn.Add(item.Thingid);
                    l += 1;
                }
            }
            for (int i = 0; i < l; i++)
            {
                lista.Add(listd[i] / max * 360);
            }

        }
        public static IEnumerable<Shape> GetShapes()
        {
            var sectorParts = new List<SectorPart>();
            for (int i = 0; i < l; i++)
            {
                sectorParts.Add(new SectorPart(listd[i], color[i]));
            }
            var ringParts = new List<RingPart>();
            ringParts.Add(new RingPart(0, 0, 0, 0, Brushes.White));
            Point p = new Point(240, 180);
            var shapes = PieChartDrawer.GetPieChartShapes(p, 150, 0, sectorParts, ringParts);
            return shapes;
        }
        public static IEnumerable<Label> getLabel()
        {
            var labels = new List<Label>();
            for (int i = 0; i < l; i++)
            {
                labels.Add(new Label {Content=lists[i],Background=color[i]});
            }
            return labels;
        }
    }
}
