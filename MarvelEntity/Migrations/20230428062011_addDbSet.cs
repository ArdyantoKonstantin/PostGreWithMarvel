using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelEntity.Migrations
{
    /// <inheritdoc />
    public partial class addDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "blob",
                schema: "public",
                newName: "blobs",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "blobs",
                schema: "public",
                newName: "blob",
                newSchema: "public");
        }
    }
}
