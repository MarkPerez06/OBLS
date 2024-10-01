using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class LineBusiness
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? SignageBillboard_Capacity { get; set; }
        public string? SignageBillboard_NoOfUnits { get; set; }
        public string? WeightsAndMeasures_Capacity { get; set; }
        public string? WeightsAndMeasures_NoOfUnits { get; set; }
    }
}
