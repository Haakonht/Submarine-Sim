using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    abstract class Boats
    {
        //GETTERS
        public abstract int getX();
        public abstract int getY();
        public abstract Rectangle getHitbox();
        public abstract int getScore();
        public abstract String getType();
        //SETTERS
        public abstract void setX(int x);
        //GRAPHICS
        public abstract Graphics drawBoat(Graphics g); 
    }
}
