using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using SubmarineSimulator.Properties;

namespace SubmarineSimulator
{
    class Submarine
    {
        private Rectangle size;
        private int x;
        private int y;
        private Image sub = Resources.Submarine;

        public Submarine(int x, int y)
        {
            this.x = x;
            this.y = y;
            size = new Rectangle(x, y, 75, 34);
        }
        private void updateLocation()
        {
            size = new Rectangle(x, y, 75, 34);
        }
        //GETTERS
        public int getX() { return x; }
        public int getY() { return y; }
        public Rectangle getHitbox() { return size; }
        //SETTERS
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }
        //GRAPHICS
        public Graphics drawSub(Graphics g)
        {
            g.DrawImage(sub, new Point(x, y));
            updateLocation();
            return g;
        }

    }
}
