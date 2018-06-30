using SubmarineSimulator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    class SmallBoat : Boats
    {
        private Rectangle size;
        private int score = 30;
        private int x = -70;
        private int y = 0;
        private String type = "Small";
        private Image boat = Resources.SmallBoat;

        public SmallBoat(int y)
        {
            this.y = y;
            size = new Rectangle(x, y, 90, 30);
        }
        private void updateSize()
        {
            size = new Rectangle(x, y, 90, 30);
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
