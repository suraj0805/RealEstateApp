using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Contexts
{
    public interface IRealEstateContext
    {
        IDbSet<RealEstateUser> Users { get; set; }
        IDbSet<RealEstateProperty> RealEstateProperty { get; set; }
        IDbSet<RealEstatePropertyInterest> RealEstatePropertyInterest { get; set; }
        IDbSet<RealEstateNotification> RealEstateNotification { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
