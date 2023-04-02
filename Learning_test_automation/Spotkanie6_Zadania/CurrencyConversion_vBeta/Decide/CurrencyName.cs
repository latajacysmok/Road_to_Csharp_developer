namespace Decide //pole typu enum jako waluta i jeszcze jedna klasa która ma pola public string foreignCurrency, public string userCurrency.
    //to mogą być pola albo properta.
{
    public class Names
    {
        public enum CurrencyDefault
        {
            Dollar = 1,
            Euro = 2,
            Czech_crown = 3,
        }
        public string CurrencyUser()
        {
            Console.Write("Dear user, tell me what currency you want to sell: ");
            while (true)
            {       
                string userCurrency = Console.ReadLine();
                if (!String.IsNullOrEmpty(userCurrency))
                {
                    return userCurrency;
                }
                else Console.WriteLine("Currency name is required, please try again.");
            }
        }
    } 
}
