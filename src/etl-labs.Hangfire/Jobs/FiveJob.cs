using etl_labs.Hangfire.Domain.Interfaces;

namespace etl_labs.Hangfire.Jobs;

public class FiveJob : IJobTopFive
{
    private readonly ITopFiveQueue _fiveQueue;

    public FiveJob(ITopFiveQueue queue)
    {
        _fiveQueue = queue;
    }

    public async Task<string> StartJob()
    {
        var resultMessage = await _fiveQueue.StartQueue();

        return resultMessage;
    }
}