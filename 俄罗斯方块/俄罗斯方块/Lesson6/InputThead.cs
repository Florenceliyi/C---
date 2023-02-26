using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class InputThead
    {
        //线程成员变量
        Thread inputThread;

        //输入检测事件
        public event Action inputEvent;
        private static InputThead instance = new InputThead();
        public static InputThead Instance
        {
            get
            {
                return instance;
            }
        }


        private InputThead()
        {
            inputThread = new Thread(InputCheck);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        private void InputCheck()
        {
            while (true)
            {
                inputEvent?.Invoke();
            }
        }

    }
}
