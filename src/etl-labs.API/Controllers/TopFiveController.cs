using etl_labs.API.Models;
using etl_labs.API.Repository;
using etl_labs.API.Scrapings;

using Microsoft.AspNetCore.Mvc;

namespace etl_labs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TopFiveController : ControllerBase
{
    private readonly TopFiveMusicService _service;

    public TopFiveController(ITopFiveRepository repository)
    {
        _service = new TopFiveMusicService(repository);
    }

    [HttpGet()]
    public List<Video> Get()
    {
        return _service.getTopFiveYoutube();
    }
}
