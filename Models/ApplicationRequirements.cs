﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBLS.Models
{
    public class ApplicationRequirements
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid UserRolesId { get; set; }
        public string? Name { get; set; }
        public string? UrlData { get; set; }
        public bool IsUpload { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
