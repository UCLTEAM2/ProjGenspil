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
        internal List<Stock> Games { get => games; set => games = value; }
        internal List<Stock> WaitingList { get => waitingList; set => waitingList = value; }
        internal List<Stock> Requests { get => requests; set => requests = value; }


    }
}
