using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RedditBulkSub_api.Models;

namespace RedditBulkSub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private RedditConfig _redditConfig;
        // constructor
        public ValuesController(ConfigService configService)
        {
            _redditConfig = configService.getRedditConfig();
        }

        // GET api/values
        [HttpGet]
        async public Task<ActionResult<dynamic>> Get()
        {
            RedditOauth reddit = new RedditOauth(_redditConfig.ApplicationId, _redditConfig.ApplicationSecret);

            string  token = (await reddit.authAsync(_redditConfig.RedditUserName, _redditConfig.RedditPassword)).access_token;
            
            return new
            {
               token,
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
