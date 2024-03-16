using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_comment_email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Comments",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Comments",
                newName: "ImageUrl");
        }
    }
}
