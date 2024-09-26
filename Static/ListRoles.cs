using OBLS.Models;
using System.Collections.Generic;

namespace OBLS.Static
{
    public class ListRoles
    {
        public List<UserRoles> Roles { get; set; }
        public ListRoles()
        {
            Roles = new List<UserRoles>
            {
                UserRoles.Applicant,
                UserRoles.Administrator,
                UserRoles.BarangayCaptain,
                UserRoles.BIRCollectionOfficer,
                UserRoles.ChiefOfPolice,
                UserRoles.MENROOfficer,
                UserRoles.MunicipalEngineer,
                UserRoles.MunicipalFireMarshall,
                UserRoles.MunicipalHealthOfficer,
                UserRoles.SanitaryHealthOfficer,
                UserRoles.MunicipalTreasurer,
                UserRoles.MunicipalMayor
            };
        }
    }
}
