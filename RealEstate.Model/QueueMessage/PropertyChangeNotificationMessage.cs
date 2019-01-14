using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model.QueueMessage
{
    public class PropertyChangeNotificationMessage : QueueMessage
    {
        public PropertyChangeNotificationMessage(long propertyId, string userId, string userName) : base(nameof(PropertyChangeNotificationMessage))
        {
            PropertyId = propertyId;
            UserId = userId;
            UserName = userName;
        }

        public long PropertyId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
