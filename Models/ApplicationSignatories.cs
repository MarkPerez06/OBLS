using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class ApplicationSignatories
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid UserRolesId { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? Department { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
