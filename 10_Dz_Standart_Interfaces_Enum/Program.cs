using System.Collections;
namespace Dz_na_26._10
{
    #region Zavdanua
    /*
        Завдання 1:
        Створити клас «Cinema», який має колекцію фільмів та методи для їх сортування.Клас імплементує інтерфейс IEnumerable та дозволяє сортувати колекцію по різним критеріям, приймаючи в метод сортування IComparer, який описує алгоритм порівняння.
        Кожний фільм описуєтся класом «Movie», який містить параметри:
            •	Назва
            •	Опис
            •	Режисер - окремий клас з певними властивостями та інтерфейсом ICloneable
            •	Країна
            •	Жанр - enum
            •	Рік
            •	Рейтинг і тд.
        Клас повинен реалізовувати інтерфейс IComparable та ICloneable.
        Для всіх класів потрібно перевизначити метод ToString(), який повертає основну інформацію про об'єкт.
        Приблизна діаграма класів наведена на наступній стор.
    */
    #endregion
    #region Director
    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
    #endregion
    enum Genre
    {
        Comedy, Horror, Adventure, Drama
    }
    #region Movie
    class Movie : IComparable<Movie>, ICloneable //IComparable
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public object Clone()
        {
            Movie clone = (Movie)this.MemberwiseClone();
            clone.Director = (Director)this.Director.Clone();
            return clone;
        }

        public int CompareTo(Movie? other)// сортування по Title
        {
            return Title.CompareTo(other.Title);
        }
        public override string ToString()
        {
            return $"Title : {Title}\nDirector : {Director}\nCountry : {Country}" +
                $"\nGenre : {Genre}\nYear : {Year}\nRating : {Rating}\n";
        }

    }

    #endregion
    #region Cinema
    class Cinema
    {
        Movie[] movies =
        {
            new Movie
            {
                 Title="The Godfather",
                 Director =new Director{FirstName= "Francis", LastName="Ford"},
                   Country="USA",
                 Genre= Genre.Drama,
                 Year=1972,
                Rating=9.2
            },
            new Movie
            {
                 Title="12 Angry Men",
                 Director =new Director{FirstName= "Sidney", LastName="Lumet"},
                   Country="USA",
                 Genre= Genre.Drama,
                 Year=1957,
                Rating= 9.0
            }
            /*
            new Movie
            {
                 Title="Schindler's List",
                 Director =new Director{FirstName= "Steven", LastName="Spielberg"},
                   Country="American",
                 Genre= Genre.Drama,
                 Year=1993,
                Rating=8.9
            },
            new Movie
            {
                 Title="Inception",
                 Director =new Director{FirstName= "Christopher", LastName="Nolan"},
                   Country="USA",
                 Genre= Genre.Adventure,
                 Year=2010,
                Rating=8.7
            },
            new Movie
            {
                 Title="Fight Club",
                 Director =new Director{FirstName= "David", LastName="Fincher"},
                   Country="USA",
                 Genre= Genre.Drama,
                 Year=1999,
                Rating=8.7
            },
            new Movie
            {
                 Title="Goodfellas",
                 Director =new Director{FirstName= "Martin", LastName="Scorsese"},
                   Country="USA",
                 Genre= Genre.Drama,
                 Year=1990,
                Rating=8.7
            },
            new Movie
            {
                 Title="Interstellar",
                 Director =new Director{FirstName= "Christopher", LastName="Nolan"},
                   Country="USA",
                 Genre= Genre.Adventure,
                 Year=2014,
                Rating=8.6
            },
            new Movie
            {
                 Title="La Vita and bella",
                 Director =new Director{FirstName= "Roberto", LastName="Benigni"},
                   Country="Italy",
                 Genre= Genre.Drama,
                 Year=1997,
                Rating=8.6
            }
            */
        };
        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer<Movie> compare)// сюди ми передаємо фільм та Клас в якому є спосіб сортування
        {
            Array.Sort(movies, compare);
        }
        public void Print()
        {
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
    #endregion
    #region Compare
    class CompareByDirector : IComparer<Movie>// сортування по Director
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Director.FirstName.CompareTo(y.Director.FirstName);
        }
    }
    class CompareByCountry : IComparer<Movie>// сортування по Country
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Country.CompareTo(y.Country);
        }
    }
    class CompareByGenre : IComparer<Movie>// сортування по Genre
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Genre.CompareTo(y.Genre);
        }
    }
    class CompareByYear : IComparer<Movie>// сортування по Year
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
    class CompareByRating : IComparer<Movie>// сортування по Rating
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            Movie movie = new Movie();
            int choise = -1;
            #region Sort
            while (choise != 0)
            {
                Console.WriteLine("1 - Print Movie\n2 - Sort By Title\n3 - Sort By Director\n4 - Sort By Country\n5 - Sort By Genre\n6 - Sort By Year\n7 - Sort By Rating\n0 - EXIT MENU");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("\n\n\n-------------  Print Movie  -------------\n");
                        cinema.Print();
                        break;
                    case 2:
                        Console.WriteLine("\n\n\n------------- Sort By Title -------------\n");
                        Console.WriteLine("-------------:Dooo  -------------");
                        cinema.Print();
                        cinema.Sort();
                        Console.WriteLine("------------- :Pislua  -------------");
                        cinema.Print();
                        break;
                    case 3:
                        Console.WriteLine("\n\n\n------------- Sort By Director -------------\n");
                        Console.WriteLine("------------- :Dooo ------------- ");
                        cinema.Print();
                        cinema.Sort(new CompareByDirector());
                        Console.WriteLine("------------- :Pislua  -------------");
                        cinema.Print();
                        break;
                    case 4:
                        Console.WriteLine("\n\n\n------------- Sort By Country -------------\n");
                        Console.WriteLine("------------- :Dooo ------------- ");
                        cinema.Print();
                        cinema.Sort(new CompareByCountry());
                        Console.WriteLine("------------- :Pislua ------------- ");
                        cinema.Print();
                        break;
                    case 5:
                        Console.WriteLine("\n\n\n------------- Sort By Genre -------------\n");
                        Console.WriteLine("------------- :Dooo ------------- ");
                        cinema.Print();
                        cinema.Sort(new CompareByGenre());
                        Console.WriteLine("------------- :Pislua-------------  ");
                        cinema.Print();
                        break;
                    case 6:
                        Console.WriteLine("\n\n\n------------- Sort By Year -------------\n");
                        Console.WriteLine("------------- :Dooo  -------------");
                        cinema.Print();
                        cinema.Sort(new CompareByYear());
                        Console.WriteLine("------------- :Pislua ------------- ");
                        cinema.Print();
                        break;
                    case 7:
                        Console.WriteLine("\n\n\n------------- Sort By Rating -------------\n");
                        Console.WriteLine("------------- :Dooo ------------- ");
                        cinema.Print();
                        cinema.Sort(new CompareByRating());
                        Console.WriteLine("------------- :Pislua ------------- ");
                        cinema.Print();
                        break;
                }
            }
            #endregion
            // копіювання Movie
            Movie movie1 = new Movie
            {
                Title = "La Vita and bella",
                Director = new Director { FirstName = "Roberto", LastName = "Benigni" },
                Country = "Italy",
                Genre = Genre.Drama,
                Year = 1997,
                Rating = 8.6
            };
            Movie copy = (Movie)movie1.Clone();
            Console.WriteLine(copy);
        }
    }
}