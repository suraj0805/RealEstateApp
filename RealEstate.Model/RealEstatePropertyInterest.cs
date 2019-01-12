using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model
{
    public class RealEstatePropertyInterest : ModelBase
    {
        [Key]
        public long PropertyInterestId { get; set; }
        public long PropertyId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual RealEstateProperty Property { get; set; }
        public virtual RealEstateUser User { get; set; }
    }
}
