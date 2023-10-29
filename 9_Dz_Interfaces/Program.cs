namespace Dz_na_23._10
{
    #region Zavdanua
    /*
     Завдання 1
            Створіть інтерфейс IOutput. У ньому мають бути два
            методи:
                ■ void Show() — відображає інформацію;
                ■ void Show(string info) — відображає інформацію та
                інформаційне повідомлення, зазначене у параметрі
                info.
            Створіть клас Array (масив цілого типу) із необхідними методами. Цей клас має імплементувати інтерфейс
            IOutput.
                Метод Show() — відображає на екран елементи масиву.
                Метод Show(string info) — відображає на екрані елементи масиву та інформаційне повідомлення, зазначене
                у параметрі info.
            Напишіть код для тестування отриманої функціональності.
    Завдання 2
            Створіть інтерфейс IMath. У ньому мають бути чотири
            методи:
                ■ int Max() — повертає максимум;
                ■ int Min() — повертає мінімум;
                ■ float Avg() — повертає середньоарифметичне;
                ■ bool Search(int valueToSearch) — шукає valueSearch
                всередині контейнера даних. Повертає true, якщо
                значення знайдено. Повертає false, якщо значення
                не знайдено.
            Клас, створений у першому завданні Array, має імплементувати інтерфейс IMath.
                Метод Max — повертає максимум серед елементів
                масиву.
                Метод Min — повертає мінімум серед елементів масиву.
                Метод Avg — повертає середньоарифметичне серед
                елементів масиву.
                Метод Search — шукає значення всередині масиву.
                Повертає true, якщо значення знайдено. Повертає false,
                якщо значення не знайдено.
            Напишіть код для тестування отриманої функціональності
    Завдання 3
            Створіть інтерфейс ISort. У ньому мають бути три
            методи:
                ■ void SortAsc() — сортування за зростанням;
                ■ void SortDesc() — сортування за зменшенням;
                ■ void SortByParam(bool isAsc) — сортування залежно
                від переданого параметра. Якщо isAsc дорівнює true,
                сортуємо за зростанням. Якщо isAsc дорівнює false,
                сортуємо за зменшенням.
            Клас, створений у першому завданні Array, має імплементувати інтерфейс ISort.
                Метод SortAsc — сортує масив за зростанням.
                Метод SortDesc — сортує масив за спаданням.
                Спосіб SortByParam — сортує масив залежно від переданого параметра. Якщо isAsc дорівнює true, сортуємо
                за зростанням. Якщо isAsc дорівнює false, сортуємо за
                зменшенням.
            Напишіть код для тестування отриманої функціональності.
     */
    #endregion
    // Interface number 1
    interface IOtput
    {
        void Show();// displays information;
        void Show(string info);// displays the information and information message specified in the info parameter
    }

    // Interface number 2
    interface IMath
    {
        int Max();// returns maximum;
        int Min();// returns minimum;
        double Avg();// returns the arithmetic mean;
        bool Search(int valueToSearch);
        // Sorting depending on the passed parameter
    }
    // Interface number 3
    interface ISort
    {
        void SortAsc();// sorting by growth;
        void SortDesc();// descending sorting;
        void SortByParam(bool isAsc);
        // Sorting depending on the passed parameter
    }
    class Array : IOtput, IMath, ISort
    {
        private int[] array;
        public Array(int size)
        {
            array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(100);
            }
        }
        // Task number 1
        public void Show()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " + array[i]);
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Show();
            Console.Write(info);
        }
        // Task number 2
        public double Avg()
        {
            return array.Average();
        }

        public int Max()
        {
            return array.Max();
        }

        public int Min()
        {
            return array.Min();
        }

        public bool Search(int valueToSearch)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == valueToSearch)
                    return true;
            }
            return false;
        }


        // Task number 3
        public void SortAsc()
        {
            System.Array.Sort(array);
        }

        public void SortDesc()
        {
            System.Array.Sort(array);
            int[] a = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                a[i] = array[i];
            }
            System.Array.Reverse(a);
            array = a;
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string info = " Salaam Aleikum";
            Array array = new Array(10);
            Console.WriteLine("\n\n\n------------- Task 1 ------------");
            Console.Write("Array : ");
            array.Show();

            Console.Write("Array + info : ");
            array.Show(info);

            Console.WriteLine("\n\n\n------------- Task 2 ------------");
            Console.Write("Array Max : ");
            int a = array.Max();
            Console.WriteLine(a)
                ;
            Console.Write("Array Min : ");
            int b = array.Min();
            Console.WriteLine(b);

            Console.Write("Array Avarage number : ");
            double d = array.Avg();
            Console.WriteLine(d);

            Console.Write("Array Search number : ");
            bool c = array.Search(47);
            Console.WriteLine(c);

            Console.WriteLine("\n\n\n------------- Task 3 ------------");
            Console.Write("\nArray sort by growth\n");
            Console.WriteLine("Ne sort");
            array.Show();
            array.SortAsc();
            Console.WriteLine("sort");
            array.Show();

            Console.Write("\n\nArray descending sort\n");
            Console.WriteLine("Ne sort");
            array.Show();
            array.SortDesc();
            Console.WriteLine("sort");
            array.Show();

            Console.Write("\n\nArray sorting depending on the parameter\n");
            Console.WriteLine("Ne sort");
            array.Show();
            array.SortByParam(false);
            Console.WriteLine("sort");
            array.Show();


        }
    }
}