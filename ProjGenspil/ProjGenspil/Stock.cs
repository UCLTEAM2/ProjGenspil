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

        public List<BoardGameVariant> Games { get; set; } = new List<BoardGameVariant>();

        public void SaveToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                //writer.NewLine = "\r\n";
                foreach (var variant in Games)
                {
                    
                    writer.Write(variant.ToString());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            Games.Clear();
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            int currentLine = 0;

            while (currentLine < lines.Length)
            {
                var variant = BoardGameVariant.FromString(lines, ref currentLine);
                Games.Add(variant);
                currentLine++; // Move to the next variant (or end of file)
            }
        }



        //public static List<BoardGameVariant> Games = new List<BoardGameVariant>();
        //public static List<BoardGameCopy> Copies = new List<BoardGameCopy>();

        //public int Quantity { get => _quantity; set => _quantity = value; }
        //public List<Stock> WaitingList { get => _waitingList; set => _waitingList = value; }
        //public List<Stock> Requests { get => _requests; set => _requests = value; }

        //Matador
        //monopoly
        //Yatzy
        //Matador junior
        //Matador Lego
    }
}
