using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class PropertyInterestViewModel
    {
        public long PropertyInterestId { get; set; }
        public long PropertyId { get; set; }
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Display(Name = "Property Description")]
        public string PropertyDescription { get; set; }
        [Display(Name ="Owned By")]
        public string OwnedBy { get; set; }
    }
}