using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    class Stock
    {
        private List<Stock> _games;
        private List<Stock> _waitingList;
        private List<Stock> _requests;
        private int _quantity;

        public int Quantity { get => _quantity; set => _quantity = value; }
        public List<Stock> Games { get => _games; set => _games = value; }
        public List<Stock> WaitingList { get => _waitingList; set => _waitingList = value; }
        public List<Stock> Requests { get => _requests; set => _requests = value; }

        public Stock(List<Stock> games, List<Stock> waitingList, List<Stock> requests, int quantity)
        {
            Games = games;
            WaitingList = waitingList;
            Requests = requests;
            Quantity = quantity;
        }
    }
}
