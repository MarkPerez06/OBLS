using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class Application
    {
        public Guid Id { get; set; }

        // APPLICATION
        [Required]
        [DisplayName("TYPE OF APPLICATION")]
        public string? Application_Type { get; set; }
        public enum ApplicationType
        {
            New,
            Renew
        }
        [Required]
        [DisplayName("Mode of Payment")]
        public string? Application_PaymentMode { get; set; }

        [Required]
        [DisplayName("Tax Year")]
        public string? Application_Year { get; set; }

        [DisplayName("Application Method")]
        public string? Application_Method { get; set; }

        [DisplayName("Application Status")]
        public string? Application_Status { get; set; }

        [DisplayName("Application Date")]
        public DateTime? Application_DateTime { get; set; } = DateTime.Now;

        [DisplayName("Generate Barangay Clearance")]
        public bool? Application_IsGenerateBrgyClearance { get; set; }


        // BUSINESS INFORMATION
        [Required]
        [DisplayName("Business Name")]
        public string? Business_Name { get; set; }

        [DisplayName("Trade Name/Franchise")]
        public string? Business_TradeName { get; set; }

        [Required]
        [DisplayName("Type of Organization")]
        public string? Business_OrganizationType { get; set; }

        [DisplayName("Sex")]
        public string? Business_Sex { get; set; }

        [DisplayName("Registration Number")]
        public string? Business_RegistrationNumber { get; set; }

        [DisplayName("TIN")]
        public string? Business_TIN { get; set; }

        [DisplayName("For Corporation")]
        public string? Business_IsFilipino { get; set; }

        public enum Citizenship
        {
            Filipino,
            Foreign
        }

        // NAME OF OWNER/PRESIDENT/OFFICER IN CHARGE
        [Required]
        [DisplayName("Last Name")]
        public string? Owner_LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? Owner_FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string? Owner_MiddleName { get; set; }

        [DisplayName("Suffix (e.g. Jr. Sr. IIII)")]
        public string? Owner_Suffix { get; set; }


        // MAIN OFFICE ADDRESS
        [Required]
        [DisplayName("Region")]
        public string? MainOffice_Region { get; set; }

        [Required]
        [DisplayName("Province")]
        public string? MainOffice_Province { get; set; }

        [Required]
        [DisplayName("City/Municipality")]
        public string? MainOffice_CityMunicipality { get; set; }

        [Required]
        [DisplayName("Barangay")]
        public string? MainOffice_Brgy { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public string? MainOffice_ZipCode { get; set; }

        [DisplayName("House/Bldg. No.")]
        public string? MainOffice_HouseBuildingNumber { get; set; }

        [DisplayName("Name of Building")]
        public string? MainOffice_BuildingName { get; set; }

        [DisplayName("Lot No.")]
        public string? MainOffice_LotNumber { get; set; }

        [DisplayName("Block No.")]
        public string? MainOffice_BlockNumber { get; set; }

        [DisplayName("Street")]
        public string? MainOffice_Street { get; set; }

        [DisplayName("Subdivision")]
        public string? MainOffice_Subdivision { get; set; }


        // CONTACT INFORMATION
        [Required]
        [DisplayName("Mobile No.")]
        public string? Contact_MobileNumber { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string? Contact_EmailAddress { get; set; }

        [DisplayName("Telephone No.")]
        public string? Contact_TelephoneNumber { get; set; }


        // BUSINESS OPERATION
        [Required]
        [DisplayName("Business Activity")]
        public string? BusinessOperation_BusinessActivity { get; set; }

        [DisplayName("Other Business Activity")]
        public string? BusinessOperation_OtherBusinessActivity { get; set; }

        [Required]
        [DisplayName("Business Area (in sq.m)")]
        public string? BusinessOperation_BusinessAreaSqm { get; set; }

        [DisplayName("Total Floor Area")]
        public string? BusinessOperation_TotalFloorArea { get; set; }

        // Total No. of Employees in Establishment
        [DisplayName("Male")]
        public int? BusinessOperation_EmployeeMale { get; set; }

        [DisplayName("Female")]
        public int? BusinessOperation_EmployeeFemale { get; set; }

        [DisplayName("Total No. Employee Residing within the LGU")]
        public int? BusinessOperation_TotalEmployeeWithLGU { get; set; }

        // No. of Delivery Vehicles (If applicable)
        [DisplayName("Van Truck")]
        public int? BusinessOperation_TotalVanTruck { get; set; }

        [DisplayName("Motorcycle")]
        public int? BusinessOperation_TotalMotorcycle { get; set; }

        [Required]
        [DisplayName("OWNED?")]
        public bool? BusinessOperation_IsOwned { get; set; }

        [Required]
        [DisplayName("DO YOU HAVE TAX INCENTIVES FROM ANY GOVERNMENT ENTITY?")]
        public bool? BusinessOperation_HasTaxIncentives { get; set; }


        // BUSINESS LOCATION ADDRESS
        [Required]
        [DisplayName("Region")]
        public string? BusinessLocation_Region { get; set; }

        [Required]
        [DisplayName("Province")]
        public string? BusinessLocation_Province { get; set; }

        [Required]
        [DisplayName("City/Municipality")]
        public string? BusinessLocation_CityMunicipality { get; set; }

        [Required]
        [DisplayName("Barangay")]
        public string? BusinessLocation_Brgy { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public string? BusinessLocation_ZipCode { get; set; }

        [DisplayName("House/Bldg. No.")]
        public string? BusinessLocation_HouseBuildingNumber { get; set; }

        [DisplayName("Name of Building")]
        public string? BusinessLocation_BuildingName { get; set; }

        [DisplayName("Lot No.")]
        public string? BusinessLocation_LotNumber { get; set; }

        [DisplayName("Block No.")]
        public string? BusinessLocation_BlockNumber { get; set; }

        [DisplayName("Street")]
        public string? BusinessLocation_Street { get; set; }

        [DisplayName("Subdivision")]
        public string? BusinessLocation_Subdivision { get; set; }
    }
}
