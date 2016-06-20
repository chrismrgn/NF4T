using System.Data.Entity;
using NF4T.OData.Models;

namespace NF4T.OData.Core
{
    public class EventsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<CMEnvironment> CMEnvironments { get; set; }
    }
}