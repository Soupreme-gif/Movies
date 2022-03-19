namespace Movies;

public interface IfileManager
{
    void Read(string file);

    void Write(string file);

    void displayMediaType();

    string CreateMovieId(string file);
}