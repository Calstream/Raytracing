using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Raytracing
{
    class Raytracer
    {
        void Render(PictureBox p)
        {
            Bitmap b = p.Image as Bitmap;
            for (int x = 0; x < p.Width; ++x)
                for (int y = 0; y < p.Height; ++y)
                {
                    b.SetPixel(x, y, getColor(x, y));
                }
            p.Refresh();
        }

        Color getColor(int x, int y)
        {
            return Color.AliceBlue;
        }

        public void RayTraceScene(Graphics g, Bitmap viewport, Scene scene)
        {
            for (int y = 0; y < viewport.Height; y++)
                for (int x = 0; x < viewport.Width; x++)
                {
                    double yp = y * 1.0f / viewport.Height * 2 - 1;
                    double xp = x * 1.0f / viewport.Width * 2 - 1;

                    Vector ray_pos = scene.eye_pos + scene.eye_dir - new Vector(0, yp, 0) - scene.eye_dir.normalize().cross(new Vector(0,1,0)) * xp;
                    Vector ray_dir = (ray_pos - scene.eye_pos).normalize();

                    Ray ray = new Ray(ray_pos,ray_dir);
                    Color c = CalculateColor(ray, scene);
                    viewport.SetPixel(x, y, c);
                }
        }

        public Color CalculateColor(Ray ray, Scene scene)
        {
            IntersectionInfo info = TestIntersection(ray, scene);
            if (info.IsHit)
            {
                // execute the actual raytrace algorithm
                Color c = RayTrace(info, ray, scene, 0);
                return c;
            }

            return scene.backColor;
        }


        private Color RayTrace(IntersectionInfo info, Ray ray, Scene scene, int depth)
        {
            // calculate ambient light
            double sa = scene.ambience;
            Color color = Color.FromArgb((int)(info.Color.R * sa), (int)(info.Color.G * sa), (int)(info.Color.B * sa));
            //double shininess = Math.Pow(10, info.Element.Material.Gloss + 1);

            
            return color;
        }


        private IntersectionInfo TestIntersection(Ray ray, Scene scene)
        {
            int hitcount = 0;
            IntersectionInfo best = new IntersectionInfo();
            best.Distance = double.MaxValue;

            foreach (IObject o in scene.objects)
            {
                IntersectionInfo info = o.Intersect(ray);
                if (info.IsHit && info.Distance < best.Distance && info.Distance >= 0)
                {
                    best = info;
                    hitcount++;
                }
            }
            best.HitCount = hitcount;
            return best;
        }

    }


}
