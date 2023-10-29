namespace Dz_na_12._10
{
    #region Zavdanua
    /*
     Завдання 1:
     Розробити клас «Freezer», який описує морозильну камеру з дотриманням
     наступних вимог:
         1. Реалізувати не менше п'яти закритих полів (різних типів), що представляють
            основні характеристики класу.
         2. Створити не менше трьох методів управління класом і методи доступу до
            його закритих полів.
         3. Створити метод, в який передаються аргументи за посиланням.
         4. Створити не менше двох статичних полів (різних типів), що представляють
            спільні характеристики об'єктів даного класу.
         5. Створити статичний конструктор для ініціалізації статичних полів.
         6. Обов'язковою вимогою є реалізація декількох перевантажених
            конструкторів, аргументи яких визначаються студентом, виходячи із
            специфіки реалізованого класу і так само реалізація конструктора за
            замовчуванням. По можливості застосувати делегування конструкторів.
         7. Перевизначити алгоритм методу ToString(), який буде повертати інформацію
            про об’єкт у вигляді рядка.
         8. Перенести описи всіх методів в інший файл, використовуючи partial class.
         9. Створити масив(не менше 5 елементів) об'єктів створеного класу та показати
            інформацію по кожному.
    */
    #endregion
    class Freezer
    {
        //private int height; висота 
        //private int width; ширина
        //private int maxT; максимальна температура 
        //private int minT; мінімальна температура
        private static string model;
        private static int count;

        static Freezer()
        {
            model = "Freezer Samsung pro super ultra giper top";
            count = 0;
        }
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value >= 0)
                {
                    height = value;
                }
                else
                    height = 0;
            }
        }
        private int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (value >= 0)
                {
                    width = value;
                }
                else
                    width = 0;
            }
        }
        private int maxT;
        public int MaxT
        {
            get { return maxT; }
            set
            {
                if (value >= -5)
                {
                    maxT = value;
                }
                else
                    maxT = 0;
            }
        }
        private int minT;
        public int MinT
        {
            get { return minT; }
            set
            {
                if (value <= -10)
                {
                    minT = value;
                }
                else
                    minT = 0;
            }
        }
        public Freezer(int height, int width, int maxT, int minT)
        {
            this.height = height;
            this.width = width;
            this.maxT = maxT;
            this.minT = minT;
        }

        public override string ToString()
        {
            return $"Model : {model}\nHeight : {Height}\nWight : {Width}\nMaxT : {MaxT}\nMinT : {MinT}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezer = new Freezer[5];
            for (int i = 0; i < freezer.Length; i++)
            {

                Console.Write("Enter height freezer : ");
                int height = int.Parse(Console.ReadLine());
                Console.Write("Enter width freezer : ");
                int width = int.Parse(Console.ReadLine());
                Console.Write("Enter max temperature freezer : ");
                int maxT = int.Parse(Console.ReadLine());
                Console.Write("Enter min temperature freezer : ");
                int minT = int.Parse(Console.ReadLine());
                freezer[i] = new Freezer(height, width, maxT, minT);
            }
            for (int i = 0; i < freezer.Length; i++)
            {
                Console.WriteLine($"\n\n\n----------- Freezer number {i} ---------------");
                Console.WriteLine(freezer[i].ToString());
            }
        }


    }
}