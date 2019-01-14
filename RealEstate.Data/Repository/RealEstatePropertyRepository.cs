using RealEstate.Data.Contexts;
using RealEstate.Data.Repository.IRepository;
using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository
{
    public class RealEstatePropertyRepository : RepositoryBase, IRealEstatePropertyRepository
    {
        public RealEstatePropertyRepository(IRealEstateContext realEstateContext) : base(realEstateContext)
        {

        }

        public async Task<RealEstateProperty> CreateRealEstateProperty(RealEstateProperty realEstateProperty)
        {
            if (realEstateProperty == null)
                throw new ArgumentNullException(nameof(realEstateProperty));
            var realEstatePropertyData = RealEstateContext.RealEstateProperty.
                FirstOrDefault(x => x.PropertyName == realEstateProperty.PropertyName && x.IsActive);
            if (realEstatePropertyData != null)
                throw new InvalidOperationException(Constants.PropertyExistsMessage);

            realEstateProperty.CreatedDate = System.DateTime.Now;
            realEstateProperty.IsActive = true;
            RealEstateContext.RealEstateProperty.Add(realEstateProperty);
            await RealEstateContext.SaveChangesAsync();

            return realEstateProperty;
        }

        public async Task<RealEstateProperty> EditRealEsateProperty(RealEstateProperty realEstateProperty)
        {
            if (realEstateProperty == null)
                throw new ArgumentNullException(nameof(realEstateProperty));
            var realEstatePropertyData = RealEstateContext.RealEstateProperty
                .FirstOrDefault(x => x.PropertyName == realEstateProperty.PropertyName && x.IsActive);
            if (realEstatePropertyData == null)
                throw new InvalidOperationException(Constants.PropertyNotExistsMessage);

            realEstatePropertyData.UpdatedDate = DateTime.Now;
            realEstatePropertyData.PropertyAddress = realEstateProperty.PropertyAddress;
            realEstatePropertyData.PropertyDescription = realEstateProperty.PropertyDescription;
            realEstatePropertyData.PropertyValue = realEstateProperty.PropertyValue;

            await RealEstateContext.SaveChangesAsync();
            return realEstatePropertyData;
        }

        public IEnumerable<RealEstateProperty> GetRealEstateProperties()
        {
            return RealEstateContext.RealEstateProperty.Include(x=>x.User).Where(x => x.IsActive).ToList();
        }

        public IEnumerable<RealEstateProperty> GetRealEstateProperties(string searchBy, string searchString)
        {
            var searchStringLower = searchString.ToLowerInvariant();
            if (searchBy == Constants.PropertyName)
                return RealEstateContext.RealEstateProperty.Include(x=>x.User).Where(x => x.PropertyName.ToLower().Contains(searchStringLower) && x.IsActive).ToList();
            else 
                return RealEstateContext.RealEstateProperty.Include(x => x.User).Where(x => x.PropertyAddress.ToLower().Contains(searchStringLower) && x.IsActive).ToList();
        }

        public RealEstateProperty GetRealEstateProperty(long propertyId)
        {
            return RealEstateContext.RealEstateProperty.
                Include(x => x.User).FirstOrDefault(x => x.PropertyId == propertyId && x.IsActive);
        }
    }
}
