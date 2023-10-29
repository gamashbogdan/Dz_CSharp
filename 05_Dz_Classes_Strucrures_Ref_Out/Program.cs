namespace Dz_na_14._10
{
    #region Zavdanua
    /*
     Завдання 1:
            Описати клас з ім'ям Worker, що містить наступні поля:
               •	прізвище та ініціали працівника;
               •	вік працівника;
               •	ЗП працівника;
               •	дата прийняття на роботу.
            Написати програму, що виконує наступні дії:
               1.	введення з клавіатури даних в масив, що складається з п'яти елементів типу Worker (записи повинні бути впорядковані за алфавітом);
               2.	якщо значення якогось параметру введено не в відповідному форматі - згенерувати відповідний exception.
               3.	вивід на екран прізвища працівника, стаж роботи якого перевищує введене з клавіатури значення.
            Рекомендація: перевірку формата даних та генерацію винятку виконуйте в блоці set{} для кожної властивості класа Worker. 
      Завдання 2:
            Створіть клас Calculator.
            У класі реалізувати чотири методи для арифметичних дій:
               1.	Add – додавання
               2.	Sub – віднімання
               3.	Mul – множення
               4.	Div - ділення.
            Метод ділення повинен робити перевірку ділення на нуль, якщо перевірка не проходить, згенерувати виключення.
            Користувач вводить значення, над якими хоче зробити операцію і вибирає саму операцію. При виникненні помилок повинні генеруватися виключення.
    */
    #endregion
    class Worker
    {
        private string lastNameAndInitials;
        private int age;
        private double salary;
        private DateTime employmentDate;

        public string LastNameAndInitials
        {
            get { return lastNameAndInitials; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name and initials cannot be empty.");
                }
                lastNameAndInitials = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
                }
                age = value;
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative.");
                }
                salary = value;
            }
        }

        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Employment date cannot be in the future.");
                }
                employmentDate = value;
            }
        }
        public Worker(string lastNameAndInitials, int age, double salary, DateTime employmentDate)
        {
            this.lastNameAndInitials = lastNameAndInitials;
            this.age = age;
            this.salary = salary;
            this.employmentDate = employmentDate;
        }
        public override string ToString()
        {
            return $"{LastNameAndInitials}, Age: {Age}, Salary: {Salary}, Employed on: {EmploymentDate.ToShortDateString()}";
        }
    }

    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n\n------------ zavdanua 1 ------------\n");
                Worker[] workers = new Worker[1];
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"Enter data for worker #{i + 1}:");

                    Console.Write("Last name and initials: ");
                    string LastNameAndInitials = Console.ReadLine();

                    Console.Write("Age: ");
                    int Age = int.Parse(Console.ReadLine());

                    Console.Write("Salary: ");
                    double Salary = double.Parse(Console.ReadLine());

                    Console.Write("Employment date (yyyy-MM-dd): ");
                    DateTime EmploymentDate = DateTime.Parse(Console.ReadLine());

                    workers[i] = new Worker(LastNameAndInitials, Age, Salary, EmploymentDate);
                }

                Console.Write("Enter minimum years of employment to search: ");
                int minYears = int.Parse(Console.ReadLine());

                Console.WriteLine("Workers with more than the specified years of employment:");
                foreach (var worker in workers)
                {
                    if ((DateTime.Now - worker.EmploymentDate).TotalDays > minYears * 365)
                    {
                        Console.WriteLine(worker.ToString());
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument error: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            try
            {
                Console.WriteLine("\n\n\n------------ zavdanua 2 ------------\n");
                Calculator calculator = new Calculator();
                Console.WriteLine("Select operation: 1 - Addition, 2 - Subtraction, 3 - Multiplication, 4 - Division");
                int operation = int.Parse(Console.ReadLine());

                Console.Write("Enter the first number: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                double b = double.Parse(Console.ReadLine());
                double result = 0;
                switch (operation)
                {
                    case 1:
                        result = calculator.Add(a, b);
                        break;
                    case 2:
                        result = calculator.Sub(a, b);
                        break;
                    case 3:
                        result = calculator.Mul(a, b);
                        break;
                    case 4:
                        result = calculator.Div(a, b);
                        break;
                    default:
                        Console.WriteLine("Invalid operation selected.");
                        break;
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Division by zero error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
