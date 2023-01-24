using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data_SharedLib;

namespace Data_Poll
{
    class DataPoller
    {
        private int _value;
        private bool _initialized = false;

        internal void StartPollingData(DataProvider dataProvider, CancellationToken ct)
        {
            while (true)
            {
                Console.WriteLine("Polling data");
                int pollValue = dataProvider.Value;

                UpdateData(pollValue);

                Thread.Sleep(2000);
            }
        }

        private void UpdateData(int value)
        {
            if (!_initialized)
            {
                _value = value;
                _initialized = true;
                Console.WriteLine("Initializing value:" + _value + "\n");
            }
            else
            {
                Console.WriteLine("Old value:" + _value);
                Console.WriteLine("New value:" + value);

                int diff = value - _value;
                _value = value;

                Console.WriteLine("Difference:" + diff + "\n");
            }
        }
    }
}
