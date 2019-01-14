using RealEstate.Model;
using RealEstate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Mappers
{
    public static class PropertyInterestMapper
    {
        public static IEnumerable<PropertyInterestViewModel> Map(this IEnumerable<RealEstatePropertyInterest> realEstatePropertyInterests)
        {
            return realEstatePropertyInterests.Select(x => new PropertyInterestViewModel {
                PropertyInterestId = x.PropertyInterestId,
                PropertyId = x.PropertyId,
                PropertyName = x.Property.PropertyName,
                PropertyDescription = x.Property.PropertyDescription,
                OwnedBy = x.User.UserName
            }).ToList();
        }
    }
}