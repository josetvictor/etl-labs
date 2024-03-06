using etl_labs.API.Models;

namespace etl_labs.API.Repository;

public interface ITopFiveRepository
{
    List<Video> getTopFiveYoutube();
    string postTopFiveYoutube(List<Video> videos);
}