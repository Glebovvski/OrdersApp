using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppOrders.Models
{
    public class OrdersViewModel
    {
        [MaxLength(50)]
        public string Number { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Evaluation Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public string Manager { get; set; }

        public string Annotation { get; set; }
    }
}