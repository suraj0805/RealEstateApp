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
        Task<RealEstatePropertyInterest> CreateRealEstatePropertyInterest(RealEstatePropertyInterest realEstatePropertyInterest);
        Task DeleteRealEstatePropertyInterest(RealEstatePropertyInterest realEstatePropertyInterest);
    }
}
