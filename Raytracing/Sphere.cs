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


        public override IntersectionInfo Intersect(Ray ray)
        {
            IntersectionInfo inf = new IntersectionInfo();
            Vector distance = ray.Position - this.Position;
            double a1 = distance.dot(ray.Direction);
            double a2 = distance.dot(distance) - (radius * radius);

            if (a1 * a1 - a2 > 0) // intersection
            {
                inf.IsHit = true;
                inf.Color = this.Material.color;
            }
            else
            {
                inf.IsHit = false;
            }
            return inf;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
