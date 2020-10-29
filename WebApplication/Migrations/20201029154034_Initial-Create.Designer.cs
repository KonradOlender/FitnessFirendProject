﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Data;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201029154034_Initial-Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Areas.Identity.Data.Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("uzytkownicy");
                });

            modelBuilder.Entity("WebApplication.Models.Cwiczenie", b =>
                {
                    b.Property<int>("id_cwiczenia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_kategorii")
                        .HasColumnType("int");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("spalone_kalorie")
                        .HasColumnType("int");

                    b.HasKey("id_cwiczenia");

                    b.HasIndex("id_kategorii");

                    b.ToTable("cwiczenia");
                });

            modelBuilder.Entity("WebApplication.Models.HistoriaUzytkownika", b =>
                {
                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<double>("waga")
                        .HasColumnType("float");

                    b.Property<int>("wzrost")
                        .HasColumnType("int");

                    b.HasKey("id_uzytkownika", "data");

                    b.ToTable("historiaUzytkownika");
                });

            modelBuilder.Entity("WebApplication.Models.KategoriaCwiczenia", b =>
                {
                    b.Property<int>("id_kategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_kategorii");

                    b.ToTable("kategoriaCwiczenia");
                });

            modelBuilder.Entity("WebApplication.Models.KategoriaSkladnikow", b =>
                {
                    b.Property<int>("id_kategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_kategorii");

                    b.ToTable("kategoriaSkladnikow");
                });

            modelBuilder.Entity("WebApplication.Models.KategoriaTreningu", b =>
                {
                    b.Property<int>("id_kategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_kategorii");

                    b.ToTable("kategoriaTreningu");
                });

            modelBuilder.Entity("WebApplication.Models.Posilek", b =>
                {
                    b.Property<int>("id_posilku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.Property<int>("kalorie")
                        .HasColumnType("int");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_posilku");

                    b.HasIndex("id_uzytkownika");

                    b.ToTable("posilki");
                });

            modelBuilder.Entity("WebApplication.Models.PosilekSzczegoly", b =>
                {
                    b.Property<int>("id_posilku")
                        .HasColumnType("int");

                    b.Property<int>("id_skladnika")
                        .HasColumnType("int");

                    b.Property<int>("porcja")
                        .HasColumnType("int");

                    b.HasKey("id_posilku", "id_skladnika");

                    b.HasIndex("id_skladnika");

                    b.ToTable("posilekSzczegoly");
                });

            modelBuilder.Entity("WebApplication.Models.Rola", b =>
                {
                    b.Property<int>("id_roli")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_roli");

                    b.ToTable("role");
                });

            modelBuilder.Entity("WebApplication.Models.RolaUzytkownika", b =>
                {
                    b.Property<int>("id_roli")
                        .HasColumnType("int");

                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.HasKey("id_roli", "id_uzytkownika");

                    b.HasIndex("id_uzytkownika");

                    b.ToTable("RolaUzytkownika");
                });

            modelBuilder.Entity("WebApplication.Models.Skladnik", b =>
                {
                    b.Property<int>("id_skladnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_kategorii")
                        .HasColumnType("int");

                    b.Property<int>("kalorie")
                        .HasColumnType("int");

                    b.Property<int>("waga")
                        .HasColumnType("int");

                    b.HasKey("id_skladnika");

                    b.HasIndex("id_kategorii");

                    b.ToTable("skladnik");
                });

            modelBuilder.Entity("WebApplication.Models.Trening", b =>
                {
                    b.Property<int>("id_treningu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_kategorii")
                        .HasColumnType("int");

                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_treningu");

                    b.HasIndex("id_kategorii");

                    b.HasIndex("id_uzytkownika");

                    b.ToTable("treningi");
                });

            modelBuilder.Entity("WebApplication.Models.TreningSzczegoly", b =>
                {
                    b.Property<int>("id_treningu")
                        .HasColumnType("int");

                    b.Property<int>("id_cwiczenia")
                        .HasColumnType("int");

                    b.Property<int>("liczba_powtorzen")
                        .HasColumnType("int");

                    b.HasKey("id_treningu", "id_cwiczenia");

                    b.HasIndex("id_cwiczenia");

                    b.ToTable("treningSzczegoly");
                });

            modelBuilder.Entity("WebApplication.Models.Cwiczenie", b =>
                {
                    b.HasOne("WebApplication.Models.KategoriaCwiczenia", "kategoria")
                        .WithMany("cwiczenia")
                        .HasForeignKey("id_kategorii")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.HistoriaUzytkownika", b =>
                {
                    b.HasOne("WebApplication.Areas.Identity.Data.Uzytkownik", "uzytkownik")
                        .WithMany("historiaUzytkownika")
                        .HasForeignKey("id_uzytkownika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.Posilek", b =>
                {
                    b.HasOne("WebApplication.Areas.Identity.Data.Uzytkownik", "uzytkownik")
                        .WithMany("posilki")
                        .HasForeignKey("id_uzytkownika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.PosilekSzczegoly", b =>
                {
                    b.HasOne("WebApplication.Models.Posilek", "posilek")
                        .WithMany("skladniki")
                        .HasForeignKey("id_posilku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Skladnik", "skladnik")
                        .WithMany("posilki")
                        .HasForeignKey("id_skladnika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.RolaUzytkownika", b =>
                {
                    b.HasOne("WebApplication.Models.Rola", "rola")
                        .WithMany("uzytkownicy")
                        .HasForeignKey("id_roli")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Areas.Identity.Data.Uzytkownik", "uzytkownik")
                        .WithMany("role")
                        .HasForeignKey("id_uzytkownika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.Skladnik", b =>
                {
                    b.HasOne("WebApplication.Models.KategoriaSkladnikow", "kategoria")
                        .WithMany("skladniki")
                        .HasForeignKey("id_kategorii")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.Trening", b =>
                {
                    b.HasOne("WebApplication.Models.KategoriaTreningu", "kategoria")
                        .WithMany("treningi")
                        .HasForeignKey("id_kategorii")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Areas.Identity.Data.Uzytkownik", "uzytkownik")
                        .WithMany("treningi")
                        .HasForeignKey("id_uzytkownika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.TreningSzczegoly", b =>
                {
                    b.HasOne("WebApplication.Models.Cwiczenie", "cwiczenie")
                        .WithMany("treningi")
                        .HasForeignKey("id_cwiczenia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Trening", "trening")
                        .WithMany("cwiczenia")
                        .HasForeignKey("id_treningu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
