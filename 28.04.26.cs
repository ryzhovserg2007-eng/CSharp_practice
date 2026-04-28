using System.Text.Json;
using Newtonsoft.Json;
namespace _28._04._26
{
    internal class Program
    {
        public class Movie
        {
            private string _name;
            private int[] _stars;
            public string Name => _name;
            public int[] Stars => _stars.ToArray();
            public Movie(string name)
            {
                _name = name;
                _stars = new int[0];
            }
            public void Add(int star)
            {
                Array.Resize(ref _stars, _stars.Length+1);
                _stars[_stars.Length-1] = star;
            }
        }
        static void Main(string[] args)
        {
            Movie m = new Movie("Star wars");
            m.Add(5);
            m.Add(2);
            m.Add(4);
            var temp = new
            {
                MovieType = m.GetType().Name,
                m.Name,
                m.Stars
            };
            string json = JsonConvert.SerializeObject(temp);
            Console.WriteLine(json);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "movie.json");
            File.WriteAllText(filePath, json);
            string content = File.ReadAllText(filePath);
            var json2 = JsonConvert.DeserializeObject<dynamic>(content);

            Movie m2 = new Movie((string)json2.Name);
            foreach( var star in json2.Stars)
            {
                m2.Add((int)star);
            }

            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string filePath = Path.Combine(folderPath,"example.txt");
            //Console.WriteLine(folderPath);//  путь до файла
            //Console.WriteLine(filePath);

            //if (File.Exists(filePath)) // если файл есть 
            //{
            //    Console.WriteLine("File already exists");
            //}
            //else
            //{
            //    File.Create(filePath).Close();
            //    Console.WriteLine("File created");
            //}
           // string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string filePath = Path.Combine(folderPath ,"example.txt");
            Console.WriteLine(folderPath);//  путь до файла
            Console.WriteLine(filePath);

            string folderPath1 = Path.GetDirectoryName(filePath); // работаем с папкой
            if (!Directory.Exists(folderPath1))
            {
                Directory.CreateDirectory(folderPath1);
            }
            

            if (!File.Exists(filePath)) 
            {
                File.Create(filePath).Close(); // открыли поток, закрыли поток
            }
            
            File.WriteAllText(filePath, "Hello!");
            // Если файла нет - создаст и запишет
            // Если файл есть - заменит содержимое
            File.WriteAllText(filePath, "Bye!");

            string[] words = new string[] { "just", "another", "example" };
            File.WriteAllLines(filePath, words);

            File.AppendAllText(filePath, "Again hello");
            File.AppendAllText(filePath, "Again bye");
            File.AppendAllLines(filePath, words);

            string content1 = File.ReadAllText(filePath);
            Console.WriteLine(content1);
            string[] content2 = File.ReadAllLines(filePath);
            foreach (string line in content2)
            {
                Console.WriteLine(line);
            }
            //File.Create("testrelative.txt").Close();
            //File.Delete("testrelative.txt");
            //File.Delete(filePath);
        }
    }
}
