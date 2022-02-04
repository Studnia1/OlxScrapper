using Coravel.Invocable;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace OlxScrapper.Services
{
    public class CoravelService : IInvocable
    {
        private readonly ILogger<CoravelService> _logger;
        public CoravelService(ILogger<CoravelService> logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(_logger));
        }
        public Task Invoke2()
        {
            var testGuid = Guid.NewGuid();
            _logger.LogError(testGuid.ToString());

            return Task.FromResult(true);
        }
        public Task Invoke()
        {
            var testGuid = "siema";
            _logger.LogError(testGuid.ToString());

            return Task.FromResult(true);
        }
    }
}
