using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    public class Stock
    {
       
        private List<Stock> _waitingList;
        private List<Stock> _requests;
        private int _quantity;

        public static List<BoardGameVariant> Games = new List<BoardGameVariant>();

        //public int Quantity { get => _quantity; set => _quantity = value; }
        //public List<Stock> WaitingList { get => _waitingList; set => _waitingList = value; }
        //public List<Stock> Requests { get => _requests; set => _requests = value; }

        public Stock(List<Stock> games)
        {
            //Games = games;
            
        }

        //Matador
        //monopoly
        //Yatzy
        //Matador junior
        //Matador Lego
    }
}
