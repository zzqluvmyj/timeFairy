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
        public static List<double> listd=new List<double>();
        public static List<String> lists = new List<String>();
        public static int l=0;
        public static void ClearUp()
        {
            listd.Clear();
            lists.Clear();
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
            foreach (Note item in notes)
            {
                max += item.M;
                lists.Add(item.Name);
                l += 1;
            }
            foreach (Note item in notes)
            {
                listd.Add(item.M / max * 360);
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
