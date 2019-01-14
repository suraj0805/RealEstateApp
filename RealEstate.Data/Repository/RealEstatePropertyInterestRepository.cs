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
    public class RealEstatePropertyInterestRepository : RepositoryBase, IRealEstatePropertyInterestRepository
    {
        public RealEstatePropertyInterestRepository(IRealEstateContext realEstateContext) : base(realEstateContext)
        {

        }

        public async Task<RealEstatePropertyInterest> CreateRealEstatePropertyInterest(RealEstatePropertyInterest realEstatePropertyInterest)
        {
            if (realEstatePropertyInterest == null)
                throw new ArgumentNullException(nameof(realEstatePropertyInterest));
            var realEstateProperty = RealEstateContext.RealEstateProperty.FirstOrDefault(x => x.PropertyId == realEstatePropertyInterest.PropertyId);
            var realEstateUser = RealEstateContext.Users.FirstOrDefault(x => x.Id == realEstatePropertyInterest.UserId);
            if (realEstateProperty == null || realEstateUser == null)
            {
                throw new ArgumentException(nameof(realEstatePropertyInterest));
            }

            realEstatePropertyInterest.CreatedDate = System.DateTime.Now;
            realEstatePropertyInterest.IsActive = true;
            RealEstateContext.RealEstatePropertyInterest.Add(realEstatePropertyInterest);
            await RealEstateContext.SaveChangesAsync();

            return realEstatePropertyInterest;
        }

        public async Task DeleteRealEstatePropertyInterest(long propertyId,string userId)
        {
            if (propertyId == default(long))
                throw new ArgumentNullException(nameof(propertyId));
            var realEstatePropertyInterestData = RealEstateContext.RealEstatePropertyInterest.
                FirstOrDefault(x => x.PropertyId == propertyId && x.UserId==userId && x.IsActive);
            if (realEstatePropertyInterestData == null)
            {
                throw new InvalidOperationException(nameof(propertyId));
            }

            realEstatePropertyInterestData.IsActive = false;
            await RealEstateContext.SaveChangesAsync();
        }

        public IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(long propertyId)
        {
            return RealEstateContext.RealEstatePropertyInterest.Include(x => x.Property).Include(x => x.User)
                .Where(x => x.PropertyId == propertyId && x.IsActive).ToList();
        }

        public IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(long propertyId,string userId)
        {
            return RealEstateContext.RealEstatePropertyInterest.Include(x => x.Property).Include(x => x.User)
                .Where(x => x.PropertyId == propertyId && x.UserId == userId && x.IsActive).ToList();
        }

        public IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(string userId)
        {
            return RealEstateContext.RealEstatePropertyInterest.Include(x => x.Property).Include(x => x.User)
                .Where(x => x.UserId == userId && x.IsActive).ToList();
        }
    }
}
