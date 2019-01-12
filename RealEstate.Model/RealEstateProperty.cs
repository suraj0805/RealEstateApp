using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model
{
    public class RealEstateProperty : ModelBase
    {
        [Key]
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string PropertyAddress { get; set; }
        public decimal PropertyValue { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IList<RealEstatePropertyInterest> PropertyInterests { get; set; }
        public IList<RealEstateNotification> PropertyNotifications { get; set; }
        public virtual RealEstateUser User { get; set; }
    }
}
