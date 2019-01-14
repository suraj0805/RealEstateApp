using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository.IRepository
{
    public interface IRealEstatePropertyInterestRepository
    {
        IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(long propertyId);
        IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(long propertyId, string userId);
        IList<RealEstatePropertyInterest> GetRealEstatePropertyInterests(string userId);
        Task<RealEstatePropertyInterest> CreateRealEstatePropertyInterest(RealEstatePropertyInterest realEstatePropertyInterest);
        Task DeleteRealEstatePropertyInterest(long propertyId, string userId);
    }
}
