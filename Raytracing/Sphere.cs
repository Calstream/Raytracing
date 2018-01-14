using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    class Sphere : BaseObject
    {
        public double radius;
        public Sphere(Vector pos, double r, Material material)
        {
            radius = r;
            Position = pos;
            Material = material;
        }


        public override Color Intersect(Ray ray)
        {
            return Color.AliceBlue;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
