using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGOperationsAndStructure
{
    public static class PathMatrixOperation
    {
        public static void RotatePathToDegrees(ref SvgElement svg, double degrees, SvgCommand center)
        {
            for (var i = 0; i < svg.Path.Count; i++)
            {
               // Console.WriteLine("start" + svg.Path[i].x + ", " + svg.Path[i].y);

                svg.Path[i] = NormalizePoint(svg.Path[i], center);

                //Console.WriteLine("norm : " + svg.Path[i].x + ", " + svg.Path[i].y);

                svg.Path[i] = RotatePointToDegrees(svg.Path[i], degrees, center);

                //Console.WriteLine("rotate : " + svg.Path[i].x + ", " + svg.Path[i].y);

                svg.Path[i] = DenormalizePoint(svg.Path[i], center);

                //Console.WriteLine("denorm : " + svg.Path[i].x + ", " + svg.Path[i].y);
            }
        }

        private static double CalculateAngleBetween(SvgCommand point, SvgCommand center)
        {
            throw new NotImplementedException();
        }

        private static SvgCommand NormalizePoint(SvgCommand point, SvgCommand center)
        {
            point.x  = point.x  - center.x;
            point.y  = point.y  - center.y;
            point.x1 = point.x1 - center.x;
            point.y1 = point.y1 - center.y;
            point.rx = point.rx - center.x;
            point.ry = point.ry - center.y;

            return point;
        }

        private static SvgCommand DenormalizePoint(SvgCommand point, SvgCommand center)
        {
            point.x  = point.x  + center.x;
            point.y  = point.y  + center.y;
            point.x1 = point.x1 + center.x;
            point.y1 = point.y1 + center.y;
            point.rx = point.rx + center.x;
            point.ry = point.ry + center.y;

            return point;
        }

        private static SvgCommand RotatePointToDegrees(SvgCommand point, double degrees, SvgCommand center)
        {
            degrees = degrees * Math.PI / 180;
            double oldVal;

            oldVal = point.x;
            point.x  = Math.Round(point.x * Math.Cos(degrees), 2)  - Math.Round(point.y * Math.Sin(degrees), 2);
            point.y  = Math.Round(oldVal * Math.Sin(degrees), 2)  + Math.Round(point.y * Math.Cos(degrees), 2);

            //Console.WriteLine(point);

            point.x1 = point.x1 * Math.Cos(degrees) - point.y1 * Math.Sin(degrees + 180);
            point.y1 = point.x1 * Math.Sin(degrees) + point.y1 * Math.Cos(degrees + 180);
            point.rx = point.rx * Math.Cos(degrees) - point.ry * Math.Sin(degrees + 180);
            point.ry = point.rx * Math.Sin(degrees) + point.ry * Math.Cos(degrees + 180);

            

            return point;
        }

        private static SvgCommand ScalePoint(SvgCommand point, double amount)
        {
            point.x  *= amount;
            point.y  *= amount;
            point.rx *= amount;
            point.ry *= amount;
            point.x1 *= amount;
            point.y1 *= amount;

            return point;
        }
        // ref problem => scale not visible to outside
        public static void ScalePath(ref SvgElement svg, double amount)
        {
            for (var i = 0; i < svg.Path.Count; i++)
            {
                svg.Path[i] = ScalePoint(svg.Path[i], amount);
            }
        }

        private static SvgCommand TranslatePoint(SvgCommand point, double deltaX, double deltaY)
        {
            point.x  += deltaX;
            point.y  += deltaY;
            point.rx += deltaX;
            point.ry += deltaY;
            point.x1 += deltaX;
            point.y1 += deltaY;

            return point;
        }

        public static void TranslatePath(ref SvgElement svg, double deltaX, double deltaY)
        {
            for (var i = 0; i < svg.Path.Count; i++)
            {
                svg.Path[i] = TranslatePoint(svg.Path[i], deltaX, deltaY);
            }
        }
    }
}
