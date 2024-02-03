namespace etl_labs.API.Domain.Interfaces;

public interface IJob
{
    public Task<string> StartJob();    
}