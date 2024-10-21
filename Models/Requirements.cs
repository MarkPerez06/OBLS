using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class Requirements
    {
        public Guid Id { get; set; }
        [DisplayName("Type")]
        public Guid UserRolesId { get; set; }
        [DisplayName("Name")]
        public string? Name { get; set; }
        [DisplayName("Is Upload")]
        public bool IsUpload { get; set; }
    }
}
