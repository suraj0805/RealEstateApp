using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository.IRepository
{
    public interface IRealEstateNotificationRepository
    {
        IList<RealEstateNotification> GetRealEstateNotifications(string userId);
        Task<RealEstateNotification> CreateRealEstateNotification(RealEstateNotification realEstateNotification);
    }
}
