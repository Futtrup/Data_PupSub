using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_PupSub
{
    internal class DataListener
    {
        private int _value;
        private bool _initialized = false;

        public void UpdateData(int value)
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
