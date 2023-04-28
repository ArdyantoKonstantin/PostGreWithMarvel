using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelEntity.Migrations
{
    /// <inheritdoc />
    public partial class blobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blob",
                schema: "public",
                columns: table => new
                {
                    blob_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: true),
                    file_path = table.Column<string>(type: "text", nullable: true),
                    mime = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("blob_pkey", x => x.blob_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blob",
                schema: "public");
        }
    }
}
