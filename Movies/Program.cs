using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movies.Models;


namespace Movies;

public class Program
{

    static void Main(string[] args)
    {
        
        
        // sets up all of the logging for the file management
        IServiceCollection serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection
            .AddLogging(x=>x.AddConsole())
            .AddTransient<IfileManager, fileHandler>()
            .BuildServiceProvider();
        var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

        var fileAccessor = serviceProvider.GetService<IfileManager>();
        string file = "movies.csv";
        
        Console.WriteLine("Would you like the Abstract classes version of the Movies project?");
        var answer = Console.ReadLine();

        if (answer.ToLower() == "yes")
        {
            fileAccessor.displayMediaType();
        }
        
        Console.WriteLine("Would you like the JSON file version of the Movies project?");
        var theAnswer = Console.ReadLine();
        
        if (theAnswer.ToLower() == "yes")
        {
            JSONFiles movieFile = new JSONFiles();
            movieFile.writeAndRead();
        }

        for (int i = 0; i < Int32.MaxValue; i++)
        {

            Console.WriteLine("Choose an option.");
            Console.WriteLine("1: add a movie.");
            Console.WriteLine("2: display list of movies.");
            Console.WriteLine("3: exit");
            Console.WriteLine("Your choice?: ");

            var response = Console.ReadLine();

            if (response == "1")
            {

                fileAccessor.Write(file);

            }
            
            else if (response == "2")
            {

                fileAccessor.Read(file);

            }
            
            else if (response == "3")
            {
                break;
            }
            
            else
            {
                Console.WriteLine("invalid entry please try again.");
            }
        }
        
    }
    
}

public interface IfileManager
{
    void Read(string file);

    void Write(string file);

    void displayMediaType();

    string CreateMovieId(string file);
}

public class fileHandler : IfileManager
{

    public void Read(string file)
    {
        
        StreamReader reader = new StreamReader(file);
       var line = reader.ReadLine();
       
       Console.WriteLine("What movie ID would you like to start at?");
       var movieIDSelection = Console.ReadLine();

       try
       {
             

           while (!reader.EndOfStream)
           {
               
               line = reader.ReadLine();
               var row = line.Split(",");

               

               if (row[0].Contains(movieIDSelection))
               {
                   
                   Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);

                   while (!reader.EndOfStream)
                   {
                       line = reader.ReadLine();
                       row = line.Split(",");

                       Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
                   }
                   

               }


           }
       }
       catch (Exception ex)
       {
           Console.WriteLine(ex.Message);
       }
       
       reader.Close();
       
    }

    public void Write(string file)
    {
        
        var title = "";
        var acceptableTitle = false;

        do
        {
            title = GetMovieTitle();
            acceptableTitle = IsUnique(file, title);

        }while (acceptableTitle == false);


        var genreList = CreateGenreList();
        var movieID = CreateMovieId(file);

        var row = $"{movieID},{title},{genreList}";
        
        StreamWriter writer = new StreamWriter(file, true);
        
        writer.WriteLine(row);
        
        writer.Close();

    }

    private string GetMovieTitle()
    {
        
        var title = "";

        Console.Write("Title of movie?: ");
            title = Console.ReadLine();
            title = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;


            return title;

    }

    public string CreateMovieId(string file)
    {
        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();
        var movieID = "";

        if (reader.EndOfStream)
        {
            movieID = "1";
        }

        while (!reader.EndOfStream)
        {
                line = reader.ReadLine();
                var entry = line.Split(",");
                movieID = entry[0];
                //possibly remove the comma if it is in there
                var movieIDAsANumber = UInt64.Parse(movieID);
                movieIDAsANumber += 1;
                movieIDAsANumber.ToString();
                movieID = movieIDAsANumber.ToString();
        }

        reader.Close();

            return movieID;
        }
    

    private bool IsUnique(string file, string title)
        {

            var movieTitle = title;
            var isUniqueTitle = true;

            StreamReader reader = new StreamReader(file);
            var line = reader.ReadLine();

            do
            {

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var entry = line.Split(",");

                    if (movieTitle.ToLower() == entry[1].ToLower())
                    {
                        Console.WriteLine("Sorry this movie is already in the database. Please try again");
                        isUniqueTitle = false;
                        break;

                    }

                }

            } while (isUniqueTitle == false);

            reader.Close();

            return isUniqueTitle;
        }


        private string CreateGenreList()
        {

            List<string> genreList = new List<string>();
            var toContinue = "";

            do
            {

                Console.WriteLine("what genre is the movie?");
                var genre = Console.ReadLine();
                genre += "|";
                genreList.Add(genre);

                Console.WriteLine("Would you like to add more genres? type no to exit");
                toContinue = Console.ReadLine();

            } while (toContinue != "no");

            var lastEntry = genreList[genreList.Count() - 1];
            genreList.RemoveAt(genreList.Count - 1);

            lastEntry = lastEntry.Remove(lastEntry.Length - 1);

            genreList.Add(lastEntry);

            var listOfGenres = string.Join("|", genreList.ToArray());

            return listOfGenres;

        }

        public void displayMediaType()
        {

            Console.WriteLine("What type of media would you like to display? Movies, Shows, or Videos");
            var selection = Console.ReadLine();

            if (selection.ToLower() == "movies")
            {
                var id = 0;
                var title = "";
                var genres = "";

                 Media media = new Movie(id, title, genres);
                 media.Display();
            }
            else if (selection.ToLower() == "shows")
            {
                var id = 0;
                var title = "";
                var episode = 0;
                var season = 0;
                var writers = ""; 
                
               Media media = new Show(id, title, episode, season, writers);
               media.Display();
            }
            else if (selection.ToLower() == "videos")
            {
                var id = 0;
                var title = "";
                var format = "";
                var length = 0;
                var regions = 0;
                
               Media media = new Video(id, title, format, length, regions);
               media.Display();
            }

            


        }

    }

