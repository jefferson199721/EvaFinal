using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvaFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace EvaFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public DbSet<EvaFinal.Models.Alumnos> Alumnos { get; set; }
        public DbSet<EvaFinal.Models.Profesor>Profesor { get; set; }
        public DbSet<EvaFinal.Models.Examen>Examen { get; set; }
        public DbSet<EvaFinal.Models.hace>Hacer { get; set; }

    }
}
