using System.Text;
namespace Dz_na_07._10
{
    #region Zavdanua
    /*
    Завдання 1
            Створіть додаток, який відображає кількість парних,
            непарних, унікальних елементів масиву.
    Завдання 2
            Створіть додаток, який відображає кількість значень у
            масиві менше заданого параметра користувачем.Наприклад,
            кількість значень менших, ніж 7 (7 введено користувачем
            з клавіатури).
    Завдання 3
            Оголосити одновимірний(5 елементів) масив з назвою
            A i двовимірний масив(3 рядки, 4 стовпці) дробових чисел
            з назвою B.Заповнити одновимірний масив А числами,
            введеними з клавіатури користувачем, а двовимірний
            масив В — випадковими числами за допомогою циклів.
            Вивести на екран значення масивів: масиву А — в один
            рядок, масиву В — у вигляді матриці.Знайти у даних
            масивах загальний максимальний елемент, мінімальний
            елемент, загальну суму усіх елементів, загальний добуток
            усіх елементів, суму парних елементів масиву А, суму
            непарних стовпців масиву В.
    Завдання 4
            Дано двовимірний масив розміром 5×5, заповне-
            ний випадковими числами з діапазону від –100 до 100.
            Визначити суму елементів масиву, розташованих між
            мінімальним і максимальним елементами.
    Завдання 5:
            Визначити кількість елементів в заданому масиві, що відрізняються
            від мінімального на 5.
    */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Завдання 1
            Console.WriteLine("\n\n-------------- Завдання 1 ------------\n");
            int[] arr = { 1, 2, 3, 4, 5, 2, 3, 6 };
            int evenNumbers = arr.Count(x => x % 2 == 0);
            int oddNumbers = arr.Count(x => x % 2 != 0);
            int uniqueNumbers = arr.Distinct().Count();
            Console.WriteLine($"Парних : {evenNumbers}, Непарних : {oddNumbers}, Унікальних : {uniqueNumbers}");
            Console.WriteLine();
            // Завдання 2
            Console.WriteLine("\n\n-------------- Завдання 2 ------------\n");
            int[] arr2 = { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            Console.Write("Введіть цифру : ");
            int parameter = Convert.ToInt32(Console.ReadLine());
            int count = arr2.Count(x => x < parameter);
            Console.WriteLine($"Кількість значень менше {parameter}: {count}");

            Console.WriteLine();
            // Завдання 3
            Console.WriteLine("\n\n-------------- Завдання 3 ------------\n");
            int[] A = new int[5];
            double[,] B = new double[3, 4];
            Random random = new Random();

            Console.WriteLine("Введіть елементи масиву A :");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Масив B :");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble();
                    Console.Write($"{B[i, j]:F2}\t");
                }
                Console.WriteLine();
            }

            int maxA = A.Max();
            int minA = A.Min();
            double maxB = B.Cast<double>().Max();
            double minB = B.Cast<double>().Min();
            int sumA = A.Sum();
            double productB = 1.0;
            foreach (var value in B)
            {
                productB *= value;
            }
            Console.WriteLine("\n---------------- Масив А -------------------");
            Console.WriteLine($"Максимальний елемент масиву A : {maxA}, Мінімальний елемент масиву A : {minA}\n");

            Console.WriteLine("\n---------------- Масив В -------------------");
            Console.WriteLine($"Максимальний елемент масиву B : {maxB}, Мінімальний елемент масиву B : {minB}\n");

            Console.WriteLine("\n---------------- Сума усіх елементів -------------------");
            Console.WriteLine($"Загальна сума усіх елементів масиву A  {sumA}, Загальний добуток усіх елементів масиву B : {productB} \n");

            int evenSumA = A.Where(x => x % 2 == 0).Sum();
            int oddSumB = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (j % 2 == 1)
                    {
                        oddSumB += (int)B[i, j];
                    }
                }
            }
            Console.WriteLine($"Сума парних елементів масиву A: {evenSumA}");
            Console.WriteLine($"Сума непарних стовпців масиву B: {oddSumB}");

            Console.WriteLine();
            // Завдання 4
            Console.WriteLine("\n\n-------------- Завдання 4 ------------\n");
            int[,] matrix = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = rand.Next(-100, 101);
                }
            }

            int minValue = matrix[0, 0];
            int maxValue = matrix[0, 0];
            int sumBetween = 0;

            foreach (int num in matrix)
            {
                if (num < minValue)
                {
                    minValue = num;
                }
                if (num > maxValue)
                {
                    maxValue = num;
                }
            }

            bool betweenMinMax = false;
            foreach (int num in matrix)
            {
                if (betweenMinMax)
                {
                    sumBetween += num;
                }
                if (num == minValue)
                {
                    betweenMinMax = !betweenMinMax;
                }
                if (num == maxValue)
                {
                    betweenMinMax = !betweenMinMax;
                }
            }

            Console.WriteLine($"Сума елементів між мінімальним і максимальним: {sumBetween}");

            Console.WriteLine();
            // Завдання 5
            Console.WriteLine("\n\n-------------- Завдання 5 ------------\n");
            int[] array5 = { 3, 7, 2, 1, 9, 5, 8 };
            int min5 = array5.Min();
            int countDiffBy5 = array5.Count(x => x != min5 + 5);
            Console.WriteLine($"Кількість елементів, що відрізняються від мінімального на 5: {countDiffBy5}");
        }
    }
}