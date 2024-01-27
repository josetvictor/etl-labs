namespace etl_labs.Hangfire.Domain.Interfaces;

public interface IJob
{
    public Task<string> StartJob();    
}