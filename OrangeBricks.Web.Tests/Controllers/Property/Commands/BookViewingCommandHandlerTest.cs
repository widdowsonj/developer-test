using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class BookViewingCommandHandlerTest
    {
        private BookViewingCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _properties;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Models.Property>>();
            _context.Properties.Returns(_properties);
            _handler = new BookViewingCommandHandler(_context);
        }

        [Test]
        public void HandleShouldAddBooking()
        {
            // Arrange
            var command = new BookViewingCommand();
            command.PropertyId = 1;
            command.BuyerUserId = "123";

            var property = new Models.Property { Id = 1, StreetName = "Smith Street", Description = "", IsListedForSale = true };

            _properties.Find(1).Returns(property);

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.That(property.Viewings.Count(), Is.EqualTo(1));
        }
    }
}
