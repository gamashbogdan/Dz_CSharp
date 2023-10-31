namespace Dz_na_04._11
{
    #region Zavdanua
    /*
    Завдання 1
        Створіть generic-версію методу обчислення максимуму з трьох чисел.
    Завдання 2
        Створіть generic-версію методу обчислення мінімуму
        з трьох чисел.
    Завдання 3
        Створіть generic-версію методу пошуку суми елементів у масиві.
    Завдання 4
        Створіть generic-клас «Стек». Реалізуйте стандартні
        методи і властивості для роботи стеку:
        ■ pop;
        ■ push;
        ■ peek;
        ■ count.
    Завдання 5
        Створіть generic-клас «Черга». Реалізуйте стандартні
        методи і властивості для роботи черги:
        ■ enqueue;
        ■ dequeue;
        ■ peek;
        ■ count.

    */
    #endregion
    public class Program
    {
        #region Task 1
        // Task 1: Maximum of three numbers
        public static T FindMaximum<T>(T a, T b, T c) where T : IComparable<T>
        {

            T maximum = a;
            if (b.CompareTo(maximum) > 0)
            {
                maximum = b;
            }
            if (c.CompareTo(maximum) > 0)
            {
                maximum = c;
            }
            return maximum;
        }
        #endregion
        #region Task 2
        // Task 2: Minimum of three numbers
        public static T FindMinimum<T>(T a, T b, T c) where T : IComparable<T>
        {
            T minimum = a;
            if (b.CompareTo(minimum) < 0)
            {
                minimum = b;
            }
            if (c.CompareTo(minimum) < 0)
            {
                minimum = c;
            }
            return minimum;
        }
        #endregion
        #region Task 3
        // Task 3: Sum of elements in an array
        public static T FindSum<T>(T[] array) where T : IConvertible
        {
            dynamic sum = default(T);
            foreach (T element in array)
            {
                sum += element;
            }
            return sum;
        }
        #endregion
        static void Main()
        {
            // Task 1: Maximum of three numbers
            int number1 = 10;
            int number2 = 20;
            int number3 = 15;

            int max = FindMaximum(number1, number2, number3);

            Console.WriteLine("Task 1 (Maximum): " + max);

            // Task 2: Minimum of three numbers
            int min = FindMinimum(number1, number2, number3);

            Console.WriteLine("Task 2 (Minimum): " + min);

            // Task 3: Sum of elements in an array
            int[] numbers = { 1, 2, 3, 4, 5 };
            int sum = FindSum(numbers);

            Console.WriteLine("Task 3 (Sum): " + sum);

            //Task 4: Generic Stack
            Stack<int> stack = new Stack<int>(3);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Task 4 (Stack):");
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Peek: " + stack.Peek());
            Console.WriteLine("Count: " + stack.Count);

            // Task 5: Generic Queue
            QueueFunction<string> queue = new QueueFunction<string>();

            queue.Enqueue("Element 1");
            queue.Enqueue("Element 2");
            queue.Enqueue("Element 3");

            Console.WriteLine("Task 5 (Queue):");
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Peek: " + queue.Peek());
            Console.WriteLine("Count: " + queue.Count);
        }

    }
    #region Task 4
    // Task 4: Generic Stack class
    public class Stack<T>
    {
        T[] arr;
        public Stack(int size)
        {
            arr = new T[size];
        }
        private List<T> elements = new List<T>();
        public void Push(T value)
        {
            elements.Add(value);
        }
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            T last = elements[Count - 1];
            elements.RemoveAt(Count - 1);
            return last;
        }
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return elements[Count - 1];
        }
        public int Count
        {
            get { return elements.Count; }
        }
    }
    #endregion
    #region Task 5
    // Task 5: Generic Queue class
    public class QueueFunction<T>
    {
        private List<T> elements = new List<T>();
        public void Enqueue(T value)
        {
            elements.Add(value);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T last = elements[0];
            elements.RemoveAt(0);
            return last;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return elements[0];
        }

        public int Count
        {
            get { return elements.Count; }
        }
    }
    #endregion


}