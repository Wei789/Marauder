using Marauder.BLL.ViewModels;
using Marauder.Help;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Marauder.Web.Controllers.Api
{
    public class ValueController : ApiController
    {
        /// <summary>
        /// RESTful sample get api.
        /// </summary>
        /// <remarks>RESTful Http method GET</remarks>
        /// <returns></returns>
        public SampleView Get()
        {
            return new SampleView() { a = 0, bClass = new SampleBClass() { b = "a" } };
        }
                
        // GET: api/Value/5
        public HttpResponseMessage Get(int id)
        {
            SampleView s = new SampleView() { a = 0, bClass = new SampleBClass() { b = "a" } };
            return KitFile.FileAsAttachment(s, id.ToString(), "text");
        }

        // POST: api/Value
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Value/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Value/5
        public void Delete(int id)
        {
        }
    }
}
