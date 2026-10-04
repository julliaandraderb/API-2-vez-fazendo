using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIS___2_VEZ_fazendo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarIdade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "usuarios");
        }
    }
}
