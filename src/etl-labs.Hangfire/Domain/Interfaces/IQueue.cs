namespace etl_labs.Hangfire.Domain.Interfaces;

public interface IQueue
{
    Task<string> StartQueue();
}