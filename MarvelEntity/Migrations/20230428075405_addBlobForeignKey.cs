using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelEntity.Migrations
{
    /// <inheritdoc />
    public partial class addBlobForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "blob_id",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_blob_id",
                schema: "public",
                table: "users",
                column: "blob_id");

            migrationBuilder.AddForeignKey(
                name: "u__blob_id_fkey",
                schema: "public",
                table: "users",
                column: "blob_id",
                principalSchema: "public",
                principalTable: "blobs",
                principalColumn: "blob_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "u__blob_id_fkey",
                schema: "public",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_blob_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "blob_id",
                schema: "public",
                table: "users");
        }
    }
}
