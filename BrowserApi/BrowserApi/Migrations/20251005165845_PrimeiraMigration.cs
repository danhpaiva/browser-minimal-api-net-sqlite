using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrowserApi.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavegadorWeb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    VersaoAtual = table.Column<string>(type: "TEXT", nullable: false),
                    MotorRenderizacao = table.Column<string>(type: "TEXT", nullable: false),
                    BaseCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    Fornecedor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavegadorWeb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavegadorWeb");
        }
    }
}
