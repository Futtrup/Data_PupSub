using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_PupSub
{
    internal class DataService
    {
        private CancellationTokenSource _tokenSource;
        private DataProvider _dataProvider;
        private DataListener _dataListener;

        public void StartDataService()
        {
            Console.WriteLine("Starting data service");

            _tokenSource = new CancellationTokenSource();
            CancellationToken ct = _tokenSource.Token;

            _dataListener = new DataListener();

            _dataProvider = new DataProvider();
            _dataProvider.ValueChanged += (s, e) => _dataListener.UpdateData(e);
            Task t_dataProvider = Task.Run(() => _dataProvider.Start(ct), ct);

            Task.WaitAll(t_dataProvider);
        }
    }
}
