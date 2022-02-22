using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Movies.Tests;

public class UnitTest1
{

    [Fact]
    public void getMovieIdWorking()
    {

        var fileAccessor = new fileHandler();
        var file = "movies.csv";

        var movieId = fileAccessor.CreateMovieId(file);

        //create assert for the movieID to equal the next ID
        
        Assert.Equal("164980", movieId);

    }
}