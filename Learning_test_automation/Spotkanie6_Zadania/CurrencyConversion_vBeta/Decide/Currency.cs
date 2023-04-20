namespace Decide
{
    public class Currency
    {
        public decimal UserValueCurrency { get; }
        public string UserNameCurrency { get; }

        

        private decimal GetUserCourse(string currencyUserName)
        {
            
            Console.Write($"Dear user, give me the exchange rate at which I should count the {currencyUserName}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal exchangeRate)) return (Math.Round(exchangeRate, 4));
                else Console.Write($"This is not a number: {exchangeRate}. Try again, please: ");
            }
            //w inny sposób umożliwić tworzenie obiektu czyli pomyśleć nad konstruktorem
            // mieć konkretny konstruktor który jest wywoływany tylko wtedy gdy użytkownik podaję kurs
            // żeby logika wyciągania wartości waluty była utworzona osobna klasa jak np. Euro
        }
    //prop + tab
    }
}
