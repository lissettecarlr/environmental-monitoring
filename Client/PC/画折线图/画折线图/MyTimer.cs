using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 画折线图
{
    public class MyTimer
    {
        public delegate void Elapsed(); //定义委托  
        public event Elapsed OnElapsed;
        private long _Interval = 1000;
        public long Interval
        {
            get { return _Interval; }
            set { _Interval = value; }
        }
        private bool _IsStart = false;
        private Thread _TimerThread;
        public void Start()
        {
            if (_IsStart)
                return;
            _IsStart = true;
            _TimerThread = new Thread(new ThreadStart(DoTimer));
            _TimerThread.Start();
        }

        public void Stop()
        {
            try
            {
                if (!_IsStart)
                    return;
                _IsStart = false;
                _TimerThread.Abort();
            }
            catch (Exception e)
            { }
        }
        private void DoTimer()
        {
            try
            {
                int last = Environment.TickCount;
                while (_IsStart)
                {
                    if (Environment.TickCount - last > _Interval)
                    {
                        if (OnElapsed != null)
                            OnElapsed();
                        last = Environment.TickCount;

                    }
                    Thread.Sleep(100);
                }

            }
            catch (Exception e)
            { }
        }
    }
}