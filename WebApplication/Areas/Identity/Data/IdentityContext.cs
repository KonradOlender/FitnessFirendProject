using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Areas.Identity.Data;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class IdentityContext : IdentityDbContext<Uzytkownik, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Uzytkownik>(b =>
            {
                
                b.HasMany<RolaUzytkownika>(t => t.role)
                 .WithOne(t => t.uzytkownik)
                 .HasForeignKey(uc => uc.id_uzytkownika)
                 .IsRequired();

                b.HasMany<HistoriaUzytkownika>(t => t.historiaUzytkownika)
                 .WithOne(t => t.uzytkownik)
                 .HasForeignKey(uc => uc.id_uzytkownika)
                 .IsRequired();

                b.HasMany<Trening>(t => t.treningi)
                 .WithOne(t => t.uzytkownik)
                 .HasForeignKey(uc => uc.id_uzytkownika)
                 .IsRequired();

                b.HasMany<Posilek>(t => t.posilki)
                 .WithOne(t => t.uzytkownik)
                 .HasForeignKey(uc => uc.id_uzytkownika)
                 .IsRequired();
            });
        }
    }
}
