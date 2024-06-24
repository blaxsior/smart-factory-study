using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywinform.model
{
    public class Conveyor
    {

        private Thread thread;
        private HwController hw;

        private int LEFT_SLOW;
        private int LEFT_STOP;
        private int RIGHT_SLOW;
        private int RIGHT_STOP;

        public Conveyor(HwController hwController)
        {
            this.hw = hwController;
            LEFT_SLOW = 0;
            LEFT_STOP = 1;
            RIGHT_SLOW = 2;
            RIGHT_STOP = 3;

            thread = new Thread(ThreadFunc);
            thread.IsBackground = true;
            thread.Start();
        }

        void ThreadFunc()
        {
            // get센서
            // 0: left slow
            // 1: left stop
            // 2: right slow
            // 3: right stop
            int step = 0;
            int oldstep = -1;
            while (true)
            {
                switch (step)
                {
                    case 0: // 오른쪽에 박스 들어옴
                        if (hw.GetOne(RIGHT_SLOW) == true || hw.GetOne(RIGHT_STOP) == true)
                        {
                            // conveyor cw
                            hw.PutOne(0, true);
                            // conveyor speed high
                            hw.PutOne(2, true);
                            step = 100;
                        }
                        break;
                    case 100: // 왼쪽으로 이동 & left slow 감지
                        if (hw.GetOne(LEFT_SLOW))
                        {
                            // 속도 저속 2 -> 3
                            hw.PutOne(2, false);
                            hw.PutOne(3, true);
                            step = 200;
                        }
                        break;
                    case 200: // 왼쪽으로 천천히 이동 & left stop 감지
                        if (hw.GetOne(LEFT_STOP))
                        {
                            // 속도 고속
                            hw.PutOne(3, false);
                            hw.PutOne(2, true);

                            // cw ==> ccw
                            hw.PutOne(0, false);
                            hw.PutOne(1, true);
                            step = 300;
                        }
                        break;
                    case 300: // 오른쪽으로 빠르게 이동 + right slow 감지
                        if (hw.GetOne(RIGHT_SLOW))
                        {
                            // 속도 저속 2 -> 3
                            hw.PutOne(2, false);
                            hw.PutOne(3, true);
                            step = 400;
                        }
                        break;
                    case 400: // 오른쪽으로 천천히 이동 + right stop 감지
                        if (hw.GetOne(RIGHT_STOP))
                        {
                            //속도 고속 + 왼쪽으로, step 100
                            hw.PutOne(3, false);
                            hw.PutOne(2, true);

                            // cw ==> ccw
                            hw.PutOne(1, false);
                            hw.PutOne(0, true);
                            step = 100;
                        }
                        break;
                }

                if(oldstep != step)
                {
                    Debug.WriteLine($"Step: {step}");
                    oldstep = step;
                }

                Thread.Sleep(100);
            }
        }
    }
}
