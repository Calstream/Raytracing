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
            res.Distance = double.MaxValue;
            foreach (IObject o in objects)
            {
                IntersectionInfo i = o.Intersect(ray);
                if (i.IsHit && i.Distance < res.Distance && i.Distance > 0)
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
            //Scene res = new Scene();
            eye_pos = new Vector(0, 0, -15);
            eye_dir = new Vector(-0.2,0,5);
            backColor = new Color_dbl(0.5, 0.5, 0.5);
            ambience = 0.4;

            lights.Add(new Light(new Vector(5, 10, -1), new Color_dbl(0.8, 0.0, 0.0)));
            lights.Add(new Light(new Vector(-3, 5, -10), new Color_dbl(0.8, 0.8, 0.8)));
            //lights.Add(new Light(new Vector(0, 2, 0), new Color_dbl(0.8, 0.8, 0.8)));

            //Vector t = new Vector(-0.5,0.5,2);

            Vector t = new Vector(-0.5, 0.5, -2);
            Material m = new Material(new Color_dbl(1.0,0.85,0.85));
            m.Reflection = 0.2;
            Sphere s = new Sphere(t,1.2,m);

            objects.Add(s);

            Vector t1 = new Vector(-2, 2, -4);
            Material m1 = new Material(new Color_dbl(0.1, 0.2, 0.2));
            m1.Reflection = 0.7;
            Sphere s1 = new Sphere(t1, 0.5, m1);

            objects.Add(s1);

            //Vector t1 = new Vector(0, 0, 0);
            //Material m1 = new Material(new Color_dbl(0.1, 0.1, 0.1));
            //Sphere s1 = new Sphere(t1, 1, m1);
            //s1.Material.Transparency = 0.0;
            //objects.Add(s1);

            Plane p = new Plane(new Vector(-0.1, 0.9, -0.5).normalize(), 0, new Material(new Color_dbl(0.4, 1.0, 1.0)));
            p.Material.Reflection = 0.5;
            objects.Add(p);

            //Plane p = new Plane(new Vector(0.0, 1, -0.5).normalize(), 4, new Material(new Color_dbl(1.0, 1.0, 0.4)));
            ////Plane p = new Plane(new Vector(0.0, 0, -1).normalize(), 4, new Material(new Color_dbl(1.0, 1.0, 0.4)));
            //objects.Add(p);

            //Plane p1 = new Plane(new Vector(0.0, 0.9, 0.5).normalize(), -3.5, new Material(new Color_dbl(0.8, 0.8, 1.0)));
            ////Plane p1 = new Plane(new Vector(0.0, 1, 0).normalize(), -3.5, new Material(new Color_dbl(0.8, 0.8, 1.0)));
            //objects.Add(p1);

            //Plane p2 = new Plane(new Vector(-1, 0, 0).normalize(), 2, new Material(new Color_dbl(0.8, 1.0, 1.0)));
            ////p2.Material.Transparency = 0.5;
            //objects.Add(p2);

            //return res;
        }
    }
}
