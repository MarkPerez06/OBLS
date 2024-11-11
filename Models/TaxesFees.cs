using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class TaxesFees
    {
        public Guid Id { get; set; }
        [DisplayName("Taxes/Fees")]
        public string Name { get; set; }
        [DisplayName("Amount")]
        public float Price { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
