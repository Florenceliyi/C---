using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class Map: IDraw
    {
        public int w;
        public int h;
        //固定墙壁
        private List<DrawObject> walls = new List<DrawObject>();
        //动态墙壁
        public List<DrawObject> dynamicWalls = new List<DrawObject>();

        public Map()
        {
            h = Game.h - 6;
            w = Game.w;
            for(int i = 0; i < Game.w; i+=2)
            {
                walls.Add(new DrawObject(E_DrawType.Wall, i, h));
            }
            for(int i = 0; i< h; i++)
            {
                walls.Add(new DrawObject(E_DrawType.Wall, 0, i));
                walls.Add(new DrawObject(E_DrawType.Wall, Game.w - 2, i));
            }
        }
        public void Draw()
        {
            //绘制动态墙壁
            for(int i =0; i<walls.Count; i++)
            {
                walls[i].Draw();
            }
            //绘制动态墙壁，有才绘制
            for (int i=0; i<dynamicWalls.Count; i++)
            {
                dynamicWalls[i].Draw();
            }
        }

        //添加动态方块函数
        public void AddWalls(List<DrawObject> walls)
        {
            for(int i = 0; i<walls.Count; i++)
            {
                //改变墙壁性质
                walls[i].ChangeType(E_DrawType.Wall);
                dynamicWalls.Add(walls[i]);
            }
        }
    }
}
