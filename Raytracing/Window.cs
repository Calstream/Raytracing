using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Raytracing
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            Raytracer raytracer = new Raytracer();

            Scene scene = new Scene();
            scene.SetTest();

            Rectangle rect = new Rectangle(0, 0, 300, 300);
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);

            Graphics g = Graphics.FromImage(bitmap);
            DateTime t = DateTime.Now;

            pictureBox1.Image = bitmap;

            raytracer.RayTraceScene(g, rect, scene);
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
