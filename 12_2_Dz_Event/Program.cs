namespace Dz_na_30._10_Part_Two
{
    #region Zavdanua
    /*
     Завдання:
        Реалізувати на подійній моделі функціонал фінансової біржі.
        Створити клас «Біржа», який буде містити методи для імітації зміни курса та
        подію досягнення максиму або мінімуму курсу.
        Також є покупці-трейдери, які мають кількість своєї валюти та обробники зміни курсу
        і відповідоно до своїх цілей виконуватимуть роботу по продажу або купівлі грошей(акцій).
        Реалізацію генерації курсу розробляйте на власний розсуд (рандом).
    */
    #endregion
    public delegate void StockExchangeTrading(double DollarRate);
    class Trader
    {
        private double money;
        public double Money
        {
            get { return money; }
            set
            {
                if (value > 0)
                    money = value;
            }
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Buy { get; set; }// купити
        public double Sell { get; set; }// продати
        public void BuyCurrency(double DollarRate)
        {
            double purchaseAmount = 100;// 100 UAH сума покупки валюти 
            if (DollarRate > Buy)
            {
                Money = -purchaseAmount;
                double info = purchaseAmount / DollarRate;
                Console.WriteLine($"\t\tTrader - {Name} {LastName}, Buys a dollar on the exchange for the amount - {info} $");// Купує акції
            }
            else if (DollarRate >= Sell)
            {
                Console.WriteLine($"\t\tTrader - {Name} {LastName}, Sells his shares and records the profit");// Продає акції
            }
            else if (DollarRate < Buy)
            {
                Console.WriteLine($"\t\tTrader - {Name} {LastName}, Does not buy currency on the exchange");// Нічого не робить
            }
        }
    }
    class StockExchange
    {
        public event StockExchangeTrading stockExchangeTrading;
        public static double CourseGenerator()
        {
            return Random.Shared.Next(-100, 100);
        }
        public void Create()
        {
            double DollarRate = CourseGenerator();
            Console.WriteLine($"\n\n\n\n\tExchange rate {DollarRate} $");
            stockExchangeTrading?.Invoke(DollarRate);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trader> traders = new List<Trader>()
            {
                new Trader{Money = 754568.86, Name = "Serghey", LastName = "Magala", Buy = 1, Sell = 97},
                new Trader{Money = 25324.12, Name = "Fabio", LastName = "Viazzo", Buy = 3, Sell = 13},
                new Trader{Money = 3213.11, Name = "Ivan", LastName = "Scherman", Buy = 2.1, Sell = 22},
                new Trader{Money = 51000.90, Name = "Sadanand ", LastName = "Kalasabail", Buy = 1.6 , Sell = 41},
                new Trader{Money = 3123.81, Name = "Daniele  ", LastName = "Sambataro", Buy = 5.1, Sell = 12}
            };
            StockExchange stockExchange = new StockExchange();

            foreach (Trader trader in traders)
            {
                stockExchange.stockExchangeTrading += new StockExchangeTrading(trader.BuyCurrency);
            }
            for (int i = 0; i < 100; i++)
            {
                stockExchange.Create();
            }
        }
    }
}