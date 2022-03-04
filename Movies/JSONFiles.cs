using Newtonsoft.Json;

namespace Movies;

public class JSONFiles
{
    
    public string movieID { get; set; }
    public string title { get; set; }
    public string[] genres { get; set; }
    
}

public static string Write()
{
    JSONFiles movieFile = new JSONFiles();
        movieFile.movieID = "1";
        movieFile.title = "Encanto";
    product.Sizes = new string[] {"Small"};

    // Install-Package Newtonsoft.Json
    string json = JsonConvert.SerializeObject(product);

    Console.WriteLine(json);

    return json;
}

public static void Read(string json)
{
    Product p = JsonConvert.DeserializeObject<Product>(json); 

    Console.WriteLine(p.Name);
    Console.WriteLine(p.Expiry);
    Console.WriteLine(p.Sizes);

}