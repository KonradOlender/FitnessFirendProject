using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trening>().HasKey(t => t.id_treningu);
            modelBuilder.Entity<Trening>()
                .HasOne<Uzytkownik>(t => t.uzytkownik)
                .WithMany(t => t.treningi)
                .HasForeignKey(d => d.id_uzytkownika);

            modelBuilder.Entity<Trening>()
                .HasOne<KategoriaTreningu>(t => t.kategoria)
                .WithMany(t => t.treningi)
                .HasForeignKey(d => d.id_kategorii);

            modelBuilder.Entity<Rola>().HasKey(t => t.id_roli);

            modelBuilder.Entity<Posilek>().HasKey(t => t.id_posilku);
            modelBuilder.Entity<Posilek>()
                .HasOne<Uzytkownik>(t => t.uzytkownik)
                .WithMany(t => t.posilki)
                .HasForeignKey(d => d.id_uzytkownika);

            modelBuilder.Entity<KategoriaSkladnikow>().HasKey(t => t.id_kategorii);
            modelBuilder.Entity<KategoriaTreningu>().HasKey(t => t.id_kategorii);
            modelBuilder.Entity<KategoriaCwiczenia>().HasKey(t => t.id_kategorii);

            modelBuilder.Entity<Cwiczenie>().HasKey(t => t.id_cwiczenia);
            modelBuilder.Entity<Cwiczenie>()
                .HasOne<KategoriaCwiczenia>(t => t.kategoria)
                .WithMany(t => t.cwiczenia)
                .HasForeignKey(d => d.id_kategorii);

            modelBuilder.Entity<Skladnik>().HasKey(t => t.id_skladnika);
            modelBuilder.Entity<Skladnik>()
                .HasOne<KategoriaSkladnikow>(t => t.kategoria)
                .WithMany(t => t.skladniki)
                .HasForeignKey(d => d.id_kategorii);

            modelBuilder.Entity<HistoriaUzytkownika>().HasKey(t => new { t.id_uzytkownika, t.data });
            modelBuilder.Entity<HistoriaUzytkownika>()
                .HasOne<Uzytkownik>(t => t.uzytkownik)
                .WithMany(t => t.historiaUzytkownika)
                .HasForeignKey(d => d.id_uzytkownika)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TreningSzczegoly>().HasKey(t => new { t.id_treningu, t.id_cwiczenia });
            modelBuilder.Entity<TreningSzczegoly>()
                .HasOne<Trening>(t => t.trening)
                .WithMany(t => t.cwiczenia)
                .HasForeignKey(d => d.id_treningu)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TreningSzczegoly>()
                .HasOne<Cwiczenie>(t => t.cwiczenie)
                .WithMany(t => t.treningi)
                .HasForeignKey(d => d.id_cwiczenia)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PosilekSzczegoly>().HasKey(t => new { t.id_posilku, t.id_skladnika });
            modelBuilder.Entity<PosilekSzczegoly>()
                .HasOne<Posilek>(t => t.posilek)
                .WithMany(t => t.skladniki)
                .HasForeignKey(d => d.id_posilku)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PosilekSzczegoly>()
                .HasOne<Skladnik>(t => t.skladnik)
                .WithMany(t => t.posilki)
                .HasForeignKey(d => d.id_skladnika)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolaUzytkownika>().HasKey(t => new { t.id_roli, t.id_uzytkownika });
            modelBuilder.Entity<RolaUzytkownika>()
                .HasOne<Rola>(t => t.rola)
                .WithMany(t => t.uzytkownicy)
                .HasForeignKey(d => d.id_roli)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolaUzytkownika>()
                .HasOne<Uzytkownik>(t => t.uzytkownik)
                .WithMany(t => t.role)
                .HasForeignKey(d => d.id_uzytkownika)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Cwiczenie> cwiczenia { get; set; }
        public  DbSet<Trening> treningi { get; set; }
        public  DbSet<KategoriaTreningu> kategoriaTreningu { get; set; }
        public  DbSet<TreningSzczegoly> treningSzczegoly { get; set; }
        public  DbSet<Posilek> posilki { get; set; }
        public  DbSet<Skladnik> skladnik { get; set; }
        public  DbSet<PosilekSzczegoly> posilekSzczegoly { get; set; }
        public  DbSet<KategoriaCwiczenia> kategoriaCwiczenia { get; set; }
        public  DbSet<Uzytkownik> uzytkownicy { get; set; }
        public  DbSet<HistoriaUzytkownika> historiaUzytkownika { get; set; }
        public  DbSet<Rola> role { get; set; }
        public DbSet<KategoriaSkladnikow> kategoriaSkladnikow { get; set; }
    }
}
