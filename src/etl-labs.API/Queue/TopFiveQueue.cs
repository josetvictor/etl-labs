using etl_labs.API.Domain.Interfaces;
using etl_labs.API.Integration.Interfaces;

namespace etl_labs.API.Queue;

public class TopFiveQueue : ITopFiveQueue
{
    private readonly ITopFiveIntegration _topFiveIntegration;

    public TopFiveQueue(ITopFiveIntegration topfiveIntegration)
    {
        _topFiveIntegration = topfiveIntegration;    
    }

    public Task<string> StartQueue()
    {
        // Na integração é onde faço a conexão com meu serviço para salvar as informaçõs no banco e retornar para o hangfire se deu certo ou não
        var foundResult = _topFiveIntegration.GetTopFive();

        Thread.Sleep(20000);

        return foundResult;
    }
}