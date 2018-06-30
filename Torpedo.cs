using SubmarineSimulator.Properties;
using System;
using System.Drawing;

namespace SubmarineSimulator
{
    internal class Torpedo
    {
        private Rectangle size;
        private int x;
        private int y;
        private Image torpedo = Resources.Torpedo;

        public Torpedo(int x, int y)
        {
            this.x = x+75;
            this.y = y;
            size = new Rectangle(x+75, y, 5, 10);
        }
        private void updateSize()
        {
            size = new Rectangle(x, y, 5, 10);
        }
        //GETTERS
        public int getY() { return y; }
        public int getX() { return x; }
        public Rectangle getHitbox() { return size; }
        //SETTER
        public void setY(int y) { this.y = y; }
        //GRAPHICS
        public Graphics drawTorpedo(Graphics g)
        {
            g.DrawImage(torpedo, new Point(x, y));
            updateSize();
            return g;
        }
    }
}