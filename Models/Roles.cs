using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class Roles
    {
        public Guid Id { get; set; }

        // APPLICATION
        [Required]
        [DisplayName("Name")]
        public string? Name { get; set; }
    }
}
