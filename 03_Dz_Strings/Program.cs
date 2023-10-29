using System.Text;
namespace Dz_na_09._10
{
    #region Zavdanua
    /*
     Task 1:
            Вставити в задану позицію рядка інший рядок.
     Task 2:
            Визначити, чи є рядок паліндромом. Паліндром – це число,
            слово або фраза, яка однаково читається в обох напрямках.
     Task 3:
            Дано текст. Визначте відсоткове відношення малих і великих літер до загальної кількості символів в ньому.
     Task 4:
            Дано масив слів. Замінити останні три символи слів, що мають обрану довжину, на символ "$".
     Task 5:
            Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.
     Task 6:
            Дано рядок слів, розділених пробілами. Між словами може бути кілька пробілів,
            на початку і вкінці рядка також можуть бути пробіли. Ви повинні змінити рядок так,
            щоб на початку і вкінці пробілів не було, а слова були розділені поодиноким символом "*" (зірочка).
     Task 7:
            Користувач вводить слова, поки не буде введено слово з символом крапки вкінці.
            Сформувати з введених слів рядок, розділивши їх комою з пробілом. Застосувати StringBuilder.
    */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Task 1: Вставити в задану позицію рядка інший рядок.
            Console.WriteLine("\n\n---------- Завдання 1 ------------\n");
            string originalString = " Це початковий рядок ";
            string insertString = " ВСТАВЛЕНИЙ ";
            int position = 12;
            string result1 = InsertString(originalString, insertString, position);
            Console.WriteLine(result1); // "Це початковий вставлений рядок"

            // Task 2: Визначити, чи є рядок паліндромом.
            Console.WriteLine("\n\n---------- Завдання 2 ------------\n");
            string inputString = "мадам";
            bool isPalindrome = IsPalindrome(inputString);
            Console.WriteLine(isPalindrome); // True

            // Task 3: Визначте відсоткове відношення малих і великих літер до загальної кількості символів в тексті.
            Console.WriteLine("\n\n---------- Завдання 3 ------------\n");
            string text = "Це ТестовИЙ Текст";
            CalculateLetterPercentages(text);

            // Task 4: Замінити останні три символи слів, що мають обрану довжину, на символ "$".
            Console.WriteLine("\n\n---------- Завдання 4 ------------\n");
            string[] words = { "перший", "другий", "третій", "четвертий" };
            int targetLength = 6;
            ReplaceLastCharactersInWords(words, targetLength);

            // Task 5: Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.
            Console.WriteLine("\n\n---------- Завдання 5 ------------\n");
            string searchText = "Це є текстовий рядок для прикладу";
            int wordNumber = 3;
            GetAndPrintFirstLetterOfWord(searchText, wordNumber);

            // Task 6: Заміна пробілів між словами на '*'.
            Console.WriteLine("\n\n---------- Завдання 6 ------------\n");
            string inputText = "  слово1   слово2 слово3   ";
            string processedText = ReplaceSpacesWithAsterisks(inputText);
            Console.WriteLine(processedText);

            // Task 7: Формування рядка з введених слів з використанням StringBuilder.
            Console.WriteLine("\n\n---------- Завдання 7 ------------\n");
            string commaSeparatedWords = GetCommaSeparatedWords();
            Console.WriteLine(commaSeparatedWords);
        }

        static string InsertString(string original, string insert, int position)
        {
            if (position >= 0 && position <= original.Length)
            {
                return original.Insert(position, insert);
            }
            return original;
        }

        static bool IsPalindrome(string input)
        {
            input = input.ToLower();
            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (input[left] != input[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        static void CalculateLetterPercentages(string text)
        {
            int totalCharacters = text.Length;
            int uppercaseCount = 0;
            int lowercaseCount = 0;

            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    uppercaseCount++;
                }
                else if (char.IsLower(c))
                {
                    lowercaseCount++;
                }
            }

            double uppercasePercentage = (double)uppercaseCount / totalCharacters * 100;
            double lowercasePercentage = (double)lowercaseCount / totalCharacters * 100;

            Console.WriteLine($"Великі літери: {uppercasePercentage}%");
            Console.WriteLine($"Малі літери: {lowercasePercentage}%");
        }

        static void ReplaceLastCharactersInWords(string[] words, int targetLength)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == targetLength)
                {
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$";
                }
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void GetAndPrintFirstLetterOfWord(string text, int wordNumber)
        {
            string[] words = text.Split(' ');
            if (wordNumber >= 0 && wordNumber < words.Length)
            {
                string word = words[wordNumber];
                if (!string.IsNullOrEmpty(word))
                {
                    char firstLetter = word[0];
                    Console.WriteLine($"Перша буква слова {wordNumber + 1}: {firstLetter}");
                }
                else
                {
                    Console.WriteLine("Задане слово порожнє.");
                }
            }
            else
            {
                Console.WriteLine("Заданий номер слова виходить за межі тексту.");
            }
        }

        static string ReplaceSpacesWithAsterisks(string input)
        {
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("*", words);
        }

        static string GetCommaSeparatedWords()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Введіть слова (закінчіть введення крапкою):");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.EndsWith("."))
                {
                    break;
                }
                stringBuilder.Append(input);
                stringBuilder.Append(", ");
            }

            if (stringBuilder.Length > 0)
            {
                // Видаляємо останній кому та пробіл
                stringBuilder.Length -= 2;
            }

            return stringBuilder.ToString();
        }

    }
}