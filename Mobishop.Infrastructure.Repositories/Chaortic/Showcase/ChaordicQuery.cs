using System;
using System.Collections.Generic;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Request;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic
{
    public class ChaordicQuery
    {
        const string ApiKey = "panvel-v5";

        /// <summary>
        /// Build the query.
        /// </summary>
        internal string Build()
        {
            var request = new Request()
            {
                ApiKey = ApiKey,
                Page = new Page()
                {
                    Name = "mobile.home"
                },
                Identity = new Identity()
                {
                    AnonymousUserId = "anon-1234",
                    BrowserId = "1234",
                    Session = "1"
                },
                Size = 7
            };

            return JsonConvert.SerializeObject(request);
        }
    }
}