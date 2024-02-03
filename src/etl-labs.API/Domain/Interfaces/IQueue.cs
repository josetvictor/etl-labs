namespace etl_labs.API.Domain.Interfaces;

public interface IQueue
{
    Task<string> StartQueue();
}