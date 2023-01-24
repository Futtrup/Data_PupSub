using Data_SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Poll
{
    class DataService
    {
        private CancellationTokenSource _tokenSource;
        private DataProvider _dataProvider;
        private DataPoller _dataPoller;

        public void StartDataService()
        {
            Console.WriteLine("Starting data service - High frequence with polling");

            _tokenSource = new CancellationTokenSource();
            CancellationToken ct = _tokenSource.Token;

            _dataPoller = new DataPoller();
            _dataProvider = new DataProvider();

            Task t_dataPoller = Task.Run(() => _dataPoller.StartPollingData(_dataProvider, ct), ct);
            Task t_dataProvider = Task.Run(() => _dataProvider.Start_HighFreqData_WithoutEvent(ct), ct);



            Task.WaitAll(t_dataProvider, t_dataPoller);
        }
    }
}
