using System.Net.Http.Headers;
using System.Xml.Serialization;
namespace _12._05._26
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _rating;
        public string Name => _name;
        public int Duration => _duration;
        public int[] Rating => _rating;
        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _rating = new int[0];
        }
        public void Add( int rate)
        {
            Array.Resize(ref _rating, _rating.Length + 1);
            _rating[_rating.Length - 1] = rate;
        }
    }
    public class MovieDTO
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int[] Rating { get; set; }
        public MovieDTO()
        {

        }
        public MovieDTO(string name, int duration, int[] rating)
        {
            Name = name;
            Duration = duration;
            Rating = rating;
        }
        public MovieDTO(Movie movie)
        {
            Name = movie.Name;
            Duration = movie.Duration;
            Rating = movie.Rating;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FilePath = Path.Combine(folderPath, "movie.xml");
            Movie movie1 = new Movie("Spider-man", 120);
            MovieDTO  movieDTO1 = new MovieDTO(movie1); 
            var serializer = new XmlSerializer(typeof(MovieDTO));
            // Конструктор без параметров
            // Публичный класс
            // Свойства с публичными сеттерами
            using (var writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, movieDTO1);
            }
            // Deserealization
            MovieDTO movieDTO2;
            using(var reader  = new StreamReader(FilePath))
            {
                 movieDTO2  = (MovieDTO)serializer.Deserialize(reader);
            }
            Movie movie2 = new Movie(movieDTO2.Name, movieDTO2.Duration);
            foreach(int val in movieDTO2.Rating)
            {
                movie2.Add(val);
            }
            if (CompareMovies(movie1 ,movie2)) Console.WriteLine("Success");
            else Console.WriteLine("No success");

            //Console.WriteLine( movie2.Name);
            //Console.WriteLine( movie2.Duration);
            //Console.WriteLine(movie1.Duration == movie2.Duration);
            //Console.WriteLine(movie1.Name   == movie2.Name);
        }
        public static bool CompareMovies(Movie m1 , Movie m2) // проверка для себя
        {
            if (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Rating != m2.Rating) return false;
            for (int i = 0; i < m1.Rating.Length; i++)
            {
                if (m1.Rating[i] != m2.Rating[i]) return false;
            }

            return true;
        }
    }
}
