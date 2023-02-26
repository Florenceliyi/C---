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
            map = new Map(this);
            blockWorker = new BlockWorker();

            //设置成后台线程 生命周期由主线程决定

            //添加输入事件监听
            InputThead.Instance.inputEvent += CheckInputThread;
            /*inputThread = new Thread(CheckInputThread);
            inputThread.IsBackground = true;
            inputThread.Start();*/
        }

        private void CheckInputThread()
        {
            //while (true)
            //{
                if (Console.KeyAvailable)
                {
                    lock (blockWorker)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if (blockWorker.CanChange(E_Change_Type.left, map))
                                {
                                    blockWorker.Change(E_Change_Type.left);
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (blockWorker.CanChange(E_Change_Type.right, map))
                                {
                                    blockWorker.Change(E_Change_Type.right);
                                }
                                break;
                            case ConsoleKey.A:
                                if (blockWorker.CanMoveRL(E_Change_Type.left, map))
                                    blockWorker.MoveRL(E_Change_Type.left, map);
                                break;
                            case ConsoleKey.B:
                                if (blockWorker.CanMoveRL(E_Change_Type.right, map))
                                    blockWorker.MoveRL(E_Change_Type.right, map);
                                break;
                            case ConsoleKey.S:
                                //向下动
                                if (blockWorker.CanMove(map))
                                    blockWorker.AutoMove();
                            break;
                            default:
                                break;
                        }
                    }
                }
            //}
        }

        public void Update()
        {

            //锁里面不要包含 休眠 不然会影响别人
            lock (blockWorker)
            {
                //地图绘制
                map.Draw();
                //搬运工绘制
                blockWorker.Draw();
                //自动向下移动
                if (blockWorker.CanMove(map))
                    blockWorker.AutoMove();
            }

            //用线程休眠的形式
            Thread.Sleep(200);

        }


        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThread()
        {
            //isRunning = false;
            //inputThread = null;

            //移除输入事件监听
            InputThead.Instance.inputEvent -= CheckInputThread;

            //在某些c#版本中 会直接报错 没用
            //inputThread.Abort();
        }

    }
}
