using OBLS.Models;

namespace OBLS.Static
{

    public class UserRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static UserRoles Applicant => new UserRoles()
        {
            Id = "bb9825cc-d2d1-4121-ace8-7335225f2c89",
            Name = "Applicant"
        };

        public static UserRoles Administrator => new UserRoles()
        {
            Id = "80aaf565-d80e-4617-893d-fb8eeeb6b6a9",
            Name = "Administrator"
        };
        public static UserRoles BarangayCaptain => new UserRoles()
        {
            Id = "5aa2a168-44cd-43f2-9a81-d2e6923abf56",
            Name = "Barangay Captain"
        };

        public static UserRoles BIRCollectionOfficer => new UserRoles()
        {
            Id = "0c6ae8f7-48e1-451b-8455-a9b503cc4bdd",
            Name = "BIR Collection Officer"
        };

        public static UserRoles ChiefOfPolice => new UserRoles()
        {
            Id = "a7cf4366-2a4e-4f5a-9d7d-b68e9b8ab640",
            Name = "Chief of Police"
        };

        public static UserRoles MENROOfficer => new UserRoles()
        {
            Id = "1c3551ec-67b0-4cdb-a040-a2485429d123",
            Name = "MENRO (Municipal Environment & Natural Resources) Officer"
        };

        public static UserRoles MunicipalEngineer => new UserRoles()
        {
            Id = "7c4b3084-7f23-4ed1-86fb-a33d714fe3da",
            Name = "Municipal Engineer"
        };

        public static UserRoles MunicipalFireMarshall => new UserRoles()
        {
            Id = "a25ab246-1312-4eb1-a102-237e57aefecf",
            Name = "Municipal Fire Marshall"
        };

        public static UserRoles MunicipalHealthOfficer => new UserRoles()
        {
            Id = "78b83b79-4ba9-40e6-a1e3-57b1a62a573c",
            Name = "Municipal Health Officer"
        };

        public static UserRoles SanitaryHealthOfficer => new UserRoles()
        {
            Id = "afa03a96-252a-4ee1-b4e7-942f0901c021",
            Name = "Sanitary Health Officer"
        };

        public static UserRoles MunicipalTreasurer => new UserRoles()
        {
            Id = "ca2b0591-e42c-41a7-abbb-fd2ceeb0e96f",
            Name = "Municipal Treasurer"
        };

        public static UserRoles MunicipalMayor => new UserRoles()
        {
            Id = "610f5fed-4f7d-4cca-b32d-ef7613bad840",
            Name = "Municipal Mayor"
        };
    }
}
