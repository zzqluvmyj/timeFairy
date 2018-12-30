using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace timeFairy
{
    /// <summary>
    /// test.xaml 的交互逻辑
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            var sectorParts = new List<SectorPart>();
            sectorParts.Add(new SectorPart(90, Brushes.Red));
            sectorParts.Add(new SectorPart(30, Brushes.Green));
            sectorParts.Add(new SectorPart(120, Brushes.GreenYellow));
            sectorParts.Add(new SectorPart(70, Brushes.HotPink));
            sectorParts.Add(new SectorPart(50, Brushes.Yellow));

            var ringParts = new List<RingPart>();
            ringParts.Add(new RingPart(40, 20, 40, 20, Brushes.White));
            Point p = new Point(2, 5);
            var shapes = PieChartDrawer.GetEllipsePieChartShapes(p, 180, 90, 30, sectorParts, ringParts);
            foreach (var shape in shapes)
            {
                g.Children.Add(shape);
            }
        }
    }
}
