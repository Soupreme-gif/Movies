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
        throw new NotImplementedException();
    }
}