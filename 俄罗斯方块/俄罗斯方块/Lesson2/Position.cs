using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator == (Position p1, Position p2)
        {
           return p1.x == p2.x && p1.y == p2.y ? true: false;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return p1.x == p2.x && p1.y == p2.y ? false : true;
        }

        //加法重载
        public static Position operator +(Position p1, Position p2)
        {
            Position pos = new Position(p1.x + p2.x, p1.y + p2.y);
            return pos;
        }
    }
}
