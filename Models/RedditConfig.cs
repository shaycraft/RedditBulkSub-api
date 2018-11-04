using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBulkSub_api.Models
{
    public class RedditConfig
    {
        public string RedditUserName { get; set; }
        public string RedditPassword { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }
    }
}
