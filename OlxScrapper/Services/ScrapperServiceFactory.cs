
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OlxScrapper.Services
{
    public class ScrapperServiceFactory : IScrapperServiceFactory
    {
        private ICollection<ScrapperService> scrapperServices;
        private readonly ILogger<ScrapperService> _log;
        private readonly IConfiguration _configuration;

        public ScrapperServiceFactory(ILogger<ScrapperService> log, IConfiguration configuration)
        {
            _log = log ??
                   throw new ArgumentNullException(nameof(log));
            _configuration = configuration ??
                             throw new ArgumentNullException(nameof(configuration));
            scrapperServices = new List<ScrapperService>();
        }
        public void AddNewService(string baseUrl, int moneyLimit)
        {
            scrapperServices.Add(new ScrapperService(_log, _configuration, baseUrl, moneyLimit));
        }

        public Task Invoke()
        {
            if(scrapperServices.Count == 0)
                return Task.FromResult(true);

            foreach (var service in scrapperServices)
            {
                service.elo();
            }
            return Task.FromResult(true);
        }
    }
}
