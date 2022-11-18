using Grpc.Core;
using InternalAPI;
using System;


public class EstimatesService : Estimates.EstimatesBase
{
    // private readonly ILogger<EstimatesService> _logger;

    public EstimatesService()
    { }

    public Task<EstimateModel> GetEstimates(GetEstimatesRequest request, ServerCallContext context)
    {
        Console.WriteLine($"GetEstimates({request.ToString()})");
        return Task.FromResult(new EstimateModel
        {
            EstimateId = "FF9D4DF7-ED1C-4804-91D4-97986C31D3CF"
        });
    }
    public Task<EstimateModel> GetEstimateRefresh(GetEstimatesRequest request, ServerCallContext context)
    {
        Console.WriteLine($"GetEstimatesRefresh({request.ToString()})");
        return Task.FromResult(new EstimateModel
        {
            EstimateId = "FF9D4DF7-ED1C-4804-91D4-97986C31D3CF"
        });
    }
}
