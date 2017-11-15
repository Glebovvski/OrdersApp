using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppOrders.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Evaluation Date")]
        public DateTime EndDate { get; set; }

        public Manager Manager { get; set; }
        
        public string Annotation { get; set; }

    }
}