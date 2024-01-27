using etl_labs.Hangfire.Integration.Interfaces;

namespace etl_labs.Hangfire.Integration;

public class TopFiveIntegration : ITopFiveIntegration
{
    public Task<string> GetTopFive()
    {
        return Task.Run(() => "top five integration return message");
    }
}