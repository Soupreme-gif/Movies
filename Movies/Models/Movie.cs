namespace Movies.Models;

public class Movie : Media
{
    public string Genres { get; set; }

    public Movie(int Id, string Title, string Genres)
    {

        this.Id = Id;
        this.Title = Title;
        this.Genres = Genres;


    }

    public override string Display()
    {

        var file = "movies2.csv";

        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();

        while (!reader.EndOfStream)
        {

            line = reader.ReadLine();
            var row = line.Split(",");

            Id = Int32.Parse(row[0]);
            Title = row[1];
            Genres = row[2];

            Console.WriteLine($"{Id},{Title},{Genres}");

        }
        
        reader.Close();

        return "";
    }
}