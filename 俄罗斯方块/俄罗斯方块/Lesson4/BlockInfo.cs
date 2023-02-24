using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class BlockInfo(){
        //方块信息坐标容器
        private List<Position[]> list;
        
        public BlockInfo(E_DrawType drawType)
        {
            list = new List<Position[]>();

            switch (drawType)
        {   //添加了一个形状的位置信息
            case E_DrawType.Cube:
                list.Add(new Position[3]
                {
                    new Position(0,-1),
                    new Position(0,1),
                    new Position(2,1)
                });
                list.Add(new Position[3]
                {
                    new Position(-4,0),
                    new Position(-2,0),
                    new Position(2,0)
                });
                list.Add(new Position[3]
                {
                    new Position(0,-2),
                    new Position(0,-1),
                    new Position(0,1)
                });
                list.Add(new Position[3]
                {
                    new Position(-2,0),
                    new Position(2,0),
                    new Position(4,0)
                });
                break;
            case E_DrawType.Line:
                //初始化 长条形状的4种形态的坐标信息
                list.Add(new Position[3] {
                        new Position(0,-1),
                        new Position(0,1),
                        new Position(0,2)
                    });
                list.Add(new Position[3] {
                        new Position(-4,0),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                list.Add(new Position[3] {
                        new Position(0,-2),
                        new Position(0,-1),
                        new Position(0,1)
                    });
                list.Add(new Position[3] {
                        new Position(-2,0),
                        new Position(2,0),
                        new Position(4,0)
                    });
                break;
            case E_DrawType.Tank:
                list.Add(new Position[3] {
                        new Position(-2,0),
                        new Position(2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3] {
                        new Position(0,-1),
                        new Position(-2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3] {
                        new Position(0,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                list.Add(new Position[3] {
                        new Position(0,-1),
                        new Position(2,0),
                        new Position(0,1)
                    });
                break;
            case E_DrawType.Left_Ladder:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,0),
                        new Position(2,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(0,1),
                        new Position(-2,1)
                    });
                list.Add(new Position[3]{
                       new Position(-2,-1),
                        new Position(-2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,-1),
                        new Position(-2,0)
                    });
                break;
            case E_DrawType.Right_Ladder:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(2,0)
                    });
                list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,1),
                        new Position(2,1),
                        new Position(-2,0)
                    });
                break;
            case E_DrawType.Left_Long_Ladder:
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                break;
            case E_DrawType.Right_Long_Ladder:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(0,1),
                        new Position(2,-1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(2,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                break;
            default:
                break;
        }
        }
        
    public Position[] this[int index]
    {
        get
        {
            if(index < 0)
            {
                return list[0];
            }else if(index >= list.Count)
            {
                return list[list.Count - 1];
            }
            else
            {
                return list[index];
            }
        }
    }
    //获取形态
    public int Count { get => list.Count; }
    }
}
