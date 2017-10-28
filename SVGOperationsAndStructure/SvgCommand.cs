﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGOperationsAndStructure
{
    public enum PointType
    {
        M, m, L, l, A, a, Q, q
    }
    public struct SvgCommand
    {
        public NumberFormatInfo nfi;
        public PointType type;
        public double x;
        public double y;
        public double xAxisRotation;
        public double largeArc;
        public double sweep;
        public double rx;
        public double ry;
        public double x1;
        public double y1;

        public override string ToString()
        {
            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            switch (this.type)
            {
                case PointType.M:
                    return String.Format("M {0} {1}", this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.m:
                    return String.Format("m {0} {1}", this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.L:
                    return String.Format("L {0} {1}", this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.l:
                    return String.Format("l {0} {1}", this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.Q:
                    return String.Format("Q {0} {1} {2} {3}", this.x1.ToString(nfi), this.y1.ToString(nfi), this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.q:
                    return String.Format("q {0} {1} {2} {3}", this.x1.ToString(nfi), this.y1.ToString(nfi), this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.A:
                    return String.Format("A {0} {1} {2} {3} {4} {5} {6}", this.rx.ToString(nfi), this.ry.ToString(nfi), this.xAxisRotation.ToString(nfi), this.largeArc.ToString(nfi), this.sweep.ToString(nfi), this.x.ToString(nfi), this.y.ToString(nfi));

                case PointType.a:
                    return String.Format("a {0} {1} {2} {3} {4} {5} {6}", this.rx.ToString(nfi), this.ry.ToString(nfi), this.xAxisRotation.ToString(nfi), this.largeArc.ToString(nfi), this.sweep.ToString(nfi), this.x.ToString(nfi), this.y.ToString(nfi));

                default:
                    // throw exception
                    return "";
            }
        }
    }
}
