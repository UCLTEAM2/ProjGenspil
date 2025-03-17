using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class Stock
    {
        private List<Stock> games;
        private List<Stock> waitingList;
        private List<Stock> requests;
        private int quantity;

        public int Quantity { get => quantity; set => quantity = value; }
        public List<Stock> Games { get => games; set => games = value; }
        public List<Stock> WaitingList { get => waitingList; set => waitingList = value; }
        public List<Stock> Requests { get => requests; set => requests = value; }

        public Stock(List<Stock> games, List<Stock> waitingList, List<Stock> requests, int quantity)
        {
            Games = games;
            WaitingList = waitingList;
            Requests = requests;
            Quantity = quantity;
            Quantity = quantity;
            Games = games;
            WaitingList = waitingList;
            Requests = requests;
        }
    }
}
