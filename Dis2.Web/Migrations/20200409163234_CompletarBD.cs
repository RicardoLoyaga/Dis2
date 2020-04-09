using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dis2.Web.Migrations
{
    public partial class CompletarBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "titulars",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "especialistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false),
                    Estado = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    TitularId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pacientes_titulars_TitularId",
                        column: x => x.TitularId,
                        principalTable: "titulars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tipoTratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoTratamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    EspecialistaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historias_especialistas_EspecialistaId",
                        column: x => x.EspecialistaId,
                        principalTable: "especialistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historias_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    NumeroTerapias = table.Column<int>(nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    HistoriaId = table.Column<int>(nullable: true),
                    TipoTratamientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tratamientos_historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tratamientos_tipoTratamientos_TipoTratamientoId",
                        column: x => x.TipoTratamientoId,
                        principalTable: "tipoTratamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ejercicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    TratamientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ejercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ejercicios_tratamientos_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "tratamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "actividads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    EjercicioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actividads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_actividads_ejercicios_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    ImagenUrl = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    ActividadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagens_actividads_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "actividads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sonidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    SonidoUrl = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    ActividadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sonidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sonidos_actividads_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "actividads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    VideoUrl = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 1, nullable: false),
                    ActividadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videos_actividads_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "actividads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actividads_EjercicioId",
                table: "actividads",
                column: "EjercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ejercicios_TratamientoId",
                table: "ejercicios",
                column: "TratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_historias_EspecialistaId",
                table: "historias",
                column: "EspecialistaId");

            migrationBuilder.CreateIndex(
                name: "IX_historias_PacienteId",
                table: "historias",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_imagens_ActividadId",
                table: "imagens",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_TitularId",
                table: "pacientes",
                column: "TitularId");

            migrationBuilder.CreateIndex(
                name: "IX_sonidos_ActividadId",
                table: "sonidos",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientos_HistoriaId",
                table: "tratamientos",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientos_TipoTratamientoId",
                table: "tratamientos",
                column: "TipoTratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_videos_ActividadId",
                table: "videos",
                column: "ActividadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagens");

            migrationBuilder.DropTable(
                name: "sonidos");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "actividads");

            migrationBuilder.DropTable(
                name: "ejercicios");

            migrationBuilder.DropTable(
                name: "tratamientos");

            migrationBuilder.DropTable(
                name: "historias");

            migrationBuilder.DropTable(
                name: "tipoTratamientos");

            migrationBuilder.DropTable(
                name: "especialistas");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "titulars");
        }
    }
}
