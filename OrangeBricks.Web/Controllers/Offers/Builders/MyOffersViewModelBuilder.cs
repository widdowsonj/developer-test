using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            return new MyOffersViewModel
            {
                MyOffers = _context.Offers
                    .Where(o => o.BuyerUserId == buyerId)
                    .Select(o => new MyOfferViewModel
                    {
                        Id = o.Id,
                        Amount = o.Amount,
                        CreatedAt = o.CreatedAt,
                        IsPending = o.Status == OfferStatus.Pending,
                        Status = o.Status.ToString(),
                        PropertyType = o.Property.PropertyType,
                        StreetName = o.Property.StreetName,
                        NumberOfBedrooms = o.Property.NumberOfBedrooms
                    })
                    .ToList()
            };
        }
    }
}