using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVisionary.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoPlaylistItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistItemsTableContent",
                table: "PlaylistItemsTableContent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlaylistItemsTableContent");

            migrationBuilder.RenameColumn(
                name: "PlaylistIdId",
                table: "PlaylistItemsTableContent",
                newName: "PlaylistId");

            migrationBuilder.RenameColumn(
                name: "ConteudoIdId",
                table: "PlaylistItemsTableContent",
                newName: "ConteudoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistItemsTableContent",
                table: "PlaylistItemsTableContent",
                columns: new[] { "ConteudoId", "PlaylistId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistItemsTableContent",
                table: "PlaylistItemsTableContent");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "PlaylistItemsTableContent",
                newName: "PlaylistIdId");

            migrationBuilder.RenameColumn(
                name: "ConteudoId",
                table: "PlaylistItemsTableContent",
                newName: "ConteudoIdId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlaylistItemsTableContent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistItemsTableContent",
                table: "PlaylistItemsTableContent",
                column: "Id");
        }
    }
}
