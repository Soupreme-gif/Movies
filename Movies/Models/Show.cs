namespace Movies.Models;

public class Show : Media
{
    public int Episode { get; set; }
    public int Season { get; set; }
    public string Writers { get; set; }

    public Show(int Id, string Title, int Episode, int Season, string Writers)
    {

        this.Id = Id;
        this.Title = Title;
        this.Episode = Episode;
        this.Season = Season;
        this.Writers = Writers;

    }

    public override string Display()
    {
        var file = "shows.csv";

        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();

        while (!reader.EndOfStream)
        {

            line = reader.ReadLine();
            var row = line.Split(",");

            Id = Int32.Parse(row[0]);
            Title = row[1];
            Episode = Int32.Parse(row[2]);
            Season = Int32.Parse(row[3]);
            Writers = row[4];

            Console.WriteLine($"{Id},{Title},{Episode},{Season},{Writers}");

        }
        
        reader.Close();

        return "";
    }
}