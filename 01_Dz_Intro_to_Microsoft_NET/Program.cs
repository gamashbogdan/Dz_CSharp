using System.Text;
namespace Dz_na_05._10
{
    #region Zavdanua
    /*
    Завдання 1
            Виведіть на екран цитату Б'ярна Страуструпа: It's easy
            to win forgiveness for being wrong; being right is what gets you
            into real trouble.
            Приклад виводу:
            It's easy to win forgiveness for being wrong;
            being right is what gets you into real trouble.
            Bjarne Stroustrup
    Завдання 2
            Користувач вводить з клавіатури п'ять чисел. Необхідно знайти суму чисел, максимум і мінімум з п'яти чисел,
            добуток чисел. Результат обчислень вивести на екран.
    Завдання 3
            Користувач з клавіатури вводить шестизначне число.
            Необхідно перевернути число і відобразити результат.
            Наприклад, якщо введено 341256, результат 652143.
    Завдання 4
            Користувач вводить з клавіатури межі числового діапазону.Потрібно показати усі числа Фібоначчі з цього
            діапазону.Числа Фібоначчі — елементи числової послідовності, у якій перші два числа дорівнюють 0 і 1, а кожне
            наступне число дорівнює сумі двох попередніх чисел.
            Наприклад, якщо вказано діапазон 0–20, результат буде:
            0, 1, 1, 2, 3, 5, 8, 13.
    Завдання 5
            Дано цілі додатні числа A і B (A<B). Вивести усі цілі
            числа від A до B включно; кожне число має виводитися у
            новому рядку; при цьому кожне число має виводитися у
            кількість разів, рівну його значенню.Наприклад: якщо А
            = 3, а В = 7, то програма має сформувати в консолі такий
            висновок:
            3 3 3
            4 4 4 4
            5 5 5 5 5
            6 6 6 6 6 6
            7 7 7 7 7 7 7
    Завдання 6
            Користувач з клавіатури вводить довжину лінії, символ
            заповнювач, напрямок лінії(горизонтальна, вертикальна).
            Програма відображає лінію по заданих параметрах.
            Наприклад: +++++.
            Параметри лінії: горизонтальна лінія, довжина дорівнює п'яти, символ заповнювач +.
    */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Завдання 1
            Console.WriteLine("\n\n\t--------- Завдання номер 1 ---------\n");
            Console.WriteLine("\n\tIt's easy to win forgiveness for being wrong;\n\tbeing right is what gets you into real trouble\n\n\t\t\tAuthor: Bjarne Stroustrup");

            // Завдання 2
            Console.WriteLine("\n\n\t--------- Завдання номер 2 ---------\n");
            int[] numbers = new int[5];
            int sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            int product = 1;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введіть число " + (i + 1) + ": ");

                numbers[i] = int.Parse(Console.ReadLine());

                // Обчислення суми, мінімуму, максимуму та добутку чисел
                sum += numbers[i];
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                product *= numbers[i];
            }

            Console.WriteLine("Сума чисел: " + sum);
            Console.WriteLine("Мінімум: " + min);
            Console.WriteLine("Максимум: " + max);
            Console.WriteLine("Добуток чисел: " + product);

            // Завдання 3
            Console.WriteLine("\n\n\t--------- Завдання номер 3 ---------\n");
            Console.Write("Введіть шестизначне число: ");
            int inputNumber = int.Parse(Console.ReadLine());
            int reversedNumber = 0;

            while (inputNumber > 0)
            {
                int digit = inputNumber % 10;
                reversedNumber = (reversedNumber * 10) + digit;
                inputNumber /= 10;
            }

            Console.WriteLine("Результат: " + reversedNumber);

            // Завдання 4
            Console.WriteLine("\n\n\t--------- Завдання номер 4 ---------\n");
            Console.Write("Введіть початкове число діапазону: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Введіть кінцеве число діапазону: ");
            int end = int.Parse(Console.ReadLine());

            int a = 0, b = 1, fib = 0;

            while (fib <= end)
            {
                if (fib >= start)
                {
                    Console.Write(fib + " ");
                }

                fib = a + b;
                a = b;
                b = fib;
            }

            // Завдання 5
            Console.WriteLine("\n\n\t--------- Завдання номер 5 ---------\n");
            Console.Write("Введіть число A: ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Введіть число B (B > A): ");
            int B = int.Parse(Console.ReadLine());

            for (int i = A; i <= B; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            // Завдання 6
            Console.WriteLine("\n\n\t--------- Завдання номер 6 ---------\n");
            Console.Write("Введіть довжину лінії: ");
            int lineLength = int.Parse(Console.ReadLine());
            Console.Write("Введіть символ заповнювач: ");
            char fillChar = char.Parse(Console.ReadLine());
            Console.Write("\t1 - Горизонтальна\n\t2 - вертикальна\n\tВведіть напрямок : ");
            int direction = int.Parse(Console.ReadLine());

            if (direction == 1)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    Console.Write(fillChar);
                }
            }
            else if (direction == 2)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    Console.WriteLine(fillChar);
                }
            }
            else
            {
                Console.WriteLine("Невірний напрямок.");
            }
        }
    }
}