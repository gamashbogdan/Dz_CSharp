namespace Dz_na_21._10
{
    #region Zavdanua
    /*
    Завдання 1:
            Розробити абстрактний клас «Геометрична Фігура» з методами:
                •	GetArea – обчислення площі
                •	GetPerimeter – обчислення периметра
            Описати похідні класи:
                	Трикутник
                	Квадрат
                	Ромб
                	Прямокутник
                	Паралелограм
                	Трапеція
                	Коло
                	Еліпс.
            Класи повинні містити характеристики певної фігури та конструктори, які їх встановлять.
            Також реалізувати клас «Складена Фігура», який буде складатися з будь-якої кількості «Геометричних фігур» (міститиме масив фігур).
            Даний клас є похідним від базового класу «Геометрична Фігура». Класі повинен містити конструктор,
            який використовуючи params прийматиме перелік фігур з який він буде складатися.
    */
    #endregion
    public abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract string Name();
    }
    public class CompoundFigure
    {
        private GeometricFigure[] figures;

        public CompoundFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }
        public void PrintInfo()
        {
            foreach (var figure in figures)
            {
                Console.WriteLine($"\n------- Name Figure {figure.Name()}---------");
                Console.WriteLine($"Area :: {figure.GetArea()}");
                Console.WriteLine($"Perimeter :: {figure.GetPerimeter()}\n\n\n");
            }
        }
    }
    #region Triangle
    public class Triangle : GeometricFigure
    {
        private string name = "Triangle";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Triangle() : this(0.0, 0.0, 0.0) { }
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public override double GetArea()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
        public override string Name()
        {
            return name;
        }
    }
    #endregion
    #region Square
    public class Square : GeometricFigure
    {
        private string name = "Square";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double d;

        public double D
        {
            get { return d; }
            set
            {
                if (value >= 0)
                    d = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Square()
        {
            A = 0.0;
            B = 0.0;
            C = 0.0;
            D = 0.0;
        }
        public Square(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override double GetArea()
        {
            return A * A;
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
        public override string Name()
        {
            return name;
        }
    }

    #endregion
    #region Rhombus
    public class Rhombus : GeometricFigure
    {
        private string name = "Rhombus";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double d;

        public double D
        {
            get { return d; }
            set
            {
                if (value >= 0)
                    d = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Rhombus()
        {
            A = 0.0;
            B = 0.0;
            C = 0.0;
            D = 0.0;
        }
        public Rhombus(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override double GetArea()
        {
            return A * A * Math.Sin(Math.PI / 3);
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
        public override string Name()
        {
            return name;
        }

    }
    #endregion
    #region Rectangle
    public class Rectangle : GeometricFigure
    {
        private string name = "Rectangle";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double d;

        public double D
        {
            get { return d; }
            set
            {
                if (value >= 0)
                    d = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Rectangle()
        {
            A = 0.0;
            B = 0.0;
            C = 0.0;
            D = 0.0;
        }
        public Rectangle(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override double GetArea()
        {
            return A * B;
        }

        public override double GetPerimeter()
        {
            return 2 * (A + B + C + D);
        }
        public override string Name()
        {
            return name;
        }
    }
    #endregion
    #region Parallelogram
    public class Parallelogram : GeometricFigure
    {
        private string name = "Parallelogram";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double d;

        public double D
        {
            get { return d; }
            set
            {
                if (value >= 0)
                    d = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double angle;

        public double Angle
        {
            get { return angle; }
            set
            {
                if (value >= 0)
                    angle = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Parallelogram()
        {
            A = 0.0;
            B = 0.0;
            C = 0.0;
            D = 0.0;
            angle = 0.0;
        }
        public Parallelogram(double a, double b, double c, double d, double angle)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            Angle = angle;
        }
        public override double GetArea()
        {
            return Math.Abs(A * B * Math.Sin(Angle)); // Площа паралелограма: |A * B * sin(кут між A та B)|
        }

        public override double GetPerimeter()
        {
            return A + B + C + D;
        }
        public override string Name()
        {
            return name;
        }
    }
    #endregion
    #region Trapezium
    public class Trapezium : GeometricFigure
    {
        private string name = "Trapezium";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double c;

        public double C
        {
            get { return c; }
            set
            {
                if (value >= 0)
                    c = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double d;

        public double D
        {
            get { return d; }
            set
            {
                if (value >= 0)
                    d = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double angle;

        public double Angle
        {
            get { return angle; }
            set
            {
                if (value >= 0)
                    angle = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Trapezium()
        {
            A = 0.0;
            B = 0.0;
            C = 0.0;
            D = 0.0;
            angle = 0.0;
        }
        public Trapezium(double a, double b, double c, double d, double angle)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            Angle = angle;
        }
        public override double GetArea()
        {
            double h = Math.Abs(A - C) * Math.Sin(Angle);
            return 0.5 * (A + C) * h;
        }

        public override double GetPerimeter()
        {
            return A + B + C + D;
        }
        public override string Name()
        {
            return name;
        }
    }
    #endregion
    #region Circle
    public class Circle : GeometricFigure
    {
        private string name = "Circle";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Circle()
        {
            A = 0.0;
        }
        public Circle(double a)
        {
            A = a;
        }
        public override double GetArea()
        {
            double radius = A / 2;
            return Math.PI * radius * radius;
        }

        public override double GetPerimeter()
        {
            double radius = A / 2;
            return 2 * Math.PI * radius;
        }
        public override string Name()
        {
            return name;
        }

    }

    #endregion
    #region Ellipse
    public class Ellipse : GeometricFigure
    {
        private string name = "Ellipse";
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value >= 0)
                    a = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }
        private double b;

        public double B
        {
            get { return b; }
            set
            {
                if (value >= 0)
                    b = value;
                else
                    throw new Exception("Value is less than zero :( ");
            }
        }

        public Ellipse()
        {
            A = 0.0;
            B = 0.0;
        }
        public Ellipse(double a, double b)
        {
            A = a;
            B = b;
        }
        public override double GetArea()
        {
            return Math.PI * A * B;
        }

        public override double GetPerimeter()
        {
            double h = ((A - B) * (A - B)) / ((A + B) * (A + B));
            return Math.PI * (A + B) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
        }

        public override string Name()
        {
            return name;
        }
    }
    #endregion
    class Program
    {
        static void Main()
        {
            var triangle = new Triangle(3, 4, 5);
            var square = new Square(5, 3, 2, 3);
            var rhombus = new Rhombus(1, 14, 1, 14);
            var rectangle = new Rectangle(21, 13, 31, 13);
            var parallelogram = new Parallelogram(21, 15, 21, 15, 6);
            var trapezium = new Trapezium(21, 15, 21, 15, 6);
            var circle = new Circle(41);
            var ellipse = new Ellipse(31, 41);
            var compoundFigure = new CompoundFigure(triangle, square, rhombus, rectangle, parallelogram, trapezium, circle, ellipse);
            compoundFigure.PrintInfo();
        }
    }

}
