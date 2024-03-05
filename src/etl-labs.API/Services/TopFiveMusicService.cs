using etl_labs.API.Models;
using etl_labs.API.Scrapings;

using Hangfire;
using Hangfire.Server;

namespace etl_labs.API;

public class TopFiveMusicService : IHostedService
{
    private readonly ToFiveMusicsYoutubeScraping _crawler;
    public TopFiveMusicService(ToFiveMusicsYoutubeScraping crawler)
    {
        _crawler = crawler;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await JobHangfire();
    }

    private async Task JobHangfire()
    {
        RecurringJob.AddOrUpdate("Job recorrente de raspagem do top 5 Youtube Brasil da semana", () => _crawler.Scraping(), Util.CronExpression("12", "15"));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public List<Video> getTopFiveYoutube()
    {
        return _crawler.topVideos;
    }

    public void postTopFiveYoutube()
    {
        _crawler.Scraping();
    }
}
