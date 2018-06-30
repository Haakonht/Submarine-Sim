using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    class Bomb
    {
        private Rectangle size;
        private int x;
        private int y;

        public Bomb(int x, int y)
        {
            this.x = x;
            this.y = y;
            size = new Rectangle(x, y, 5, 10);
        }
        private void updateSize()
        {
            size = new Rectangle(x, y, 5, 10);
        }
        //GETTERS
        public int getY() { return y; }
        public Rectangle getHitbox() { return size; }
        //SETTER
        public void setY(int y) { this.y = y; }
        //GRAPHICS
        public Graphics drawBomb(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), size);
            updateSize();
            return g;
        }
    }
}
