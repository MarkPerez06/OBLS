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

        [Required]
        [DisplayName("Mode of Payment")]
        public string? Application_PaymentMode { get; set; }

        [Required]
        [DisplayName("Tax Year")]
        public string? Application_Year { get; set; }

        [HiddenInput]
        [DisplayName("Application Method")]
        public string? Application_Method { get; set; }

        [HiddenInput]
        [DisplayName("Application Status")]
        public string? Application_Status { get; set; }

        [HiddenInput]
        [DisplayName("Application Date")]
        public DateTime? Application_DateTime { get; set; } = DateTime.Now;

        [DisplayName("Generate Barangay Clearance")]
        public bool Application_IsGenerateBrgyClearance { get; set; }


        // BUSINESS INFORMATION
        [HiddenInput]
        [DisplayName("Tracking Number")]
        public string? Tracking_Number { get; set; }

        [HiddenInput]
        [DisplayName("Business ID Number")]
        public string? Business_IDNumber { get; set; }

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

        [DisplayName("Tax Declaration No.")]
        public string? BusinessOperation_TaxDeclarationNo { get; set; }

        [DisplayName("Property Identification No.")]
        public string? BusinessOperation_PropertyIdentificationNo { get; set; }

        [Required]
        [DisplayName("DO YOU HAVE TAX INCENTIVES FROM ANY GOVERNMENT ENTITY?")]
        public bool? BusinessOperation_HasTaxIncentives { get; set; }

        [DisplayName("Please Specify the Entity")]
        public string? BusinessOperation_PleaseSpecifyTheEntity { get; set; }

        [DisplayName("Incentive Certificate")]
        public string? BusinessOperation_IncentiveCertificate { get; set; }

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

        [Required]
        [DisplayName("Latitude")]
        public string? Latitude { get; set; }

        [Required]
        [DisplayName("Longitude")]
        public string? Longitude { get; set; }

        public DateTime? Permit_ExpiredDate { get; set; } = DateTime.Now;
        public DateTime? Permit_DateRelease { get; set; } = DateTime.Now;
        public decimal? Permit_Amount { get; set; }
        public bool? Permit_IsPaid { get; set; }
        public string? Permit_Comments { get; set; }
        public string? UserId { get; set; }
    }
}
