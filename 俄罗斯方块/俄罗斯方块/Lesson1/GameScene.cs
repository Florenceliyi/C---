using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        Map map;

        #region Lesson10 
        //bool isRunning;
        //Thread inputThread;
        #endregion
        public GameScene()
        {
            map = new Map();
      
        }

        

        public void Update()
        {
            
          //地图绘制
          map.Draw();
               
        }
    }
}
