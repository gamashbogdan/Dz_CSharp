using System.Text;
namespace Dz_na_30._10_Part_One
{
    #region Zavdanua
    /*
    Завдання 1:
        Створити метод розширення для класу String, який буде перевіряти чи рядок є паліндром.

    Завдання 2:
        Створити метод розширення для класу String,
        який буде шифрувати рядок використовуючи ключ (передається в параметри).
        Шифрування відбувається шляхом здвигу символа по в таблиці ASCII.
        Привіт – 3
        Сткдкф

    Завдання 3:
        Створити метод розширення для класу Array,
        який буде знаходити кількість однакових елементів в масиві.
    */
    #endregion

    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)//Завдання 1:
        {
            string cleanStr = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            int left = 0;
            int right = cleanStr.Length - 1;
            while (left < right)
            {
                if (cleanStr[left] != cleanStr[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public static string EncryptWithShift(this string str, int shift)//  Завдання 2:
        {
            StringBuilder encryptedStr = new StringBuilder();

            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char encryptedChar = (char)(((c - baseChar + shift) % 26) + baseChar);
                    encryptedStr.Append(encryptedChar);
                }
                else
                {
                    encryptedStr.Append(c);
                }
            }
            return encryptedStr.ToString();
        }
    }

    public static class ArrayExtensions
    {
        public static int CountOccurrences<T>(this T[] array, T itemToCount)//  Завдання 3:
        {
            int count = 0;
            foreach (T item in array)
            {
                if (EqualityComparer<T>.Default.Equals(item, itemToCount))
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1:
            string palindromeStr = "";
            Console.Write("\n\tEnter a word : ");
            palindromeStr = Console.ReadLine();
            bool isPalindrome = palindromeStr.IsPalindrome();
            // результат
            Console.WriteLine($"IsPalindrome : {isPalindrome}");

            // Завдання 2:
            string originalStr = "";
            Console.Write("\n\tEnter the words you want to encrypt : ");
            originalStr = Console.ReadLine();
            string encryptedStr = originalStr.EncryptWithShift(3);
            // результат
            Console.WriteLine($"Encrypted String : {encryptedStr}");

            //Завдання 3:
            int[] numbers = new int[20];
            for (int i = 0; i < 20; i++)
            {
                numbers[i] = Random.Shared.Next(20);
            }
            Console.Write("\n\tEnter the number you want to search in the array : ");
            int numberSearch = int.Parse(Console.ReadLine());
            int countOfTwos = numbers.CountOccurrences(numberSearch);
            // результат
            Console.WriteLine($"Count of Twos : {countOfTwos}");

        }
    }
}