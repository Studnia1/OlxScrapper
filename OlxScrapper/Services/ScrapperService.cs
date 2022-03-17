using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Coravel.Invocable;

namespace OlxScrapper.Services
{
    public class ScrapperService
    {
        private readonly ILogger<ScrapperService> _log;
        private readonly IConfiguration _configuration;
        private string _baseUrl; 

        public ScrapperService(ILogger<ScrapperService> log, IConfiguration configuration, string baseUrl, int moneyLimit)
        {
            _log = log ??
                throw new ArgumentNullException(nameof(log));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _baseUrl = baseUrl ??
                       throw new ArgumentNullException(nameof(baseUrl));
        }

        public void ScrapperEngineRun()
        {
            var htmlWeb = new HtmlWeb();
            var page = htmlWeb.Load(_baseUrl);

            var priceRows = page.QuerySelectorAll(".price");
        }

        public Task elo()
        {
            var testGuid = "siema";
            _log.LogError(testGuid.ToString());

            return Task.FromResult(true);
        }
    }
}
