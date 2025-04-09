namespace ProjGenspil
{
    public class Customer
    {
        private string _customerName;
        private string _customerPhone;
        private string _customerEmail;
        private string _gameName;
        private string _gameVariant;


        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string CustomerPhone { get => _customerPhone; set => _customerPhone = value; }
        public string CustomerEmail { get => _customerEmail; set => _customerEmail = value; }
        public string GameName { get => _gameName; set => _gameName = value; }
        public string GameVariant { get => _gameVariant; set => _gameVariant = value; }

        public Customer() { }

        public Customer(string customerName, string customerPhone, string customerEmail, string gameName, string gameVariant)
        {
            _customerName = customerName;
            _customerPhone = customerPhone;
            _customerEmail = customerEmail;
            _gameName = gameName;
            _gameVariant = gameVariant;

        }

        public override string ToString()
        {
            var customerData = new System.Text.StringBuilder();
            customerData.Append($"{CustomerName},{CustomerPhone},{CustomerEmail},{GameName},{GameVariant}");
            //customerData.AppendLine(); // Adds platform-specific line ending (\r\n on Windows)

            return customerData.ToString();
        }

        public static Customer FromString(string[] lines, ref int currentLine)
        {
            // Parse the BoardGameVariant details
            string[] customerParts = lines[currentLine].Split(',');
            var customer = new Customer
            {
                CustomerName = customerParts[0],
                CustomerPhone = customerParts[1],
                CustomerEmail = customerParts[2],
                GameName = customerParts[3],
                GameVariant = customerParts[4]
            };

            return customer;
        }

        public string GetRequestDetails()
        {
            int windowWidth = 80; // Default width
            try
            {
                windowWidth = Console.WindowWidth;
            }
            catch (IOException)
            {
                // Handle the exception or use the default width
            }

            string details = $"\nCustomer Name: {CustomerName}" +
            $"\nPhone: {CustomerPhone}" +
            $"\nEmail: {CustomerEmail}" +
            $"\nGame Name: {GameName}" +
            $"\nGame Variant: {GameVariant}";
            return details;
        }
    }
}
