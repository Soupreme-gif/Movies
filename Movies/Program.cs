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

