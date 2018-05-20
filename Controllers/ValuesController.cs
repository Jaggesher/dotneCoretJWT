using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCoreJWT.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet("Admin")]
        [Authorize(Policy = "SiteAdmin")]
        public IEnumerable<string> Admin()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("SimpleUser")]
        [Authorize(Policy = "ApiUserSimple")]
        public IEnumerable<String> SimpleUser()
        {
            return new string[] { "value3", "value4" };
        }


        [HttpGet("ValueableUser")]
        [Authorize(Policy = "APiUserValueable")]
        public IEnumerable<String> ValueableUser()
        {
            return new string[] { "value5", "value6" };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
