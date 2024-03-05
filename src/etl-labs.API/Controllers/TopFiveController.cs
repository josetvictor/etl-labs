using etl_labs.API.Models;
using etl_labs.API.Scrapings;

using Microsoft.AspNetCore.Mvc;

namespace etl_labs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TopFiveController : ControllerBase
{
    private readonly ILogger<TopFiveController> _logger;
    private readonly TopFiveMusicService _service;

    public TopFiveController(ILogger<TopFiveController> logger, TopFiveMusicService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "ToFiveMusicsYoutubeScraping")]
    public List<Video> Get()
    {
        return _service.getTopFiveYoutube();
    }

    [HttpPost(Name = "ToFiveMusicsYoutubeScraping")]
    public void Post()
    {
        _service.postTopFiveYoutube();
    }
}
