using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class ApplicationLineBusiness
    {
        public Guid Id { get; set; }
        public Guid LineBusinessId { get; set; }
        public Guid ApplicationId { get; set; }
        public string? NoOfUnits { get; set; }
        public string? CapitalInvestment { get; set; }
        public string? GrossIncomeEssential { get; set; }
        public string? GrossIncomeNonEssential { get; set; }
        public string? SignageBillboard_Capacity { get; set; }
        public string? SignageBillboard_NoOfUnits { get; set; }
        public string? WeightsAndMeasures_Capacity { get; set; }
        public string? WeightsAndMeasures_NoOfUnits { get; set; }
    }
}
