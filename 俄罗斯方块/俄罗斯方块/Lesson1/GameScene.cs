using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        Map map;
        BlockWorker blockWorker;
        public GameScene()
        {
            map = new Map();
            blockWorker = new BlockWorker();
        }

        

        public void Update()
        {
            
          //地图绘制
            map.Draw();
            blockWorker.Draw();     

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    if(blockWorker.CanChange(E_Change_Type.left, map)){
                        blockWorker.Change(E_Change_Type.left);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (blockWorker.CanChange(E_Change_Type.right, map))
                    {
                        blockWorker.Change(E_Change_Type.right);
                    }
                case ConsoleKey.A:
                    if(blockWorker.CanMoveRL(E_Change_Type.left, map))
                    blockWorker.MoveRL(E_Change_type.left);
                    break;
                case ConsoleKey.B:
                    if (blockWorker.CanMoveRL(E_Change_Type.right, map))
                        blockWorker.MoveRL(E_Change_type.right);
                    break;
                default: 
                    break;
            }   
        }
    }
}
