using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanksgame
{
    class Map
    {
        public float x;
        public float y;
        public float h = 700;
        public float w = 70;
        public float r = 35;
        public Rectangle rectangle1;

        public Map(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void Draw2(PaintEventArgs e)
        {
            int m = (int)Math.Ceiling(x);// преобразовали float to int число с плавающей точкой в число целое
            int n = (int)Math.Ceiling(y);
            int sh = (int)Math.Ceiling(w);
            int v = (int)Math.Ceiling(h);


            Rectangle rectangle1 = new Rectangle(m + 700, n + 150, sh - 0, v +0);
            Rectangle rectangle2 = new Rectangle(m + 630, n, sh - 0, v + 0);

            e.Graphics.DrawRectangle(Pens.Black, rectangle2);

            e.Graphics.DrawRectangle(Pens.Black, rectangle1);
           
        }
        public void Draw1(Graphics g)
        {
            g.FillRectangle(Brushes.Brown, x + 700, y + 150, w - 0, h + 0);//1
            g.FillRectangle(Brushes.Green, x + 630, y, w - 0, h + 0);//2



        }
       

       
    }
}


