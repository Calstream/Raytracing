using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class Color_dbl
    {
        public double R;
        public double G;
        public double B;

        public Color_dbl()
        {
            R = 0;
            G = 0;
            B = 0;
        }

        public Color_dbl(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color_dbl(Color_dbl other)
        {
            R = other.R;
            G = other.G;
            B = other.B;
        }

        static public Color_dbl operator +(Color_dbl c1, Color_dbl c2)
        {
            Color_dbl result = new Color_dbl();

            result.R = c1.R + c2.R;
            result.G = c1.G + c2.G;
            result.B = c1.B + c2.B;

            return result;
        }

        static public Color_dbl operator -(Color_dbl c1, Color_dbl c2)
        {
            Color_dbl result = new Color_dbl();

            result.R = c1.R - c2.R;
            result.G = c1.G - c2.G;
            result.B = c1.B - c2.B;

            return result;
        }

        static public Color_dbl operator *(Color_dbl c1, Color_dbl c2)
        {
            Color_dbl result = new Color_dbl();

            result.R = c1.R * c2.R;
            result.G = c1.G * c2.G;
            result.B = c1.B * c2.B;

            return result;
        }

        static public Color_dbl operator *(Color_dbl col, double f)
        {
            Color_dbl result = new Color_dbl();

            result.R = col.R * f;
            result.G = col.G * f;
            result.B = col.B * f;

            return result;
        }

        static public Color_dbl operator /(Color_dbl col, double f)
        {
            Color_dbl result = new Color_dbl();

            result.R = col.R / f;
            result.G = col.G / f;
            result.B = col.B / f;

            return result;
        }

        public void Correct()
        {
            R = (R > 0.0) ? ((R > 1.0) ? 1.0f : R) : 0.0f;
            G = (G > 0.0) ? ((G > 1.0) ? 1.0f : G) : 0.0f;
            B = (B > 0.0) ? ((B > 1.0) ? 1.0f : B) : 0.0f;
        }

        public Color ToArgb()
        {
            return Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255));
        }
    }
}
