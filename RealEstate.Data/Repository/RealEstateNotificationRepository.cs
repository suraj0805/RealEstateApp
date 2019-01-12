using RealEstate.Data.Contexts;
using RealEstate.Data.Repository.IRepository;
using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository
{
    public class RealEstateNotificationRepository : RepositoryBase, IRealEstateNotificationRepository
    {
        public RealEstateNotificationRepository(IRealEstateContext realEstateContext) : base(realEstateContext)
        {

        }

        public IList<RealEstateNotification> GetRealEstateNotifications(string userId)
        {
            return RealEstateContext.RealEstateNotification.Where(x => x.UserId == userId && x.IsActive).ToList();
        }
    }
}
