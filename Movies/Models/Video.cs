namespace Movies.Models;

public class Video : Media
{
    // TODO need to add properties
    
    public string format { get; set; }
    public int length { get; set; }
    public int regions { get; set; }

    public Video()
    {
        this.Id = Id;
        this.Title = Title;
        this.format = format;
        this.length = length;
        this.regions = regions;
    }

    public override string Display()
    {
        throw new NotImplementedException();

        

    }
}