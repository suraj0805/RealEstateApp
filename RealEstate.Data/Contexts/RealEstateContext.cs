using Microsoft.AspNet.Identity.EntityFramework;
using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Contexts
{
    public class RealEstateContext : IdentityDbContext<RealEstateUser>, IRealEstateContext
    {
        public RealEstateContext(string connectionString):base(connectionString)
        {
            
        }
        public IDbSet<RealEstateProperty> RealEstateProperty { get; set; }
        public IDbSet<RealEstatePropertyInterest> RealEstatePropertyInterest { get; set; }
        public IDbSet<RealEstateNotification> RealEstateNotification { get; set; }
    }
}
