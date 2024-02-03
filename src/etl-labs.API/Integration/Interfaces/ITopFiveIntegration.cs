namespace etl_labs.API.Integration.Interfaces;

public interface ITopFiveIntegration
{
    public Task<string> GetTopFive();
}