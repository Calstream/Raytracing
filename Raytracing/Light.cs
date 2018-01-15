using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class Light
    {
        public Vector Position;
        public Color_dbl Color;
        public double strength;

        public Light(Vector pos, Color_dbl color)
        {
            Position = pos;
            Color = color;

            strength = 10;
        }

        public double Strength(double distance)
        {
            if (distance >= strength) return 0;

            return Math.Pow((strength - distance) / strength, .2);
        }
    }
}
