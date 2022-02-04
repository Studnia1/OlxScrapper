using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace OlxScrapper.Services
{
    public class ScrapperService
    {
        private readonly ILogger<ScrapperService> _log;
        private readonly IConfiguration _configuration;
        private string _baseUrl; 

        public ScrapperService(ILogger<ScrapperService> log, IConfiguration configuration, string baseUrl)
        {
            _log = log ??
                throw new ArgumentNullException(nameof(log));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _baseUrl = baseUrl;
        }

        public void ScrapperEngineRun()
        {
            var htmlWeb = new HtmlWeb();
            var page = htmlWeb.Load(_baseUrl);

            var priceRows = page.QuerySelectorAll(".price");
        }
    }
}
