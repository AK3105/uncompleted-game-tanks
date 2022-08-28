using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tanksgame
{
    class Tank
    {
        private float x;
        private float y;
        float dy;
        float dx;
        private float velocity = 10;
        private int rotating; //0 - up; 1 - right; 2 - down; 3 - left
        float brickX = 700;
        float brickY = 150;
        private float w = 45;
        private float h = 45;
        private float r = 23;
       // private float angle = 180;
        private float muzzleW = 10;
        private float muzzleH = 50;

        public Boolean isHit = false;
        public Boolean isDead = false;
        private bool brickHit= false;
        private bool brickHit2 = false;

        public Tank(float x, float y, int rotating)
        {
            this.x = x;
            this.y = y;
            this.rotating = rotating;
        }

        public void setIsHit(Boolean isHit)
        {
            this.isHit = isHit;
        }

        public void setHit(Boolean brickHit)
        {
            this.brickHit =brickHit;
        }
        public void setHit2(Boolean brickHit2)
        {
            this.brickHit2 = brickHit2;
        }

        public float GetX() {
            return x;
        }

        public float GetY()
        {
            return y;
        }
        public float GetR()
        {
            return r;
        }

        public float GetDx()
        {
            switch (rotating)
            {
                case 0: return 0;
                case 1: return 4 * velocity;
                case 2: return 0;
                case 3: return -4 * velocity;
            }
            return 0f;
        }

        public float GetDy()
        {
            switch (rotating)
            {
                case 0: return -4 * velocity;
                case 1: return 0;
                case 2: return 4 * velocity;
                case 3: return 0;
            }
            return 0f;
        }

        public void Draw(Graphics g)
        {
            g.TranslateTransform(x, y);
            g.RotateTransform(velocity);
            g.FillRectangle(Brushes.Black, 0 - w / 2f, 0 - h / 2f, w, h);
            g.FillRectangle(Brushes.Black, 0 - muzzleW / 2f, 0 - muzzleH, muzzleW, muzzleH);
            g.RotateTransform(-velocity);
            g.TranslateTransform(-x, -y);
            
            if (isHit)
            {
                g.FillRectangle(Brushes.Red, 0 - w / 2f, 0 - h / 2f, w, h);
                g.FillRectangle(Brushes.Red, 0 - muzzleW / 2f, 0 - muzzleH, muzzleW, muzzleH);
            }
           

            g.FillRectangle(Brushes.Black, x - w / 2f, y - h / 2f, w, h);
            switch (rotating)
            {
                case 0: g.FillRectangle(Brushes.Black, x - muzzleW / 2f, y - muzzleH, muzzleW, muzzleH);
                    break;
                case 1: g.FillRectangle(Brushes.Black, x, y - muzzleW / 2f, muzzleH, muzzleW);
                    break;
                case 2: g.FillRectangle(Brushes.Black, x - muzzleW / 2f, y, muzzleW, muzzleH);
                    break;
                case 3: g.FillRectangle(Brushes.Black, x - muzzleH, y - muzzleW / 2f, muzzleH, muzzleW);
                    break;
            }
             
        }

        public void move(float formWidth, float formHeight, Tank rivalTank)
        {
            if (isHit)
            {
                velocity = 0;
            }


            float newX = x;
            float newY = y;
            switch (velocity)
            {
                case 0: newY -= velocity;//движение вверх
                    if (newY <= muzzleH)
                    {
                        newY = muzzleH +6; //из-за таймера лучше не ставить больше 7 "границу"
                    }
                    break;
                case 1: newX += velocity;//это движение вправо
                    if (newX >= formWidth - muzzleH)
                    {
                        newX = formWidth - muzzleH - 6;
                    }
                    break;
                
                case 2: newX -= velocity;//влево 
                    if (newX < muzzleH)
                    {
                        newX = muzzleH+6;
                    }
                    break;
                case 3: newY += velocity;//вниз
                    if (newY >= formHeight - muzzleH)
                    {
                        newY = formHeight - muzzleH - 6;
                    }
                    break;

            }

            if ((rivalTank.x - newX) * (rivalTank.x - newX) + (rivalTank.y - newY) * (rivalTank.y - newY) > w * w)
            {
                x = newX;
                y = newY;
            }
            if (brickHit)
            {
                rotating -= 1;
            }
            if (brickHit2)
            {
                rotating -= 1;
            }




        }

        public void rotate(int kudaPovernut)
        {
           // angle += kudaPovernut;
            this.rotating += kudaPovernut;
            if (this.rotating < 0)
            {
                this.rotating += 4;
            }
            else if (this.rotating > 3)
            {
                this.rotating -= 4;
            }
        }
      
       public void Intersection()
        {
           
            Rectangle rec = new Rectangle((int)brickX,(int) brickY, 70,700);
            
            rec.Inflate(41, 41);
            if (rec.Contains(new Point((int)x,(int) y)))
            {
                brickHit = true;
            }
        }
        public void Intersection2()
        {

            Rectangle rec = new Rectangle((int)brickX-70, (int)brickY-150, 70, 700);
            
            rec.Inflate(41, 41);
            if (rec.Contains(new Point((int)x, (int)y)))
            {
                brickHit2 = true;
            }
        }
        public void move2()
        {
            x += 1;
            y += 1;
        }
    }

}
