namespace Dz_na_28._10
{
    #region Zavdanua
    /*
        Написати програму для виконання операцій з одновимірним масивом за допомогою делегатів. Користувачу надається наступне меню для вибору типа операції з масивом:
             1.	    обчислення значення
             2.	    зміна масиву
        Якщо користувач вибрав 1-й тип, вивести підменю вибору операції:
        1-й тип:
             i.	    Обчислити кількість негативних елементів
             ii.	Визначити суму всіх елементів
             iii.	*Обрахувати кількість простих чисел
        2-й тип:
            i.	    Змінити всі негативні елементи на 0
            ii.	    Відсортувати масив
            iii.	*Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.
        Створити вказані вище методи та реалізувати вибір користувачем операції на виконання без використання конструкцій if, switch та ?:(тернарного) оператора. 
        Методи першого типу повинні повертати результат обчислення, в той час методи другого типу – void.
        Реалізувати валідацію вибраного номера операції.
    */
    #endregion
    public delegate int IntDelegate();// делегат який в собі зберігає адресу функції яку в подальшому можна викликати завдяки цому делегату
    public delegate void VoidDelegate();// цей такій самий :D ( тілький тип повернення void )
    public delegate void ChoiceVoidDelegate();// цей теж void :D
    #region Array
    class Array
    {
        int[] array = new int[7] { 1, 2, 3, 3 - 1, -1, -2, -3 };// 
        #region Stage_1
        public int NegativeNumbers()// шукає в масиві негативні єлементи (які менше нуля)
        {
            int a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    a++;
                }

            }
            return a;
        }
        public int SumNumber()// рахує суму усіх елементів у масиві
        {
            return array.Sum();
        }
        public int EasyNumbers()// шукає в масиві прості числа
        {
            int a = 0;
            for (int i = 2; i <= array.Length / 2; i++)
            {
                if (array[i] % i == 0)
                {
                    a++;
                }
            }
            return a;
        }
        #endregion
        #region Stage_2
        public void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public void ChangingNegativeNumbers()// змінює усі прості числа в масиві на нуль
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = 0;
                }
            }
            Console.Write("\nChanging Negative Numbers : ");
            Print();
        }
        public void SortArray()// сортування масиву від меншого до більшого
        {
            System.Array.Sort(array);
            Console.Write("\nSort Array : ");
            Print();
        }
        public void MovingElementsArray()//переміщення елементів у масиві (Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                while (left < right && array[left] % 2 == 0)
                {
                    left++;
                }

                while (left < right && array[right] % 2 != 0)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
                Console.Write("\nMoving Elements Array : ");
                Print();
            }
        }
        #endregion
        #region Menu
        public void CalculationOfTheValue()
        {
            short key = 0;
            IntDelegate delegateInt = new IntDelegate(NegativeNumbers);// створення обєкта делегату та запис адреси функції для подальшого виклику цієї функції
            delegateInt += SumNumber;// додавання до масиву делегату адресу ще одну функцію
            delegateInt += EasyNumbers;// і ще одну
            Console.WriteLine("\n\n\n\t\t1 - Negative Numbers\n\t\t2 - Sum Number\n\t\t3 - Easy Numbers");
            Console.Write("\tYour choice : ");
            key = short.Parse(Console.ReadLine());
            var collection1 = delegateInt.GetInvocationList();
            Console.WriteLine("\nThe result of the function : " + (collection1[key - 1] as IntDelegate).Invoke());
        }
        public void ArrayChange()
        {
            short key = 0;
            VoidDelegate delegateInt = new VoidDelegate(ChangingNegativeNumbers);// створення обєкта делегату та запис адреси функції для подальшого виклику цієї функції
            delegateInt += SortArray;// додавання до масиву делегату адресу ще одну функцію
            delegateInt += MovingElementsArray;// і ще одну
            Console.WriteLine("\n\n\n\t\t1 - Changing Negative Numbers\n\t\t2 - Sort Array\n\t\t3 - Moving ElementsArray");
            Console.Write("\tYour choice : ");
            key = short.Parse(Console.ReadLine());
            var collection1 = delegateInt.GetInvocationList();
            collection1[key - 1].DynamicInvoke();
        }
        #endregion
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array();
            short choice = -1;
            ChoiceVoidDelegate choiceVoidDelegate = new ChoiceVoidDelegate(array.CalculationOfTheValue);// створення обєкта делегату та запис адреси функції для подальшого виклику цієї функції
            choiceVoidDelegate += array.ArrayChange;// додавання до масиву делегату адресу ще одну функцію
            while (choice != 0)
            {
                Console.WriteLine("\n\n\n\n\t\t1 - Calculation of the value\n\t\t2 - Array change\n\t\t0 - EXIT");
                Console.Write("\tYour choice : ");
                choice = short.Parse(Console.ReadLine());
                var collection = choiceVoidDelegate.GetInvocationList();
                collection[choice - 1].DynamicInvoke();
            }
        }
    }
}