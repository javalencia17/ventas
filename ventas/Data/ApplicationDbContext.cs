using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ventas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ventas.Models.Categoria> Categoria { get; set; }
        public DbSet<ventas.Models.Articulo> Articulo { get; set; }
        public DbSet<ventas.Models.Persona> Persona { get; set; }
        
    }
}
