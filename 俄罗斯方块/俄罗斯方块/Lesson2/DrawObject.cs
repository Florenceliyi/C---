using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    enum E_DrawType
    {
        Wall,
        Cube,
        Line,
        Tank,
        Left_Ladder,
        Right_Ladder,
        Left_Long_Ladder,
        Right_Long_Ladder

    }
    class DrawObject : IDraw
    {
        public Position pos;
        public E_DrawType drawType;
        public DrawObject(E_DrawType drawType)
        {
            this.drawType = drawType;
        }
        public DrawObject(E_DrawType drawType, int x, int y):this(drawType)
        {
            this.drawType = drawType;
        }
        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            switch (drawType)
            {
                case E_DrawType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case E_DrawType.Cube:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case E_DrawType.Line:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_DrawType.Tank:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case E_DrawType.Left_Ladder:
                case E_DrawType.Right_Ladder:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case E_DrawType.Left_Long_Ladder:
                case E_DrawType.Right_Long_Ladder:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    break;
            }
            Console.Write("■");
        }

        public void ChangeType(E_DrawType drawType)
        {
            this.drawType = drawType;
        }
    }
}
