using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{
    [TestFixture]
    public class MyOffersViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnOffersWithMatchingBuyerId()
        {
            // Arrange
            var builder = new MyOffersViewModelBuilder(_context);

            var offers = new List<Offer>
            {                
                new Offer {
                    Id = 1,
                    BuyerUserId = "666",
                    Property = new Models.Property { StreetName = "Bad Street", PropertyType = "Terraced", NumberOfBedrooms = 2 }
                },
                new Offer {
                    Id = 2,
                    BuyerUserId = "1234567890",
                    Property = new Models.Property { StreetName = "Good Street", PropertyType = "Terraced", NumberOfBedrooms = 2 }
                },
            };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);
            
            // Act
            var viewModel = builder.Build("1234567890");

            // Assert
            Assert.That(viewModel.MyOffers.Count, Is.EqualTo(1));
            Assert.That(viewModel.MyOffers[0].Id, Is.EqualTo(2));
        }
    }
}
