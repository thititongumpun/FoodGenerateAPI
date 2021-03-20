using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodGenerateAPI.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _stopWatch;
        private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

        public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _stopWatch.Start();

            var elapsedMilliseconds = _stopWatch.ElapsedMilliseconds;

            var response = await next();

            _logger.LogInformation($"Running Request: {typeof(TRequest).Name} elapsedMilliseconds:{ elapsedMilliseconds}");

            _stopWatch.Stop();
            
            _logger.LogInformation($"Running Request: {typeof(TResponse).Name} elapsedMilliseconds:{ elapsedMilliseconds}");

            return response;
        }
    }
}
