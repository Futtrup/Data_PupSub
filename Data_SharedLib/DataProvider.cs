using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Data_SharedLib
{
    public class DataProvider
    {
        public event EventHandler<int> ValueChanged;
        public int Value { get; private set; } = 0;

        private Random _rnd = new Random();

        public void Start_HighFreqData_WithoutEvent(CancellationToken ct)
        {
            lock (this)
            {
                Console.WriteLine("Starting hight frequence Value update, without event, for poll driven data");
                while (true)
                {
                    if (ct.IsCancellationRequested) return;

                    Value += _rnd.Next(1, 10);
                    Thread.Sleep(50);
                }
            }
        }

        public void Start_LowFreqData_WithEvent(CancellationToken ct)
        {
            lock (this)
            {
                Console.WriteLine("Starting updating Value in low frequence for pub-sub with event OnValueChanged");
                while (true)
                {
                    if (ct.IsCancellationRequested) return;

                    Value += _rnd.Next(1, 10);
                    OnValueChanged(Value);
                    Thread.Sleep(_rnd.Next(500, 3000));
                }
            }
        }

        protected virtual void OnValueChanged(int value) =>
            ValueChanged?.Invoke(this, value);
    }
}
