using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanksgame
{
    public partial class GameScreen : UserControl
    {
        List<Bullet> bullets = new List<Bullet>();
        Tank tank;
        Random random = new Random();
        Tank tank2;
        Map map = new Map(0,0);
        Tank tank3;
        Tank tank4;
        Tank tank5;
        Tank tank6;

        public GameScreen()
        {
            tank = new Tank(random.Next(1200,1300 ), random.Next(690, 800), random.Next(2,3));
            tank2 = new Tank(random.Next(30,100), random.Next(30,100), random.Next(1));
            tank3 = new Tank(random.Next(1200, 1300), random.Next(00, 800), random.Next(4));
            tank4 = new Tank(random.Next(10, 100), random.Next(00, 800), random.Next(4));
            tank5 = new Tank(2000, 2500, 0);
            tank6 = new Tank(2000, 2500, 0);

            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {


        }
       

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            tank.Draw(e.Graphics);
            tank2.Draw(e.Graphics);
          //  tank3.Draw(e.Graphics);
            //tank4.Draw(e.Graphics);
            map.Draw1(e.Graphics);
            map.Draw2(e);


            foreach (Bullet b in bullets)
            {
                b.Draw(e.Graphics);
            }
          
        }

        public void rotateLeft(int tankNum)
        {
            switch (tankNum)
            {
                case 0: tank.rotate(-1);
                    break;
                case 1: tank2.rotate(-1);
                    break;
            }
        }

        public void rotateRight(int tankNum)
        {
            switch (tankNum)
            {
                case 0: tank.rotate(1);
                    break;
                case 1: tank2.rotate(1);
                    break;
            }
        }

        public void Fire(int tankNum)
        {
            if (tankNum == 0)
            {
                float x = tank.GetX();
                float y = tank.GetY();
                float dx = tank.GetDx();
                float dy = tank.GetDy();
                bullets.Add(new Bullet(tank, x, y, dx, dy));
            }
            else
            {
                float x = tank2.GetX();
                float y = tank2.GetY();
                float dx = tank2.GetDx();
                float dy = tank2.GetDy();
                bullets.Add(new Bullet(tank2, x, y, dx, dy));
            }
        }

        public void move(float formWidth, float formHeight)
        {
            tank.Intersection();
            tank2.Intersection2();
            tank.move(formWidth, formHeight, tank2);
            tank2.move(formWidth, formHeight, tank);
            tank3.move(formWidth, formHeight, tank4);
            tank4.move(formWidth, formHeight, tank3);
            
            foreach (Bullet b in bullets)
            {
                b.move();

                if (b.IsTankHit(tank))
                {
                    tank = tank6;
                    tank.setIsHit(true);
                }

                if (b.IsTankHit(tank2))
                {
                    tank2 = tank5;
                    tank2.setIsHit(true);
                }
            }
            
        }
    }
}
