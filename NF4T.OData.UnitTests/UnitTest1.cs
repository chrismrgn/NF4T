using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NF4T.Models;
using NF4T.OData.Controllers;

namespace NF4T.OData.UnitTests
{
    [TestClass]
    public class EventsControllerTests
    {
        [TestMethod]
        public void GetReturnsProduct()
        {
            // Arrange
            //var mockSet = new Mock<DbSet<Blog>>();
            var controller = new EventsController();

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var actionResult = controller.Get() as OkNegotiatedContentResult<IQueryable<Record>>;

            Assert.IsNotNull(actionResult);

            var events = actionResult.Content;
            Assert.IsTrue(events.Any());
        }
    }
}
