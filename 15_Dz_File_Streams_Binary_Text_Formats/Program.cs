namespace Dz_na_06._11
{
    #region Zavdanua
    /*
    Завдання 1:
            Додаток дозволяє користувачеві переглядати вміст файлу.
            Користувач вводить шлях до файлу. Якщо файл існує, його вміст
            відображається на екрані.Якщо файл не існує, виведіть
            повідомлення про помилку.
    Завдання 2:
            Користувач вводить значення елементів масиву з клавіатури.
            Додаток надає можливість зберігати вміст масиву у файл.
    Завдання 3:
            Додайте до другого завдання можливість завантажувати масив
            із файлу.
    Завдання 4:
            Додаток генерує випадковим чином 10000 цілих чисел.
            Збережіть парні числа в один файл, непарні – в інший. За
            підсумками роботи додатка потрібно відобразити статистику на
            екрані.
    Завдання 5:
            Додаток надає користувачеві можливість пошуку по файлу:
             Пошук заданого слова.Додаток показує, чи знайдено слово.
            Крім того, відображається інформація про те, де знайдено
            збіг.
             Пошук кількості входження слова у файл. Додаток
            відображає кількість знайденого слова.
             Пошук заданого слова у зворотному порядку. Наприклад,
            користувач шукає слово «moon». Це означає, що додаток
            шукає слово «moon» у зворотному напрямку: «noom». За
            результатами пошуку, додаток відображає кількість
            входжень.
    Завдання 6:
            Користувач вводить шлях до файлу.Додаток відображає
            статистичну інформацію про файл:
             кількість речень;
             кількість великих літер;
             кількість маленьких літер;
             кількість голосних літер;
             кількість приголосних літер;
             кількість цифр.
    */
    #endregion
    class FileViewer
    {
        public void DisplayFileContent(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("Завдання 1: Відображення вмісту файлу");
                    Console.WriteLine("File Content:\n" + content);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    class ArrayFileManager
    {
        public void SaveArrayToFile(string filePath, int[] array)
        {
            using (TextWriter writer = File.CreateText(filePath))
            {
                foreach (int number in array)
                {
                    writer.WriteLine(number);
                }
            }
            Console.WriteLine("Завдання 2: Збереження масиву у файл");
            Console.WriteLine("Array saved to file.");
        }

        public int[] LoadArrayFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string line;
                    var array = new System.Collections.Generic.List<int>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            array.Add(number);
                        }
                    }
                    return array.ToArray();
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                return null;
            }
        }
    }

    class NumberFileSeparator
    {
        public void SeparateNumbersToFile(string filePath, int[] numbers)
        {
            var evenNumbers = Array.FindAll(numbers, n => n % 2 == 0);
            var oddNumbers = Array.FindAll(numbers, n => n % 2 != 0);

            using (TextWriter evenWriter = File.CreateText("even_numbers.txt"))
            using (TextWriter oddWriter = File.CreateText("odd_numbers.txt"))
            {
                foreach (int number in evenNumbers)
                {
                    evenWriter.WriteLine(number);
                }
                foreach (int number in oddNumbers)
                {
                    oddWriter.WriteLine(number);
                }
            }
            Console.WriteLine("Завдання 4: Розділення чисел на парні та непарні");
            Console.WriteLine("Numbers separated and saved to files.");
        }
    }

    class TextSearcher
    {
        public bool SearchWordInFile(string filePath, string word)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string content = reader.ReadToEnd();
                    return content.Contains(word);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                return false;
            }
        }

        public int CountOccurrencesInFile(string filePath, string word)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string content = reader.ReadToEnd();
                    int count = 0;
                    int index = content.IndexOf(word);
                    while (index != -1)
                    {
                        count++;
                        index = content.IndexOf(word, index + 1);
                    }
                    return count;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                return 0;
            }
        }

        public int CountOccurrencesInReverseFile(string filePath, string word)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string content = reader.ReadToEnd();
                    string reversedWord = new string(word.Reverse().ToArray());
                    int count = 0;
                    int index = content.IndexOf(reversedWord);
                    while (index != -1)
                    {
                        count++;
                        index = content.IndexOf(reversedWord, index + 1);
                    }
                    return count;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                return 0;
            }
        }
    }

    class FileStatistics
    {
        public void DisplayFileStatistics(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    string content = reader.ReadToEnd();
                    int sentenceCount = content.Split('.', '!', '?').Length - 1;
                    int upperCaseCount = content.Count(char.IsUpper);
                    int lowerCaseCount = content.Count(char.IsLower);
                    int vowelCount = content.Count(c => "AEIOUaeiou".Contains(c));
                    int consonantCount = content.Count(c => char.IsLetter(c) && !"AEIOUaeiou".Contains(c));
                    int digitCount = content.Count(char.IsDigit);

                    Console.WriteLine("Завдання 6: Відображення статистики про файл");
                    Console.WriteLine("File Statistics:");
                    Console.WriteLine($"Sentence Count: {sentenceCount}");
                    Console.WriteLine($"Uppercase Letters Count: {upperCaseCount}");
                    Console.WriteLine($"Lowercase Letters Count: {lowerCaseCount}");
                    Console.WriteLine($"Vowel Count: {vowelCount}");
                    Console.WriteLine($"Consonant Count: {consonantCount}");
                    Console.WriteLine($"Digit Count: {digitCount}");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1: Відображення вмісту файлу
            FileViewer fileViewer = new FileViewer();
            fileViewer.DisplayFileContent(@"C:\Users\helen\Desktop\example.txt");

            // Завдання 2: Збереження масиву у файл
            int[] array = { 1, 2, 3, 4, 5 };
            ArrayFileManager arrayManager = new ArrayFileManager();
            arrayManager.SaveArrayToFile(@"C:\Users\helen\Desktop\array.txt", array);

            // Завдання 3: Завантаження масиву із файлу
            int[] loadedArray = arrayManager.LoadArrayFromFile(@"C:\Users\helen\Desktop\array.txt");
            if (loadedArray != null)
            {
                Console.WriteLine("Завдання 3: Завантаження масиву із файлу");
                Console.WriteLine("Loaded Array: " + string.Join(", ", loadedArray));
            }

            // Завдання 4: Розділення чисел на парні та непарні
            int[] randomNumbers = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = rand.Next(1, 10001);
            }
            NumberFileSeparator numberSeparator = new NumberFileSeparator();
            numberSeparator.SeparateNumbersToFile(@"C:\Users\helen\Desktop\numbers.txt", randomNumbers);

            // Завдання 5: Пошук слів у файлі
            TextSearcher textSearcher = new TextSearcher();
            bool wordFound = textSearcher.SearchWordInFile(@"C:\Users\helen\Desktop\example.txt", "search");
            if (wordFound)
            {
                Console.WriteLine("Завдання 5: Пошук заданого слова");
                Console.WriteLine("Word found in the file.");
            }

            int wordCount = textSearcher.CountOccurrencesInFile(@"C:\Users\helen\Desktop\example.txt", "word");
            Console.WriteLine("Завдання 5: Пошук кількості входжень слова");
            Console.WriteLine($"Word 'word' found {wordCount} times in the file.");

            int reverseWordCount = textSearcher.CountOccurrencesInReverseFile(@"C:\Users\helen\Desktop\example.txt", "siht");
            Console.WriteLine("Завдання 5: Пошук заданого слова у зворотному порядку");
            Console.WriteLine($"Word 'siht' found {reverseWordCount} times in reverse in the file.");

            // Завдання 6: Відображення статистики про файл
            FileStatistics fileStatistics = new FileStatistics();
            fileStatistics.DisplayFileStatistics(@"C:\Users\helen\Desktop\example.txt");
        }
    }

}