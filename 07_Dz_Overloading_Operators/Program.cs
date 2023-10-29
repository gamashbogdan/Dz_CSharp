namespace Dz_na_19._10
{
    #region Zavdanua
    /*
     Завдання:
            Створити два класи, які будуть описувати фігуру:
                •	Square. Містить властивість A - довжина сторони квадрату.
                •	Rectangle. Містить властивості A, B - довжина сторін прямокутника.
            Написати для класів конструктор по замовчуванню та параметризований, перевизначити метод ToString та перевантажити наступні оператори:
                •	(++ --) - оператори змінюють розмір кожної з сторін на одиницю відповідно
                •	(+ - * /) - оператори створюють нову фігуру зробивши відповідну операцію з кожною зі сторін.
                    Перевіряйте, щоб сторона не була від'ємною.
                •	(< > <= >= == !=) - оператори порівнюють відповідні фігури по розмірам сторін.
                    Для операторів рівності перевизначте базовий метод Equals в парі з методом GetHashCode.
                •	(true false) - умовою істиності фігури є перевірка чи розміри сторін відмінні від нуля.
            Також перевизначити оператори приведення типу в наступних варіантах:
                •	неявне приведення (implicit) квадрату до прямокутника
                •	явне приведення (explicit) прямокутника до квадрату
                •	неявне приведення квадрату до типу int
                •	явне приведення прямокутника до типу int
    */
    #endregion
    class Square
    {
        public int a { get; set; }
        public Square() : this(0) { }

        public Square(int a)
        {
            this.a = a;
        }

        public override string ToString()
        {
            return $"Square A : {a}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   a == square.a;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a);
        }

        public static Square operator -(Square p)
        {
            Square p1 = new Square
            {
                a = p.a * -1,
            };
            return p1;
        }
        public static Square operator ++(Square p)
        {
            p.a++;
            return p;
        }
        public static Square operator --(Square p)
        {
            p.a--;
            return p;
        }

        #region Bynary Operators
        public static Square operator +(Square p1, Square p2)
        {
            Square p3 = new Square
            {
                a = p1.a + p2.a,
            };
            return p3;
        }
        public static Square operator -(Square p1, Square p2)
        {
            Square p3 = new Square
            {
                a = p1.a - p2.a,
            };
            return p3;
        }
        public static Square operator *(Square p1, Square p2)
        {
            Square p3 = new Square
            {
                a = p1.a * p2.a,
            };
            return p3;
        }
        public static Square operator /(Square p1, Square p2)
        {
            Square p3 = new Square
            {
                a = p1.a / p2.a,
            };
            return p3;
        }
        public static bool operator ==(Square p1, Square p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Square p1, Square p2)
        {
            return !(p1 == p2);
        }
        public static bool operator >(Square p1, Square p2)
        {
            return p1.a > p2.a;
        }
        public static bool operator <(Square p1, Square p2)
        {
            return !(p1 > p2);
        }
        public static bool operator >=(Square p1, Square p2)
        {
            return p1.a >= p2.a;
        }
        public static bool operator <=(Square p1, Square p2)
        {
            return !(p1 >= p2);
        }
        public static bool operator true(Square p)
        {
            return (p.a != 0) || (p.a != 0);
        }
        public static bool operator false(Square p)
        {
            return (p.a == 0) && (p.a == 0);
        }
        #endregion

        #region Overload Types
        public static implicit operator int(Square p)
        {
            return p.a;
        }
        public static implicit operator double(Square p)
        {
            return p.a;
        }
        public static explicit operator Rectangle(Square p)
        {
            return new Rectangle(p.a, p.a);
        }
        #endregion

    }


    class Rectangle
    {
        public int a { get; set; }
        public int b { get; set; }
        public Rectangle() : this(0, 0) { }

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override string ToString()
        {
            return $"Rectangle A : {a} , B : {b}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   a == rectangle.a &&
                   b == rectangle.b;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b);
        }

        public static Rectangle operator -(Rectangle p)
        {
            Rectangle p1 = new Rectangle
            {
                a = p.a * -1,
                b = p.b * -1
            };
            return p1;
        }
        public static Rectangle operator ++(Rectangle p)
        {
            p.a++;
            p.b++;
            return p;
        }
        public static Rectangle operator --(Rectangle p)
        {
            p.a--;
            p.b--;
            return p;
        }

        #region Bynary Operators
        public static Rectangle operator +(Rectangle p1, Rectangle p2)
        {
            Rectangle p3 = new Rectangle
            {
                a = p1.a + p2.a,
                b = p1.b + p2.b
            };
            return p3;
        }
        public static Rectangle operator -(Rectangle p1, Rectangle p2)
        {
            Rectangle p3 = new Rectangle
            {
                a = p1.a - p2.a,
                b = p1.b - p2.b
            };
            return p3;
        }
        public static Rectangle operator *(Rectangle p1, Rectangle p2)
        {
            Rectangle p3 = new Rectangle
            {
                a = p1.a * p2.a,
                b = p1.b * p2.b
            };
            return p3;
        }
        public static Rectangle operator /(Rectangle p1, Rectangle p2)
        {
            Rectangle p3 = new Rectangle
            {
                a = p1.a / p2.a,
                b = p1.b / p2.b
            };
            return p3;
        }
        #endregion

        #region Logic Operators
        public static bool operator ==(Rectangle p1, Rectangle p2)
        {

            return p1.Equals(p2);
        }
        public static bool operator !=(Rectangle p1, Rectangle p2)
        {
            return !(p1 == p2);
        }
        public static bool operator >(Rectangle p1, Rectangle p2)
        {
            return p1.a + p1.b > p2.a + p2.b;
        }
        public static bool operator <(Rectangle p1, Rectangle p2)
        {
            return !(p1 > p2);
        }
        public static bool operator >=(Rectangle p1, Rectangle p2)
        {
            return p1.a + p1.b >= p2.a + p2.b;
        }
        public static bool operator <=(Rectangle p1, Rectangle p2)
        {
            return !(p1 >= p2);
        }
        #endregion

        #region true/false operators
        public static bool operator true(Rectangle p)
        {
            return (p.a != 0) || (p.b != 0);
        }
        public static bool operator false(Rectangle p)
        {
            return (p.a == 0) && (p.b == 0);
        }
        #endregion

        #region Overload Types
        public static implicit operator int(Rectangle p)
        {
            return p.a + p.b;
        }
        public static implicit operator double(Rectangle p)
        {
            return p.a + p.b;
        }
        public static explicit operator Square(Rectangle p)
        {
            return new Square(p.a);
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Square square1 = new Square(5);
            Square square2 = new Square(3);

            Console.WriteLine("Square 1: " + square1);
            Console.WriteLine("Square 2: " + square2);

            Console.WriteLine("Incrementing side of Square 1...");
            ++square1;
            Console.WriteLine("Square 1 after increment: " + square1);

            Console.WriteLine("Decrementing side of Square 2...");
            --square2;
            Console.WriteLine("Square 2 after decrement: " + square2);

            Console.WriteLine("Adding Square 1 and Square 2...");
            Square sumSquare = square1 + square2;
            Console.WriteLine("Sum of Square 1 and Square 2: " + sumSquare);

            Console.WriteLine("Subtracting Square 1 from Square 2...");
            Square diffSquare = square2 - square1;
            Console.WriteLine("Difference between Square 2 and Square 1: " + diffSquare);

            Console.WriteLine("Multiplying Square 1 and Square 2...");
            Square multSquare = square1 * square2;
            Console.WriteLine("Multiplication of Square 1 and Square 2: " + multSquare);

            Console.WriteLine("Dividing Square 1 by Square 2...");
            Square divSquare = square1 / square2;
            Console.WriteLine("Division of Square 1 by Square 2: " + divSquare);

            Console.WriteLine("Comparing Square 1 and Square 2...");
            Console.WriteLine("Square 1 > Square 2: " + (square1 > square2));
            Console.WriteLine("Square 1 < Square 2: " + (square1 < square2));
            Console.WriteLine("Square 1 >= Square 2: " + (square1 >= square2));
            Console.WriteLine("Square 1 <= Square 2: " + (square1 <= square2));
            Console.WriteLine("Square 1 == Square 2: " + (square1 == square2));
            Console.WriteLine("Square 1 != Square 2: " + (square1 != square2));

            Console.WriteLine("Is Square 1 true? " + (square1 ? "Yes" : "No"));
            Console.WriteLine("Is Square 2 true? " + (square2 ? "Yes" : "No"));

            Rectangle rectangle1 = (Rectangle)square1;
            Console.WriteLine("Implicitly converting Square 1 to Rectangle: " + rectangle1);

            Square square3 = (Square)rectangle1;
            Console.WriteLine("Explicitly converting Rectangle to Square: " + square3);

            int sideLength = (int)square1;
            Console.WriteLine("Implicitly converting Square 1 to int: " + sideLength);

            int area = (int)rectangle1;
            Console.WriteLine("Explicitly converting Rectangle to int: " + area);

        }
    }
}