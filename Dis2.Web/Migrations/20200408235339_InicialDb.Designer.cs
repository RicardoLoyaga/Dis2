﻿// <auto-generated />
using Dis2.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dis2.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200408235339_InicialDb")]
    partial class InicialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dis2.Web.Data.Entities.Titular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("titulars");
                });
#pragma warning restore 612, 618
        }
    }
}
