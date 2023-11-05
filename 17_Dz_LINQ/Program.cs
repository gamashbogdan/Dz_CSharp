namespace Dz_na_13._11
{
    #region Zavdanua
    /*
      1:
        Дано цілочисельну послідовність.Витягти з неї всі позитивні числа,
        відсортувавши їх по зростанню. (можна використати Where, OrderBy)
      2:
        Дано колекцію цілих чисел.Знайти кількість позитивних двозначних елементів,
        а також їх середнє арифметичне. (Where, Avg)
    */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Завдання 1
            int[] arr = { 3, -1, 4, 0, -2, 5, -6, 8, 9, -3 };
            IEnumerable<int> positiveNumbersSorted = arr.Where(x => x > 0).OrderBy(x => x);
            Console.WriteLine("Відсортовані позитивні числа:");
            foreach (var num in positiveNumbersSorted)
            {
                Console.Write(num+ "  ");
            }
            // Завдання 2
            int[] arr1 = { 12, -34, 56, -78, 90, 23, 45, -67, 89, 10 };
            var positiveTwoDigitElements = arr1.Where(x => x > 9 && x < 100);
            int count = positiveTwoDigitElements.Count();
            double average = positiveTwoDigitElements.Average();
            Console.WriteLine($"\n\nКількість позитивних двозначних елементів: {count}");
            foreach (var num in positiveTwoDigitElements)
            {
                Console.Write(num+"  ");
            }
            Console.WriteLine($"\n\nСереднє арифметичне: {average}");

        }
    }
}