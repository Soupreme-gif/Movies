using Newtonsoft.Json;

namespace Movies;

internal class JSONFiles
{
    
    public string movieID { get; set; }
    public string title { get; set; }
    public string[] genres { get; set; }
    
    public void Read(string json)
    {
        JSONFiles movieFile = JsonConvert.DeserializeObject<JSONFiles>(json); 

        Console.WriteLine(movieFile.movieID);
        Console.WriteLine(movieFile.title);
        Console.WriteLine(movieFile.genres);

    }
    
    public string Write()
    {
        JSONFiles movieFile = new JSONFiles();
        movieFile.movieID = "1";
        movieFile.title = "Encanto";
        movieFile.genres = new[] {"Fantasy"};

        // Install-Package Newtonsoft.Json
        string json = JsonConvert.SerializeObject(movieFile);

        Console.WriteLine(json);

        return json;
    }
    
}



