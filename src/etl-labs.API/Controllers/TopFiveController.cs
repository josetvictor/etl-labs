using etl_labs.API.Scrapings;

using Microsoft.AspNetCore.Mvc;

namespace etl_labs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TopFiveController : ControllerBase
{
    private readonly ILogger<TopFiveController> _logger;
    private readonly ToFiveMusicsYoutubeScraping _crawler;

    public TopFiveController(ILogger<TopFiveController> logger, ToFiveMusicsYoutubeScraping crawler)
    {
        _logger = logger;
        _crawler = crawler;
    }

    [HttpGet(Name = "ToFiveMusicsYoutubeScraping")]
    public List<Video> Get()
    {
        return _crawler.topVideos;
    }

    [HttpPost(Name = "ToFiveMusicsYoutubeScraping")]
    public void Post()
    {
        _crawler.Scraping();
    }
}
