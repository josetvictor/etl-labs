using etl_labs.API.Models;

namespace etl_labs.API.Repository;

public class TopFiveRepository : ITopFiveRepository
{
    private readonly List<Video> _topFiveYoutube;
    public TopFiveRepository()
    {
        _topFiveYoutube = new List<Video>();
    }

    public List<Video> getTopFiveYoutube()
    {
        return _topFiveYoutube;
    }

    public string postTopFiveYoutube(List<Video> videos)
    {
        int count = 0;
        foreach(var item in videos)
        {
            _topFiveYoutube.Add(item);
            count++;
        }

        return $"{count} videos adicionados";
    }
}