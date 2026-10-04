using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Update.Internal;

#nullable disable

namespace APIS___2_VEZ_fazendo.Migrations
{
    /// <inheritdoc />
    public partial class InserirIdades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE usuarios SET idade = 17 WHERE id = 3");
            migrationBuilder.Sql("UPDATE usuarios SET idade = 16 WHERE id = 4");
            migrationBuilder.Sql("UPDATE usuarios SET idade = 17 WHERE id = 6");
            migrationBuilder.Sql("UPDATE usuarios SET idade = 18 WHERE id = 7");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
