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
            if (info.is_hit)
            {
                Color c = RayTrace(info, ray, scene, 0).toStandart();
                return c;
            }

            return scene.backColor.toStandart();
        }


        private Color_dbl RayTrace(IntersectionInfo info, Ray ray, Scene scene, int depth)
        {
            Color_dbl color = info.Color * scene.ambience;
            foreach (Light l in scene.lights)
            {
                Vector v = (l.Position - info.pos).normalize(); // diffuse 
                double L = v.dot(info.normal);
                if (L > 0.0f)
                    color += info.Color * l.Color * L;

                if (depth < 5)
                {
                    //shadows
                    IntersectionInfo shadow_info = new IntersectionInfo();
                    Ray toLight = new Ray(info.pos, v);
                    shadow_info = TestIntersection(toLight, scene, info.hit_object);
                    if (shadow_info.is_hit && shadow_info.hit_object != info.hit_object)
                        color *= 0.5;

                    //reflections
                    if (info.hit_object.Material.Reflection > 0)
                    {
                        Ray reflectionray = new Ray(info.pos, ray.Direction + info.normal * 2 * -info.normal.dot(ray.Direction));
                        IntersectionInfo ref_info = TestIntersection(reflectionray, scene, info.hit_object);
                        if (ref_info.is_hit && ref_info.dist > 0)
                            ref_info.Color = RayTrace(ref_info, reflectionray, scene, depth + 1);
                        else 
                            ref_info.Color = scene.backColor;
                        color = color.Blend(ref_info.Color, info.hit_object.Material.Reflection);
                    }

                }
            }
                color.Correct();
            return color;
        }


        private IntersectionInfo TestIntersection(Ray ray, Scene scene, IObject ignore)
        {
            int hitcount = 0;
            IntersectionInfo best = new IntersectionInfo();
            best.dist = double.MaxValue;

            foreach (IObject o in scene.objects)
            {
                if (o == ignore)
                    continue;
                IntersectionInfo info = o.Intersect(ray);
                if (info.is_hit && info.dist < best.dist && info.dist >= 0)
                {
                    best = info;
                    hitcount++;
                }
            }
            best.hit_count = hitcount;
            return best;
        }

    }


}
