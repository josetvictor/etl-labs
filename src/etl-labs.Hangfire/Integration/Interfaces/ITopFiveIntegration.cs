namespace etl_labs.Hangfire.Integration.Interfaces;

public interface ITopFiveIntegration
{
    public Task<string> GetTopFive();
}