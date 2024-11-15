﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OBLS.Models;

namespace OBLS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationLineBusiness> ApplicationLineBusiness { get; set; }
        public DbSet<ApplicationRequirements> ApplicationRequirements { get; set; }
        public DbSet<ApplicationSignatories> ApplicationSignatories { get; set; }
        public DbSet<LineBusiness> LineBusiness { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<OBLS.Models.TaxesFees>? TaxesFees { get; set; }
        public DbSet<OBLS.Models.PaymentMethod>? PaymentMethod { get; set; }
    }
}