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
            IntersectionInfo info = TestIntersection(ray, scene,null);
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
            Color_dbl color = info.Color * scene.ambience;
            //double shininess = Math.Pow(10, info.Element.Material.Gloss + 1);

            foreach (Light l in scene.lights)
            {

                // calculate diffuse lighting
                Vector v = (l.Position - info.Position).normalize();

                double L = v.dot(info.Normal);
                if (L > 0.0f)
                    color += info.Color * l.Color * L;


                if (depth < 3)
                {
                    IntersectionInfo shadow = new IntersectionInfo();
                    // calculate shadow, create ray from intersection point to light
                    Ray shadowray = new Ray(info.Position, v);

                    // find any element in between intersection point and light
                    shadow = TestIntersection(shadowray, scene, info.hit_object);
                    if (shadow.IsHit && shadow.hit_object != info.hit_object)
                    {
                        // only cast shadow if the found interesection is another
                        // element than the current element
                        color *= 0.5 + 0.5 * Math.Pow(shadow.hit_object.Material.Transparency, 0.5); // Math.Pow(.5, shadow.HitCount);
                    }
                }
            }
                color.Correct();
            return color.ToArgb();
        }


        private IntersectionInfo TestIntersection(Ray ray, Scene scene, IObject ignore)
        {
            int hitcount = 0;
            IntersectionInfo best = new IntersectionInfo();
            best.Distance = double.MaxValue;

            foreach (IObject o in scene.objects)
            {
                if (o == ignore)
                    continue;
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
