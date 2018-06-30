using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    class Fish
    {
        private Rectangle size;
        private int x = -4;
        private int y;

        public Fish(int y)
        {
            this.y = y;
            size = new Rectangle(x, y, 8, 4);
        }
        private void updateSize()
        {
            size = new Rectangle(x, y, 8, 4);
        }
        //GETTERS
        public int getX() { return x; }
        public Rectangle getHitbox() { return size; }
        //SETTER
        public void setX(int x) { this.x = x; }
        public Graphics drawFish(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.OrangeRed), size);
            updateSize();
            return g;
        }
    }
}
