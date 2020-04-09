﻿// <auto-generated />
using System;
using Dis2.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dis2.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200409174213_CorrecionFechaDB")]
    partial class CorrecionFechaDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dis2.Web.Data.Entities.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalle");

                    b.Property<int?>("EjercicioId");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EjercicioId");

                    b.ToTable("actividads");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Ejercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalle");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("TratamientoId");

                    b.HasKey("Id");

                    b.HasIndex("TratamientoId");

                    b.ToTable("ejercicios");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Especialista", b =>
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

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("especialistas");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Historia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Detalle");

                    b.Property<int?>("EspecialistaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int?>("PacienteId");

                    b.HasKey("Id");

                    b.HasIndex("EspecialistaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("historias");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActividadId");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("ImagenUrl");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.ToTable("imagens");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("TitularId");

                    b.HasKey("Id");

                    b.HasIndex("TitularId");

                    b.ToTable("pacientes");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Sonido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActividadId");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SonidoUrl");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.ToTable("sonidos");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.TipoTratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("tipoTratamientos");
                });

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

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

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

            modelBuilder.Entity("Dis2.Web.Data.Entities.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalle");

                    b.Property<int?>("HistoriaId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("NumeroTerapias");

                    b.Property<int?>("TipoTratamientoId");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaId");

                    b.HasIndex("TipoTratamientoId");

                    b.ToTable("tratamientos");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActividadId");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Actividad", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Ejercicio", "Ejercicio")
                        .WithMany("Actividads")
                        .HasForeignKey("EjercicioId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Ejercicio", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Tratamiento", "Tratamiento")
                        .WithMany("Ejercicios")
                        .HasForeignKey("TratamientoId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Historia", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Especialista", "Especialista")
                        .WithMany("Historias")
                        .HasForeignKey("EspecialistaId");

                    b.HasOne("Dis2.Web.Data.Entities.Paciente", "Paciente")
                        .WithMany("Historias")
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Imagen", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Actividad", "Actividad")
                        .WithMany("Imagens")
                        .HasForeignKey("ActividadId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Paciente", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Titular", "Titular")
                        .WithMany("Pacientes")
                        .HasForeignKey("TitularId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Sonido", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Actividad", "Actividad")
                        .WithMany("Sonidos")
                        .HasForeignKey("ActividadId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Tratamiento", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Historia", "Historia")
                        .WithMany("Tratamientos")
                        .HasForeignKey("HistoriaId");

                    b.HasOne("Dis2.Web.Data.Entities.TipoTratamiento", "TipoTratamiento")
                        .WithMany("Tratamientos")
                        .HasForeignKey("TipoTratamientoId");
                });

            modelBuilder.Entity("Dis2.Web.Data.Entities.Video", b =>
                {
                    b.HasOne("Dis2.Web.Data.Entities.Actividad", "Actividad")
                        .WithMany("Videos")
                        .HasForeignKey("ActividadId");
                });
#pragma warning restore 612, 618
        }
    }
}