using Coravel.Invocable;

namespace OlxScrapper.Services
{
    public interface IScrapperServiceFactory : IInvocable
    {
        void AddNewService(string baseUrl, int moneyLimit);
    }
}