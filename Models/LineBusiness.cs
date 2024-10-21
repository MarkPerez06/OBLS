using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class LineBusiness
    {
        public Guid Id { get; set; }
        [DisplayName("Code")]
        public string? Code { get; set; }
        [DisplayName("Description")]
        public string? Description { get; set; }
        [DisplayName("Signage/Billboard - Capacity")]
        public string? SignageBillboard_Capacity { get; set; }
        [DisplayName("Signage/Billboard - No. of Units")]
        public string? SignageBillboard_NoOfUnits { get; set; }
        [DisplayName("Weights and Measures - Capacity")]
        public string? WeightsAndMeasures_Capacity { get; set; }
        [DisplayName("Weights and Measures - No. of Units")]
        public string? WeightsAndMeasures_NoOfUnits { get; set; }
    }
}
