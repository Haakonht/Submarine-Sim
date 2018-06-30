using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    class PowerUp
    {
        private Rectangle size;
        private int x;
        private int y;

        public PowerUp(int y)
        {
            this.y = y;
            this.x = -10;
            size = new Rectangle(x, y, 15, 15);
        }

        private void updateSize()
        {
            size = new Rectangle(x, y, 15, 15);
        }
        public Rectangle getHitbox() { return size; }
        public int getX() { return x; }
        public void setX(int x) { this.x = x; }
        public Graphics drawPowerUp(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Purple), size);
            g.DrawString("+", new Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular), new SolidBrush(Color.Black), new Point(x, y));
            updateSize();
            return g;
        }

    }
}
