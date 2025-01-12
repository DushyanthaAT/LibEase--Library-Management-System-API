using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibEaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAddedDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublicationYear",
                table: "Books",
                newName: "AddedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "Books",
                newName: "PublicationYear");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
