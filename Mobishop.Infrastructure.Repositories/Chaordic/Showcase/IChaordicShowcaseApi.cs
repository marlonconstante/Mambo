using System;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;
using Refit;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase
{
    public interface IChaordicShowcaseApi : IRestApiClient
    {
        [Get("/recommend/{showcaseType}?format=json&q={query}")]    
        Task<ChaordicRootObject> FetchShowcase(string showcaseType, string query);
    }
}