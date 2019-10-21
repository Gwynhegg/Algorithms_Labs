using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class GraphPanel : Form
    {
        Graphics g;
        public GraphPanel()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
        }

        public void putDot(int x,int y)
        {
            g.FillEllipse(new SolidBrush(Color.Black), x*10, this.Height / 2 - y * 10, 3, 3);
        }

        public void putLine(int x1,int y1,int x2,int y2)
        {
            g.DrawLine(new Pen(Color.Red), x1*10, this.Height / 2 - y1*10, x2*10, this.Height / 2 - y2*10);
        }
        public void createGraph()
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
        }
    }
}
