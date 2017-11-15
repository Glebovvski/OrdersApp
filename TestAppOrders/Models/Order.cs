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

        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Evaluation Date")]
        public DateTime EndDate { get; set; }

        public Manager Manager { get; set; }
        
        public string Annotation { get; set; }

    }
}