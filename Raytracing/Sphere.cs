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
            IntersectionInfo info = new IntersectionInfo();
            info.element = this;

            Vector dst = ray.Position - this.Position;
            double B = dst.dot(ray.Direction);
            double C = dst.dot(dst) - (radius * radius);
            double D = B * B - C;

            if (D > 0) // hit
            {
                info.IsHit = true;
                info.Distance = -B - (double)Math.Sqrt(D);
                info.Position = ray.Position + ray.Direction * info.Distance;
                //info.Normal = (info.Position - Position).Normalize();

                // skip uv calculation, just get the color
                info.Color = this.Material.color;

            }
            else
                info.IsHit = false;
            return info;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
