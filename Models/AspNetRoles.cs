using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class Roles
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}