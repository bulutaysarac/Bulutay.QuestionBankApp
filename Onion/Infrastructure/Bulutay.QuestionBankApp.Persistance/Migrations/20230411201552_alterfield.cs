using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulutay.QuestionBankApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class alterfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Options",
                newName: "Body");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Options",
                newName: "Body");
        }
    }
}
