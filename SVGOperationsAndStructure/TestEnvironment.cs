using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geesus.Svg.Operation
{
    
    public class TestEnvironment
    {
        static void testrun1()
        {
            //
            var a = new SvgDocumentParser();
            SvgCommandFactory factory = new SvgCommandFactory();
            SvgCommand p1 = factory.MCmd(0, 0);
            SvgCommand p2 = factory.LCmd(70, 70);
            //SvgCommand p3 = factory.LCmd(70, 60);

            SvgElement line = new SvgElement();
            line.Path.Add(p1);
            line.Path.Add(p2);
            //line.Path.Add(p3);
            line.SetAttribute("stroke", "red");
            line.SetAttribute("fill", "transparent");

            //PathOperation.ScalePath(ref line, 0.5);
            //PathOperation.TranslatePath(ref line, 250, 250);

            SvgCommand d = new SvgCommand();
            d.x = 35;
            d.y = 35;

            PathMatrixOperation.RotatePathToDegrees(ref line, 45, d);



            SvgDocumentWriter writer = new SvgDocumentWriter();

            SvgWrapper wrapper = new SvgWrapper();
            wrapper.SetChild("one", line);

            writer.WriteToFile("MySvg.svg", wrapper);
        }

        static void Main(string[] args)
        {
            var parser = new SvgDocumentParser();
            var wrapper = parser.Parse();
            var writer = new SvgDocumentWriter();
            writer.WriteToFile("MySvg.svg", wrapper);

        }
    }
}
