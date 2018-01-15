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
            info.hit_object = this;

            Vector dst = ray.Position - this.Position;
            double b = dst.dot(ray.Direction);
            double c = dst.dot(dst) - (radius * radius);
            double d = b * b - c;

            if (d > 0) // hit
            {
                info.IsHit = true;
                info.Distance = -b - (double)Math.Sqrt(d);
                info.Position = ray.Position + ray.Direction * info.Distance;
                info.Color = this.Material.color;
                info.Normal = (info.Position - Position).normalize();
            }
            else
                info.IsHit = false;
            return info;
        }
    }
}
