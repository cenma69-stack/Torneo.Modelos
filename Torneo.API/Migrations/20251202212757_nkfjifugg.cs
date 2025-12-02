using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Torneo.API.Migrations
{
    /// <inheritdoc />
    public partial class nkfjifugg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTorneo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTorneo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    Goles = table.Column<int>(type: "integer", nullable: false),
                    TarjetasAmarillas = table.Column<int>(type: "integer", nullable: false),
                    TarjetasRojas = table.Column<int>(type: "integer", nullable: false),
                    PartidosSuspendido = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechaInicio = table.Column<string>(type: "text", nullable: false),
                    fechaFin = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    TipoId = table.Column<int>(type: "integer", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    TipoTorneoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Torneo_TipoTorneo_TipoTorneoId",
                        column: x => x.TipoTorneoId,
                        principalTable: "TipoTorneo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquiposId = table.Column<int>(type: "integer", nullable: false),
                    TorneoId = table.Column<int>(type: "integer", nullable: false),
                    EquipoLocalId = table.Column<int>(type: "integer", nullable: false),
                    puntos = table.Column<int>(type: "integer", nullable: false),
                    GF = table.Column<int>(type: "integer", nullable: false),
                    GC = table.Column<int>(type: "integer", nullable: false),
                    diferencia = table.Column<int>(type: "integer", nullable: false),
                    partidosJugados = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partido_Torneo_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TorneoEquipo",
                columns: table => new
                {
                    TorneoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TorneoID = table.Column<int>(type: "integer", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    Puntos = table.Column<int>(type: "integer", nullable: false),
                    PartidosJugados = table.Column<int>(type: "integer", nullable: false),
                    GolesFavor = table.Column<int>(type: "integer", nullable: false),
                    GolesContra = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneoEquipo", x => x.TorneoId);
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Torneo_TorneoID",
                        column: x => x.TorneoID,
                        principalTable: "Torneo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_EquipoId",
                table: "Jugador",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_TorneoId",
                table: "Partido",
                column: "TorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneo_TipoTorneoId",
                table: "Torneo",
                column: "TipoTorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_EquipoId",
                table: "TorneoEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_TorneoID",
                table: "TorneoEquipo",
                column: "TorneoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "TorneoEquipo");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "TipoTorneo");
        }
    }
}
