using etl_labs.API.Models;
using etl_labs.API.Repository;
using etl_labs.API.Scrapings;

using Hangfire;

namespace etl_labs.API;

public class TopFiveMusicService
{
    private readonly ITopFiveRepository _repository;
    private readonly ToFiveMusicsYoutubeScraping _crawler;
    public TopFiveMusicService(ITopFiveRepository repository)
    {
        _crawler = new ToFiveMusicsYoutubeScraping();
        _repository = repository;
    }

    public List<Video> getTopFiveYoutube()
    {
        return _repository.getTopFiveYoutube();
    }

    public string postTopFiveYoutube()
    {
        var videos = _crawler.Scraping();
        
        return _repository.postTopFiveYoutube(videos);
    }
}
