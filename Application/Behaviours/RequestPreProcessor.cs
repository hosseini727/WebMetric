using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class RequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<RequestPreProcessor<TRequest>> _logger;

        public RequestPreProcessor(ILogger<RequestPreProcessor<TRequest>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Handling {typeof(TRequest)} Request");
        }
    }

}
