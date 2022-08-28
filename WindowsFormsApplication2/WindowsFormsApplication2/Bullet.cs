using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanksgame
{
    class Bullet
    {
        private float x;
        private float y;
        private float dx;
        private float dy;
        private float r = 5;
        private Tank myTank;

        public Bullet(Tank myTank, float x, float y, float dx, float dy)
        {
            this.myTank = myTank;
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
        }
        
        public void move()
        {
            x += dx;
            y += dy;
        }
        
        public Boolean IsTankHit(Tank tank)
        {
            if (tank == myTank)
            {
                return false;
            }

            if ((tank.GetX() - x) * (tank.GetX() - x) + (tank.GetY() - y) * (tank.GetY() -y ) <= (tank.GetR()+r)*(tank.GetR()+r) )
            {
              return true;
            }
            else
            {
              return false;
            }
        }
        

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.GreenYellow, x - r, y - r, r*2, r*2);
        }
    }
}
