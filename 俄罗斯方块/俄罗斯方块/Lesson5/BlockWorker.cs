using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块

{
    //变形左右枚举
    enum E_Change_Type
    {
        left,
        right
    }
    class BlockWorker : IDraw
        {
        //方块们
        private List<DrawObject> blocks;

        private Dictionary<E_DrawType, BlockInfo> blockInfoDic;

        //当前形态的索引
        private int currentInfoIndex;
        private BlockInfo currentBlockInfo;

        public BlockWorker()
        {
            blockInfoDic = new Dictionary<E_DrawType, BlockInfo>()
           {
               {E_DrawType.Cube, new BlockInfo(E_DrawType.Cube) },
               {E_DrawType.Line, new BlockInfo(E_DrawType.Line) },
               {E_DrawType.Tank, new BlockInfo(E_DrawType.Tank) },
               {E_DrawType.Left_Ladder, new BlockInfo(E_DrawType.Left_Ladder) },
               {E_DrawType.Right_Ladder, new BlockInfo(E_DrawType.Right_Ladder) },
               {E_DrawType.Left_Long_Ladder, new BlockInfo(E_DrawType.Left_Long_Ladder) },
               {E_DrawType.Right_Long_Ladder, new BlockInfo(E_DrawType.Right_Long_Ladder) },
           };
        }
        public void RandomCreateBlock()
        {
        //随机方块类型
        Random r = new Random();
        E_DrawType type = (E_DrawType)r.Next(1, 8);
            //新建方块就是创建4个小方形
            blocks = new List<DrawObject>()
            {
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),

            };
            //初始化方块的位置，方块list的第0个就是远点方块
            blocks[0].pos = new Position(24, 5);
            //取出方块形态信息进行具体随机
            currentBlockInfo = blockInfoDic[type];
            //随机几种形态设置方块信息
            currentInfoIndex = r.Next(0, currentBlockInfo.Count);
            //取出其中一种形态的坐标信息
            Position[] pos = currentBlockInfo[currentInfoIndex];
            for(int i =0; i< pos.Length; i++)
            {
                //取出来pos是相对原点方块的坐标
                blocks[i + 1].pos = blocks[0].pos + pos[i];
            }
        }

        public void Draw()
        {
            Console.WriteLine(blocks);
            for (int i = 0; i < blocks.Count; i++)
            {

                blocks[i].Draw();

            }
        }

        #region 变形相关方法
        public void Change(E_Change_Type type)
        {
            //清楚变换之前的形态
            ClearDraw();
            switch (type)
            {
                case E_Change_Type.left:
                    --currentInfoIndex;
                    if(currentInfoIndex < 0)
                    {
                        currentInfoIndex = currentBlockInfo.Count - 1;
                    }
                    break;
                case E_Change_Type.right:
                    ++currentInfoIndex;
                    if(currentInfoIndex >= currentBlockInfo.Count)
                    {
                        currentInfoIndex = 0;
                    }
                    break;
                default:
                    break;
            }
            //得到位置偏移信息,用于设置另外三个小方块
            Draw();
            
        }
        //擦除的方法
        public void ClearDraw()
        {
            for(int i = 0;i< blocks.Count; i++)
            {
                blocks[i].ClearDraw();
            }
        }

        //判断是否能变形
        public bool CanChange(E_Change_Type type, Map map)
        {
            int currentIndex = currentInfoIndex;

            switch (type)
            {
                case E_Change_Type.left:
                    --currentIndex;
                    if (currentIndex < 0)
                    {
                        currentIndex = currentBlockInfo.Count - 1;
                    }
                    break;
                case E_Change_Type.right:
                    ++currentIndex;
                    if (currentIndex >= currentBlockInfo.Count)
                    {
                        currentIndex = 0;
                    }
                    break;
                default:
                    break;
            }

            //通过临时索引取出形态信息用于重合判断
            Position[] currentPosition = currentBlockInfo[currentIndex];

            //是否超出地图边界
            Position tempPos;
            for (int i = 0; i < currentPosition.Length; i++)
            {
                tempPos = blocks[0].pos + currentPosition[i];
                //判断左右边界和下边界
                if (tempPos.x < 2 || tempPos.x >= Game.w - 2 || tempPos.y >= map.h)
                {
                    return false;
                }
            }
            //是否与地图上的动态方块重合
            for (int i = 0; i < currentPosition.Length; i++)
            {
                tempPos = blocks[0].pos + currentPosition[i];
                for(int j = 0; j< map.dynamicWalls.Count; j++)
                {
                    if(tempPos == map.dynamicWalls[j].pos)
                    {
                        return false;
                    }
                }
            }
                return true;
        }
        #endregion

        #region 方块左右移动
        public void MoveRL(E_Change_Type type, Map map)
        {
            //根据传入的类型决定左动还是右动
            Position movePos = new Position(type == E_Change_Type.left ? -2 : 2, 0);
            for(int i = 0; i< blocks.Count; i++)
            {
                blocks[i].pos += movePos;
            }

            //动之后再画上去
            Draw();

        }

        //判断是否可以左右移动
        public bool CanMoveRL(E_Change_Type type, Map map)
        {
            //根据传入的类型决定左动还是右动
            Position movePos = new Position(type == E_Change_Type.left ? -2 : 2, 0);
            //预判断得到一个临时变量
            Position pos;
            //判断左右两边重合
            for (int i = 0; i < blocks.Count; i++)
            {
                pos = blocks[i].pos + movePos;
                if (pos.x < 2 || pos.x >= Game.w - 2)
                {
                    return false;
                }
            }
            //和动态方块重合的情况
            for (int i = 0; i < blocks.Count; i++)
            {
                pos = blocks[i].pos + movePos;
                for (int j = 0; j < map.dynamicWalls.Count; j++)
                {
                    if (pos == map.dynamicWalls[j].pos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 方块自动向下移动
        public void AutoMove()
        {
            //变之前擦除
            ClearDraw();
            //得到所有方块让其向下移动
            for(int i = 0; i< blocks.Count; i++)
            {
                //Y轴向下移动
                blocks[i].pos.y += 1;
            }

            //变了之后再画
            Draw();
        }

        public bool CanMove(Map map)
        {
            //临时变量存储下一次移动的位置用于重合判断
            Position movePos = new Position(0, 1);
            Position pos;
            //边界
            for(int i = 0; i<blocks.Count; i++)
            {
                pos = blocks[i].pos + movePos;
                if(pos.y >= map.h)
                {
                    //停下来 变成地图动态方块
                    map.AddWalls(blocks);

                    //随机创建新的方块
                    RandomCreateBlock();
                    return false;
                }
            }
            //动态方块
            for (int i = 0; i < blocks.Count; i++)
            {
                pos = blocks[i].pos + movePos;
                for (int j = 0; j < map.dynamicWalls.Count; j++)
                {
                    if (pos == map.dynamicWalls[j].pos)
                    {
                        //停下来 变成地图动态方块
                        map.AddWalls(blocks);

                        //随机创建新的方块
                        RandomCreateBlock();
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

    }
}
