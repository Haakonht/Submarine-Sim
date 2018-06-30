using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using SubmarineSimulator.Properties;

namespace SubmarineSimulator
{
    class LargeBoat : Boats
    {
        private Rectangle size;
        private int score = 80;
        private int x = -150;
        private int y = 0;
        private String type = "Large";
        private Image boat = Resources.LargeBoat;

        public LargeBoat(int y)
        {
            this.y = y;
            size = new Rectangle(x, y, 170, 45);
        }
        private void updateSize()
        {
            size = new Rectangle(x, y, 170, 45);
        }
        //GETTERS
        public override Rectangle getHitbox() { return size; }
        public override int getX() { return x; }
        public override int getY() { return y; }
        public override int getScore() { return score; }
        public override String getType() { return type; }
        //SETTER
        public override void setX(int x) { this.x = x; }
        //GRAPHICS
        public override Graphics drawBoat(Graphics g)
        {
            g.DrawImage(boat, new Point(x, y));
            updateSize();
            return g;
        }
    }
}
