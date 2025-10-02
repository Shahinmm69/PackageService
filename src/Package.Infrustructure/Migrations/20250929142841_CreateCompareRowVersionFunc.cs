using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Package.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCompareRowVersionFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.RemoveCompareRowVersionFunc);
            migrationBuilder.Sql(SqlScripts.CreateCompareRowVersionFunc);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.RemoveCompareRowVersionFunc);
        }
    }
}
