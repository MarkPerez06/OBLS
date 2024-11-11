using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        [DisplayName("Payment Method")]
        public string Name { get; set; }
        [DisplayName("Payment Number")]
        public string Number { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
