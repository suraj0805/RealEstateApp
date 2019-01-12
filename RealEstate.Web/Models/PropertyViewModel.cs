using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class PropertyViewModel
    {
        public long PropertyId { get; set; }
        [Required]
        [Display(Name ="Property Name")]
        [StringLength(200,ErrorMessage ="Max 200 characters")]
        public string PropertyName { get; set; }
        [Required]
        [Display(Name = "Property Description")]
        [StringLength(1000,ErrorMessage ="Max 1000 characters")]
        public string PropertyDescription { get; set; }
        [Required]
        [Display(Name ="Property Address")]
        [StringLength(1000,ErrorMessage ="Max 1000 characters")]
        public string PropertyAddress { get; set; }
        [Display(Name ="Owned By")]
        public string OwnedBy { get; set; }
        [Display(Name ="Property Value")]
        public decimal PropertyValue { get; set; }
    }
}