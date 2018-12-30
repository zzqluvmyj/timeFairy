﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// 饼图的绘制类
    /// </summary>
    public static class PieChartDrawer
    {
        public static Point GetCirclePoint(this Point center, double radius, double angle)
        {
            // 圆心平移到原点后0度所对应的向量
            var zeroAngleVector = new Vector(0, radius);

            // 旋转角度所对应的矩阵
            var rotateMatrix = new Matrix();
            rotateMatrix.Rotate(180 + angle);

            // 因旋转的中心点在原点,最后需要平移到实际坐标上
            return (zeroAngleVector * rotateMatrix) + center;
        }
        public static Point GetEllipsePoint(this Point center, double radiusX, double radiusY, double angle)
        {
            // 半径为X半轴的圆圆心平移到原点后0度所对应的向量
            var circleZeroAnglePoint = new Vector(0, radiusX);

            // 旋转角度所对应的矩阵
            var rotateMatrix = new Matrix();
            rotateMatrix.Rotate(180 + angle);

            // 圆旋转角度后的坐标
            var circlePoint = circleZeroAnglePoint * rotateMatrix;

            // 将圆拉伸椭圆后的坐标
            var ellpseOrigin = new Point(circlePoint.X, circlePoint.Y * radiusY / radiusX);

            // 将坐标平移至实际坐标
            return (Vector)ellpseOrigin + center;
        }
        /// <summary>
        /// 获取饼图的形状列表
        /// </summary>
        /// <param name="center">圆心</param>
        /// <param name="radius">圆的半径</param>
        /// <param name="offsetAngle">偏移角度,即第一个扇形开始的角度</param>
        /// <param name="sectorParts">扇形列表,扇形列表的SpanAngle之和应为360度</param>
        /// <param name="ringParts">环列表</param>
        /// <returns>构成饼图的形状列表</returns>
        public static IEnumerable<Shape> GetPieChartShapes(Point center, double radius, double offsetAngle, IEnumerable<SectorPart> sectorParts, IEnumerable<RingPart> ringParts)
        {
            return GetEllipsePieChartShapes(center, radius, radius, offsetAngle, sectorParts, ringParts);
        }

        /// <summary>
        /// 获取椭圆形状的饼图的形状列表
        /// </summary>
        /// <param name="center">椭圆两个焦点的中点</param>
        /// <param name="radiusX">椭圆的长轴</param>
        /// <param name="radiusY">椭圆的短轴</param>
        /// <param name="offsetAngle">偏移角度,即第一个扇形开始的角度</param>
        /// <param name="sectorParts">扇形列表,扇形列表的SpanAngle之和应为360度</param>
        /// <param name="ringParts">环列表</param>
        /// <returns>构成饼图的形状列表</returns>
        public static IEnumerable<Shape> GetEllipsePieChartShapes(Point center, double radiusX, double radiusY, double offsetAngle, IEnumerable<SectorPart> sectorParts, IEnumerable<RingPart> ringParts)
        {
            var shapes = new List<Shape>();
            double startAngle = offsetAngle;

            foreach (var sectorPart in sectorParts)
            {
                // 扇形顺时针方向在椭圆上的第一个点
                var firstPoint = center.GetEllipsePoint(radiusX, radiusY, startAngle);

                startAngle += sectorPart.SpanAngle;

                // 扇形顺时针方向在椭圆上的第二个点
                var secondPoint = center.GetEllipsePoint(radiusX, radiusY, startAngle);

                var sectorFigure = new PathFigure { StartPoint = center };

                // 添加中点到第一个点的弦
                sectorFigure.Segments.Add(new LineSegment(firstPoint, false));

                // 添加第一个点和第二个点之间的弧
                sectorFigure.Segments.Add(
                    new ArcSegment(secondPoint, new Size(radiusX, radiusY), 0, false, SweepDirection.Clockwise, false));
                var sectorGeometry = new PathGeometry();
                sectorGeometry.Figures.Add(sectorFigure);

                var sectorPath = new Path { Data = sectorGeometry, Fill = sectorPart.FillBrush };

                shapes.Add(sectorPath);
            }

            var ringShapes = GetRingShapes(center, ringParts);
            shapes.AddRange(ringShapes);

            return shapes;
        }

        /// <summary>
        /// 获取环的形状列表
        /// </summary>
        /// <param name="center">中心点，为圆表示圆形，为椭圆表示椭圆两个焦点的中点</param>
        /// <param name="ringParts">环列表</param>
        /// <returns>环的形状列表</returns>
        private static IEnumerable<Shape> GetRingShapes(Point center, IEnumerable<RingPart> ringParts)
        {
            var shapes = new List<Shape>();

            foreach (var ringPart in ringParts)
            {
                var innerEllipse = new EllipseGeometry(center, ringPart.RadiusX, ringPart.RadiusY);
                var outterEllipse = new EllipseGeometry(center, ringPart.RadiusX + ringPart.SpanRadiusX, ringPart.RadiusY + ringPart.SpanRadiusY);

                // 根据里外椭圆求出圆环的形状
                var ringGeometry = new CombinedGeometry(GeometryCombineMode.Xor, innerEllipse, outterEllipse);
                var ringPath = new Path
                {
                    Data = ringGeometry,
                    Fill = ringPart.FillBrush
                };

                shapes.Add(ringPath);
            }

            return shapes;
        }
    }
}
