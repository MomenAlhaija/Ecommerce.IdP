using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.IdP.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
                VALUES 
                (NEWID(), 'Admin', 'ADMIN', NEWID()),
                (NEWID(), 'User', 'USER', NEWID())
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        DELETE FROM AspNetRoles WHERE Name IN ('Admin', 'User')
    ");
        }
    }
}
