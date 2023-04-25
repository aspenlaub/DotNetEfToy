using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy.Migrations {
    /// <inheritdoc />
    public partial class EntityFrameworkCore702 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Toys", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Toys");
        }
    }
}
