using etl_labs.API.Repository;

using Hangfire;

namespace etl_labs.API.Jobs;

public class TopFiveJob : IHostedService
{
    private readonly TopFiveMusicService _service;
    public TopFiveJob(ITopFiveRepository repository)
    {
        _service = new TopFiveMusicService(repository);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            RecurringJob.AddOrUpdate("Job recorrente de raspagem do top 5 Youtube Brasil da semana", () => _service.postTopFiveYoutube(), Util.CronExpression("12", "*", "*", "1")); // Roda toda segunda feira
        });
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}