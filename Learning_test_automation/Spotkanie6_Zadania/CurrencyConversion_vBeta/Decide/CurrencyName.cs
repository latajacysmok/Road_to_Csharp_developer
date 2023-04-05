namespace Decide
{
    public class CurrencyName
    {
        public string UserEntersNameOfCurrency(bool ifBuy)
        {
            if (ifBuy == true) Console.Write("Dear user, tell me what currency you want to buy: ");
            else Console.Write("Dear user, tell me what currency you want to sell: ");

            while (true)
            {
                string userCurrency = Console.ReadLine();
                if (!String.IsNullOrEmpty(userCurrency)) return userCurrency;
                Console.WriteLine("Currency name is required, please try again.");
            }
        }
    }
}
