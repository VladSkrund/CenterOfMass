using System.Drawing;
using System.Windows.Forms;

namespace CenterOfMass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point[] points = new Point[100];
        float[] mass = new float[100];
        int n = 0;
        float SystemMass = 0;
        float centerX = 0;
        float centerY = 0;
        float m = 0;


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            float.TryParse(textBox1.Text, out m);
            points[n].X = e.X;
            points[n].Y = e.Y;
            mass[n] = m;

            if (mass[n] < 1) mass[n] = 1;

            n++;

            SystemMass = 0;
            centerX = 0;
            centerY = 0;

            for (int i=0; i<n; i++)
            {
                SystemMass += mass[i];
                centerX += mass[i] * points[i].X;
                centerY += mass[i] * points[i].Y;
            }
            centerX /= SystemMass;
            centerY /= SystemMass;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

                foreach (Point p in points)
                {
                   if (p.X != 0 )
                   { 
                    e.Graphics.FillEllipse(Brushes.Black, p.X, p.Y, 5, 5);
                    e.Graphics.FillEllipse(Brushes.Red, centerX, centerY, 5, 5);
                   }
                }

        }
    }
}
