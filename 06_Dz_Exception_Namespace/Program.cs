namespace Dz_na_16._10
{
    #region Zavdanua
    /*
    Завдання 1
            Користувач вводить до рядка з клавіатури набір сим-
            волів від 0-9. Необхідно перетворити рядок на число ціло-
            го типу.Передбачити випадок виходу за межі діапазону,
            який визначається типом int. Використовуйте механізм
            виключень.
    Завдання 2
            Створіть клас «Кредитна картка». Вам необхідно зберіга-
            ти інформацію про номер картки, ПІБ власника, CVC, дату
            завершення роботи картки і т.д.Передбачити механізми
            ініціалізації полів класу.Якщо значення для ініціалізації
            неправильне, генеруйте виняток.
    Завдання 3
            Користувач вводить до рядка з клавіатури математич-
            ний вираз. Наприклад, 3*2*1*4. Програма має підрахувати
            результат введеного виразу. У рядку можуть бути лише
            цілі числа і оператор*. Для обробки помилок введення
            використовуйте механізм виключень.*/
    #endregion
    class Card
    {
        private string cardnumber;

        public string Cardnumber
        {
            get { return cardnumber; }
            set
            {
                if (value.Length != 16)
                {
                    throw new ArgumentException("Error count of number");
                }
                else
                {
                    cardnumber = value;
                }
            }
        }

        public string PIB { get; set; }
        private string cvc;
        public string Cvc
        {
            get { return cvc; }
            set
            {
                if (value.Length != 3)
                {
                    throw new ArgumentException("Error count of CVC");
                }
                else
                {
                    cvc = value;
                }
            }
        }
        private DateTime dateend;

        public DateTime Dateend
        {
            get { return dateend; }
            set
            {
                if (value <= DateTime.Now)
                {
                    throw new ArgumentException("Error, wrong date");
                }
                else
                {
                    dateend = value;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Card Details : ");
            Console.WriteLine("Card Number : " + Cardnumber);
            Console.WriteLine("PIB : " + PIB);
            Console.WriteLine("CVC : " + Cvc);
            Console.WriteLine("Dateend : " + Dateend.ToString("dd-MM-yyyy"));
        }
    }

    class Program
    {

        static void Main()
        {
            // Завдання 1
            try
            {
                Console.WriteLine("Enter a number: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Number: " + number);
            }
            catch (OverflowException x)
            {
                Console.WriteLine("Overflow Exception: " + x.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Завдання 2
            Card c = new Card();
            try
            {
                Console.WriteLine("Enter PIB: ");
                c.PIB = Console.ReadLine();
                Console.WriteLine("Enter Dateend (year-month-day): ");
                c.Dateend = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Cvc: ");
                c.Cvc = Console.ReadLine();
                Console.WriteLine("Enter Cardnumber: ");
                c.Cardnumber = Console.ReadLine();
                c.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception: " + ex.Message);
            }
            // Завдання 3
            try
            {
                Console.WriteLine("Enter a mathematical expression (for example, 1*2*1*3) : ");
                string expression = Console.ReadLine();
                int result = CalculateExpression(expression);
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception: " + ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Arithmetic Exception: " + ex.Message);
            }

            static int CalculateExpression(string expression)
            {
                string[] elements = expression.Split('*');
                int result = 1;

                foreach (string element in elements)
                {
                    if (!int.TryParse(element, out int num))
                    {
                        throw new FormatException("Invalid format in the expression");
                    }
                    result *= num;
                }
                return result;
            }
        }
    }
}
