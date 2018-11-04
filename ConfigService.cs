using Microsoft.Extensions.Configuration;
using RedditBulkSub_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBulkSub_api
{
    public class ConfigService
    {
        private readonly IConfiguration _config;
        private const string REDDIT_OAUTH = "RedditOAuth";

        public ConfigService(IConfiguration config)
        {
            this._config = config;
        }

        public RedditConfig getRedditConfig()
        {
            return new RedditConfig
            {
                RedditUserName = _config.GetSection($"{REDDIT_OAUTH}:RedditUserName").Value,
                RedditPassword = _config.GetSection($"{REDDIT_OAUTH}:RedditPassword").Value,
                ApplicationId = _config.GetSection($"{REDDIT_OAUTH}:ApplicationId").Value,
                ApplicationSecret = _config.GetSection($"{REDDIT_OAUTH}:ApplicationSecret").Value
            };

        }
    }
}
