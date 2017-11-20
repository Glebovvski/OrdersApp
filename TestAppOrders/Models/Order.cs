using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppOrders.Models
{
    public class Order : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Evaluation Date")]
        public DateTime EndDate { get; set; }

        public Manager Manager { get; set; }
        
        public string Annotation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.CreateDate > this.EndDate)
            {
                errors.Add(new ValidationResult("Creation date must be earlier than Evaluation date"));
            }

            return errors;
        }
    }
}