using System;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;
using Refit;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase
{
    public interface IChaordicShowcaseApi : IRestApiClient
    {
        [Get("recommend/{showcaseType}?format=json&q={query}")]    
        Task<ChaorticRootObject> FetchShowcase(string showcaseType, string query);
    }
}