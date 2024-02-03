using etl_labs.API.Scrapings;
using etl_labs.API.Integration.Interfaces;

namespace etl_labs.API.Integration;

public class TopFiveIntegration : ITopFiveIntegration
{
    private readonly ToFiveMusicsYoutubeScraping _crawler;

    public TopFiveIntegration(ToFiveMusicsYoutubeScraping crawler)
    {
        _crawler = crawler;
    }

    public Task<string> GetTopFive()
    {
        _crawler.Scraping();
        return Task.Run(() => "top five integration Add");
    }
}