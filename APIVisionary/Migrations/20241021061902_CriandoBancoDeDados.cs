using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVisionary.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosTableContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NascDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriationAccount = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTableContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaylisTableContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistTittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylisTableContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylisTableContent_UsuariosTableContent_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "UsuariosTableContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConteudoTableContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    PlaylistVideosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteudoTableContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConteudoTableContent_PlaylisTableContent_PlaylistVideosId",
                        column: x => x.PlaylistVideosId,
                        principalTable: "PlaylisTableContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConteudoTableContent_UsuariosTableContent_AutorId",
                        column: x => x.AutorId,
                        principalTable: "UsuariosTableContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistItemsTableContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteudoIdId = table.Column<int>(type: "int", nullable: false),
                    PlaylistIdId = table.Column<int>(type: "int", nullable: false),
                    ConteudoModelId = table.Column<int>(type: "int", nullable: true),
                    PlaylistVideosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItemsTableContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistItemsTableContent_ConteudoTableContent_ConteudoModelId",
                        column: x => x.ConteudoModelId,
                        principalTable: "ConteudoTableContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaylistItemsTableContent_PlaylisTableContent_PlaylistVideosId",
                        column: x => x.PlaylistVideosId,
                        principalTable: "PlaylisTableContent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoTableContent_AutorId",
                table: "ConteudoTableContent",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoTableContent_PlaylistVideosId",
                table: "ConteudoTableContent",
                column: "PlaylistVideosId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylisTableContent_CreatorId",
                table: "PlaylisTableContent",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItemsTableContent_ConteudoModelId",
                table: "PlaylistItemsTableContent",
                column: "ConteudoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItemsTableContent_PlaylistVideosId",
                table: "PlaylistItemsTableContent",
                column: "PlaylistVideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistItemsTableContent");

            migrationBuilder.DropTable(
                name: "ConteudoTableContent");

            migrationBuilder.DropTable(
                name: "PlaylisTableContent");

            migrationBuilder.DropTable(
                name: "UsuariosTableContent");
        }
    }
}
