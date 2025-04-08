namespace ProjGenspil
{
    public class Stock
    {


        public List<BoardGameVariant> Games { get; set; } = new List<BoardGameVariant>();
        public List<Customer> GameRequest { get; set; } = new List<Customer>();

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
        public void SaveToFileRequest(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                //writer.NewLine = "\r\n";
                foreach (var customer in GameRequest)
                {

                    writer.Write(customer.ToString());
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

        public void LoadFromFileRequest(string filePath)
        {
            GameRequest.Clear();
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            int currentLine = 0;

            while (currentLine < lines.Length)
            {
                var customer = Customer.FromString(lines, ref currentLine);
                GameRequest.Add(customer);
                currentLine++; // Move to the next variant (or end of file)
            }
        }

    }
}