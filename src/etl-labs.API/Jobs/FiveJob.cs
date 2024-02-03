using etl_labs.API.Domain.Interfaces;

namespace etl_labs.API.Jobs;

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