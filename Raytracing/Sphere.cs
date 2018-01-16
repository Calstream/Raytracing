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
                info.is_hit = true;
                info.dist = -b - (double)Math.Sqrt(d);
                info.pos = ray.Position + ray.Direction * info.dist;
                info.Color = this.Material.color;
                info.normal = (info.pos - Position).normalize();
            }
            else
                info.is_hit = false;
            return info;
        }
    }
}
