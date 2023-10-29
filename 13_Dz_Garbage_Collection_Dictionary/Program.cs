using System.Text;
namespace Dz_na_02._11
{
    #region Zavdanua
    /*
     Завдання 1:
        Реалізувати клас PhoneBook на базі дженерік колекції 
        Dictionary<TKey, TValue>, 
        передбачити додавання, зміну, пошук та видалення записів.

     Завдання 2***. Програма «Статистика»
        Підрахувати, скільки разів кожне слово зустрічається у заданому
        текстi. Результат записати до колекції Dictionary<
        TKey, TValue>. Текс використовувати із додатка 1.
        Вивести статистику за текстом у вигляді таблиці (рис. 1).
     Додаток 1.
        Ось будинок, який збудував Джек. А це пшениця, яка
        у темній коморі зберігається у будинку, який збудував
        Джек. А це веселий птах-синиця, який часто краде
        пшеницю, яка в темній коморі зберігається у будинку,
        який збудував Джек.
     */
    #endregion

    #region Phone Book
    class PhoneBook// завдання 1
    {
        Dictionary<string, string> phoneNumbers;
        public PhoneBook()
        {
            phoneNumbers = new Dictionary<string, string>();
        }
        public void AddNewContact(string phone, string name)
        {
            try
            {
                phoneNumbers.Add(phone, name);
            }
            catch (Exception)
            {
                Console.WriteLine("this contact is exists");
            }
        }
        public void Change(string Key, string newValue)
        {
            if (phoneNumbers.ContainsKey(Key))
                phoneNumbers[Key] = newValue;
            else
                Console.WriteLine("Incorrectly entered phone number :D");
        }
        public void Search(string phone)                                                                                                 // :D
        {
            if (phoneNumbers.ContainsKey(phone))
                Console.WriteLine(phoneNumbers[phone]);
            else
                Console.WriteLine("There is no such number :(");
        }
        public void Remove(string Key)
        {
            phoneNumbers.Remove(Key);
        }
        public void ShowAll()
        {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\tList of all phone numbers :D \n");
            foreach (var phone in phoneNumbers)
            {
                Console.WriteLine($"\tKey : {phone.Key},  Value : {phone.Value}");
            }
            Console.WriteLine("\n");
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // завдання 1
            #region Zavdanua 1
            PhoneBook PB = new PhoneBook();
            PB.AddNewContact("1234567890", "Ivan");
            PB.AddNewContact("0987654321", "Ola");
            PB.AddNewContact("0912837465", "Roman");
            PB.AddNewContact("56248723423", "Kata");
            PB.AddNewContact("12267382644", "GORD");
            PB.AddNewContact("0968784322", "Bo:Dya");
            PB.ShowAll();
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("\n\n\n\t\t1 - ShowALL\n\t\t2 - AddNewContac\n\t\t3 - Change\n\t\t4 - Search\n\t\t5 - Remove\n\t\t0 - EXIT");
                Console.Write("\t\t\tYour choice : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PB.ShowAll();
                        break;
                    case 2:
                        Console.Write("  Enter phone : ");
                        string phone = Console.ReadLine();
                        Console.Write("  Enter name : ");
                        string name = Console.ReadLine();
                        PB.AddNewContact(phone, name);
                        break;
                    case 3:
                        Console.Write("  Enter Key : ");
                        string key = Console.ReadLine();
                        Console.Write("  Enter new value : ");
                        string newValue = Console.ReadLine();
                        PB.Change(key, newValue);
                        break;
                    case 4:
                        Console.Write("  Enter phone : ");
                        string searchPhone = Console.ReadLine();
                        PB.Search(searchPhone);
                        break;
                    case 5:
                        Console.Write("  Enter Key : ");
                        string deleteByKey = Console.ReadLine();
                        PB.Remove(deleteByKey);
                        break;
                }
            }
            #endregion
            // завдання 2
            #region Zavdanua 2
            string word = "Ось будинок, який збудував Джек. А це пшениця, яка у темній коморі зберігається у будинку, який збудував Джек. А це веселий птах-синиця, який часто краде пшеницю, яка в темній коморі зберігається у будинку, який збудував Джек.";
            Dictionary<string, int> wordCounter = new Dictionary<string, int>();
            string[] words = word.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (wordCounter.ContainsKey(words[i]))
                    wordCounter[words[i]]++;
                else
                    wordCounter.Add(words[i], 1);
            }
            int uniqueWords = 0;
            Console.WriteLine("\t\t     Слово                Число");
            foreach (var item in wordCounter)
            {
                Console.WriteLine($" {item.Key,20}                    {item.Value}");
                if (item.Value == 1)
                    ++uniqueWords;
            }
            Console.Write($"Всього слів : {words.Length} із них унікальні : {uniqueWords}\n");

            #endregion

        }
    }
}