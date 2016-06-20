using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using NF4T.Models;
using NF4T.OData.Core;
using NF4T.OData.Models;

namespace NF4T.OData.Controllers
{
    public class EventsController : ODataController
    {
        private EventsContext context = new EventsContext();

        private bool AppVersionsExists(Guid key)
        {
            return Guid.Empty == key;
        }

        //ADD ASYNC
        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Get()
        {
            var events = new List<Record>
            {
                new Record
                {
                    Subject = new Subject { TcmId = "tcm:0-0-0"},
                    Environment = new CMEnvironment() { Name = "Mock" }
                },
                new Record
                {
                    Subject = new Subject { TcmId = "tcm:0-0-0"},
                    Environment = new CMEnvironment() { Name = "Mock" }
                }
            };

            return Ok(events.AsQueryable());
        }

        //ADD ASYNC
        [HttpPost]
        public IHttpActionResult Post(Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created(record);
        }

        //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //if (key != update.Id)
                //{
                //    return BadRequest();
                //}
                //db.Entry(update).State = EntityState.Modified;
                //try
                //{
                //    await db.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ProductExists(key))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
         
    }
}
