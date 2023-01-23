using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Data_PupSub
{
    internal class DataProvider
    {
        public event EventHandler<int> ValueChanged;

        private int _value = 0;
        private Random _rnd = new Random();


        public void Start(CancellationToken ct)
        {
            while (true)
            {
                if (ct.IsCancellationRequested) return;

                _value += _rnd.Next(1, 10);
                OnValueChanged(_value);
                Thread.Sleep(_rnd.Next(500, 3000));
            }
        }

        protected virtual void OnValueChanged(int value) =>
            ValueChanged?.Invoke(this, value);
    }
}
