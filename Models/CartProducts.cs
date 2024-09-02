using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class CartProducts
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? SessionId { get; set; }
    }
}