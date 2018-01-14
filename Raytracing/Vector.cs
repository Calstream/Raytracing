using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
    public class Vector
    {

        public double x;
        public double y;
        public double z;

        static Vector() { }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // copy constructor
        public Vector(Vector v) : this(v.x, v.y, v.z) { }

        public Vector normalize()
        {
            double l = (double)this.magnitude();
            return new Vector(x / l, y / l, z / l);
        }

        static public Vector operator +(Vector v, Vector w)
        {
            return new Vector(w.x + v.x, w.y + v.y, w.z + v.z);
        }

        static public Vector operator -(Vector v, Vector w)
        {
            return new Vector(v.x - w.x, v.y - w.y, v.z - w.z);
        }

        static public Vector operator *(Vector v, Vector w)
        {
            return new Vector(v.x * w.x, v.y * w.y, v.z * w.z);
        }

        static public Vector operator *(Vector v, double f)
        {
            return new Vector(v.x * f, v.y * f, v.z * f);
        }

        static public Vector operator /(Vector v, double f)
        {
            return new Vector(v.x / f, v.y / f, v.z / f);
        }

        public double dot(Vector w)
        {
            return this.x * w.x + this.y * w.y + this.z * w.z;
        }

        public Vector cross(Vector w)
        {
            return new Vector(-z * w.y + y * w.z,
                               z * w.x - x * w.z,
                              -y * w.x + x * w.y);
        }

        public double magnitude()
        {
            return Math.Sqrt((double)((x * x) + (y * y) + (z * z)));
        }

    }
}
