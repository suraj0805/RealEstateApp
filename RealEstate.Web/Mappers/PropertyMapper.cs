using RealEstate.Model;
using RealEstate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Mappers
{
    public static class PropertyMapper
    {
        public static IEnumerable<PropertyViewModel> Map(this IEnumerable<RealEstateProperty> realEstateProperties)
        {
            return realEstateProperties.Select(x => new PropertyViewModel {
                PropertyId = x.PropertyId,
                PropertyName = x.PropertyName,
                PropertyDescription = x.PropertyDescription,
                PropertyAddress = x.PropertyAddress,
                PropertyValue = x.PropertyValue,
                OwnedBy = x.UserId
            }).ToList();
        }

        public static PropertyViewModel Map(this RealEstateProperty realEstateProperty)
        {
            var result = new PropertyViewModel();
            result.PropertyId = realEstateProperty.PropertyId;
            result.PropertyName = realEstateProperty.PropertyName;
            result.PropertyDescription = realEstateProperty.PropertyDescription;
            result.PropertyAddress = realEstateProperty.PropertyAddress;
            result.PropertyValue = realEstateProperty.PropertyValue;
            result.OwnedBy = realEstateProperty.UserId;
            return result;
        }

        public static RealEstateProperty Map(this PropertyViewModel propertyViewModel)
        {
            var result = new RealEstateProperty();
            result.PropertyId = propertyViewModel.PropertyId;
            result.PropertyName = propertyViewModel.PropertyName;
            result.PropertyDescription = propertyViewModel.PropertyDescription;
            result.PropertyAddress = propertyViewModel.PropertyAddress;
            result.PropertyValue = propertyViewModel.PropertyValue;
            result.UserId = propertyViewModel.OwnedBy;

            return result;
        }
    }
}