using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class Plane : BaseObject
    {
        public double D;

        public Plane(Vector pos, double d, Material material)
        {
            Position = pos;
            D = d;
            Material = material;

        }

        public override IntersectionInfo Intersect(Ray ray)
        {

            IntersectionInfo info = new IntersectionInfo();
            double Vd = Position.dot(ray.Direction);
            if (Vd == 0) return info; // no intersection

            double t = -(Position.dot(ray.Position) + D) / Vd;

            if (t <= 0) return info;

            info.hit_object = this;
            info.IsHit = true;
            info.Position = ray.Position + ray.Direction * t;
            info.Distance = t;
            info.Color = Material.color;

            return info;
        }
    }
}
