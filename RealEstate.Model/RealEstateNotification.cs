using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model
{
    public class RealEstateNotification : ModelBase
    {
        [Key]
        public long NotificationId { get; set; }
        public long PropertyId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Message { get; set; }
        [DefaultValue(false)]
        public bool IsRead { get; set; }
        public virtual RealEstateProperty Property { get; set; }
        public virtual RealEstateUser User { get; set; }
    }
}
