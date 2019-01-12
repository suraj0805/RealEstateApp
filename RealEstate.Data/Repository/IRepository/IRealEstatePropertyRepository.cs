using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository.IRepository
{
    public interface IRealEstatePropertyRepository
    {
        IEnumerable<RealEstateProperty> GetRealEstateProperties();
        IEnumerable<RealEstateProperty> GetRealEstateProperties(string searchBy, string searchString);
        RealEstateProperty GetRealEstateProperty(long propertyId);
        Task<RealEstateProperty> EditRealEsateProperty(RealEstateProperty realEstateProperty);
        Task<RealEstateProperty> CreateRealEstateProperty(RealEstateProperty realEstateProperty);
    }
}
