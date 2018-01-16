using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Raytracing
{
    public class Scene
    {
        public Color_dbl backColor;
        public double ambience;
        public List<IObject> objects;
        public List<Light> lights;
        public Vector eye_pos;
        public Vector eye_dir;

        public IntersectionInfo IntersectRay(Ray ray)
        {
            int hitCount = 0;
            IntersectionInfo res = new IntersectionInfo();
            res.dist = double.MaxValue;
            foreach (IObject o in objects)
            {
                IntersectionInfo i = o.Intersect(ray);
                if (i.is_hit && i.dist < res.dist && i.dist > 0)
                {
                    res = i;
                    hitCount++;
                }
            }
            return res;
        }

        public Scene()
        {
            objects = new List<IObject>();
            lights = new List<Light>();
        }
        public void SetTest()
        {
            //eye_pos = new Vector(0, 0, -15);
            //eye_dir = new Vector(-0.2,0,5);

            eye_pos = new Vector(0, 0, -15);
            eye_dir = new Vector(-0.2, 0, 5);

            backColor = new Color_dbl(0.5, 0.5, 0.5);
            ambience = 0.4;

            lights.Add(new Light(new Vector(5, 10, -1), new Color_dbl(0.8, 0.0, 0.0)));
            lights.Add(new Light(new Vector(-3, 5, -10), new Color_dbl(0.8, 0.8, 0.8)));

            Vector t = new Vector(-0.5, 0.5, -2);
            Material m = new Material(new Color_dbl(1.0,0.85,0.85));   // black mirror
            m.Reflection = 0.2;
            Sphere s = new Sphere(t,1.2,m);
            objects.Add(s);

            Vector t1 = new Vector(-2, 2, -4);
            Material m1 = new Material(new Color_dbl(0.1, 0.2, 0.2)); // pink glossy
            m1.Reflection = 0.7;
            Sphere s1 = new Sphere(t1, 0.5, m1);
            objects.Add(s1);

            Vector t2 = new Vector(2, 0, -2);
            Material m2 = new Material(new Color_dbl(0.8, 0.9, 0.8));   // black glossy
            m2.Reflection = 0.1;
            Sphere s2 = new Sphere(t2, 0.7, m2);
            objects.Add(s2);

            Plane p = new Plane(new Vector(-0.1, 0.9, -0.5).normalize(), 0, new Material(new Color_dbl(0.4, 1.0, 1.0)));
            p.Material.Reflection = 0.5;
            objects.Add(p);
        }
    }
}
