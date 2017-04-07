using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{
    [TestFixture]
    public class BookViewingViewModelBuilderTest
    {
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _properties;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Models.Property>>();
            _context.Properties.Returns(_properties);
        }

        [Test]
        public void BuildShouldReturnPropertyWithMatchingPropertyId()
        {
            // Arrange
            var builder = new BookViewingViewModelBuilder(_context);

            var property = new Models.Property{ Id = 1, StreetName = "Smith Street", Description = "", IsListedForSale = true };

            _properties.Find(1).Returns(property);

            // Act
            var viewModel = builder.Build(1);

            // Assert
            _context.Properties.Received(1).Find(1);
            Assert.That(viewModel.PropertyId, Is.EqualTo(1));
        }
    }
}
