namespace Movies.Models;

public class Video : Media
{
    // TODO need to add properties
    
    public string format { get; set; }
    public int length { get; set; }
    public int regions { get; set; }

    public Video(int Id, string Title, string format, int length, int regions)
    {
        this.Id = Id;
        this.Title = Title;
        this.format = format;
        this.length = length;
        this.regions = regions;
    }

    public override string Display()
    {
        var file = "video.csv";

        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();

        while (!reader.EndOfStream)
        {

            line = reader.ReadLine();
            var row = line.Split(",");

            Id = Int32.Parse(row[0]);
            Title = row[1];
            format = row[2];
            length = Int32.Parse(row[3]);
            regions = Int32.Parse(row[4]);
            

            Console.WriteLine($"{Id},{Title},{format},{length},{regions}");

        }
        
        reader.Close();

        return "";
    }
}