using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class Roles
    {
        public string Id { get; set; }
        public string? Name { get; set; }
    }
}
