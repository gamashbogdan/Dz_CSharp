using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters.Binary;
namespace Dz_na_09._11
{
    #region Zavdanua
    /*
                        “Форма реєстрації Форум”
            1. Реалізувати додаток з наступним функціоналом:
                a)Консольне меню
                b)В якості колекції для даних використати Словник
                (Dictionary<TKey, TValue>), який реалізує CRUD
                c) Значущими елементами словника є екземпляри класу User
            2. Класс User повинен містити наступні властивості:
                a) Id - int унікальні значення в діапазоні 1000 - 9999
                b) Login - string, лише друємі символи без спец сиволів
                c) Password - string, лише друємі символи без спец сиволів,
                довжина не менше 8ми сиволів,
                d) ConfirmPassword - string, лише друємі символи без спец
                сиволів, довжина не менше 8ми сиволів,
                e) E-mail - string, валідація згідно загальних правил
                стандарту
                f) CreditCard - валідація згідно загальних правил стандарту
                g)Phone - валідація згідно українського формату +38-0**-***-**-**
            3. Всі властивості містять відповідні атрибути валідації, з
                перевизначиними повідомленнями, згідно яких модель після
                перевірки записується в словник.Якщо якісь властивості не
                проходять валідацію - користувач змушений ввести їх
                повторно.
            4. Після вибору відповідного пункту меню екземпляр словника
                серіалізується і зберігається у файл. (робиться резервна копія)
            5. Після вибору відповідного пунктуц меню дані з файлу
                читаються і десеріалізуються переписуючи поточний
                екземпляр.
            Bonus 12: при десеріалізації даних вмісти 2ох словників
            порівнюються і користувачеві пропонується наступні дії:
                1. Переписати весь вміст
                2. Дописати в пам”ять лише ті дані Користувачів яких там
                не вистачає (якщо такі є). Якщо користувач є в пам”яті в
                файлі, користувач може вибрати ячку версію даних прийняти
            а яку відкинути.
    */
    #endregion

    [Serializable]
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Login not set")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Login should only contain letters")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password not set")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password should only contain letters and numbers")]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password not set")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email not set")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [RegularExpression(@"^\+38-0\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid credit card number format")]
        public string CreditCard { get; set; }
    }
    [Serializable]
    class Program
    {
        static Dictionary<int, User> users = new Dictionary<int, User>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Forum Registration Form");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Register a new user");
                Console.WriteLine("2. Serialize and save user data");
                Console.WriteLine("3. Deserialize and load user data");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        SerializeAndSaveUserData();
                        break;
                    case 3:
                        DeserializeAndLoadUserData();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            User newUser = new User();
            bool isValid = true;

            do
            {
                Console.WriteLine("Enter Login:");
                newUser.Login = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                newUser.Password = Console.ReadLine();

                Console.WriteLine("Confirm Password:");
                newUser.ConfirmPassword = Console.ReadLine();

                Console.WriteLine("Enter Email:");
                newUser.Email = Console.ReadLine();

                Console.WriteLine("Enter Phone (e.g., +38-0**-***-**-**):");
                newUser.Phone = Console.ReadLine();

                Console.WriteLine("Enter Credit Card (16 digits):");
                newUser.CreditCard = Console.ReadLine();

                var result = new List<ValidationResult>();
                var context = new ValidationContext(newUser);

                if (!(isValid = Validator.TryValidateObject(newUser, context, result, false)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!isValid);

            // Generate a unique Id and add the user to the dictionary
            newUser.Id = GenerateUniqueId();
            users.Add(newUser.Id, newUser);

            Console.WriteLine("User registered successfully.");
        }

        static int GenerateUniqueId()
        {
            Random random = new Random();
            int id;

            do
            {
                id = random.Next(1000, 10000);
            } while (users.ContainsKey(id));

            return id;
        }

        static void SerializeAndSaveUserData()
        {
            // Серіалізація та збереження даних користувачів в файл
            if (users.Count > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream fs = File.Create("user_data.bin"))
                {
                    formatter.Serialize(fs, users);
                }
                Console.WriteLine("User data has been serialized and saved.");
            }
            else
            {
                Console.WriteLine("No user data to save.");
            }

        }

        static void DeserializeAndLoadUserData()
        {
            if (File.Exists("user_data.bin"))
            {
                // Десеріалізація та завантаження даних користувачів з файлу
                BinaryFormatter formatter = new BinaryFormatter();
                Dictionary<int, User> loadUsers = null;
                using (Stream fs = File.OpenRead("user_data.bin"))
                {
                    loadUsers = (Dictionary<int, User>)formatter.Deserialize(fs);
                }
                foreach (var item in loadUsers)
                {
                    Console.WriteLine($"User ID: {item.Key}");
                    Console.WriteLine($"Login: {item.Value.Login}");
                    Console.WriteLine($"Password: {item.Value.Password}");
                    Console.WriteLine($"Confirm Password: {item.Value.ConfirmPassword}");
                    Console.WriteLine($"Email: {item.Value.Email}");
                    Console.WriteLine($"Phone: {item.Value.Phone}");
                    Console.WriteLine($"Credit Card: {item.Value.CreditCard}");
                    Console.WriteLine();
                }


                Console.WriteLine("User data has been deserialized and loaded.");
            }
            else
            {
                Console.WriteLine("User data file not found.");
            }
        }
    }
}
