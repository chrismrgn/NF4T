using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using NF4T.OData.Core;
using NF4T.OData.Models;

namespace NF4T.OData.Controllers
{
    
    [EnableQuery]
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
            var events = new List<Event>
            {
                new Event
                {
                    SubjectId = "tcm:0-0-0",
                    Environment = new CMEnvironment() { Id = Guid.NewGuid() }
                },
                new Event
                {
                    SubjectId = "tcm:0-0-0",
                    Environment = new CMEnvironment() { Id = Guid.NewGuid() }
                }
            };

            return Ok(events.AsQueryable());
        }

        //ADD ASYNC
        [HttpPost]
        public IHttpActionResult Post(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created(@event);
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
