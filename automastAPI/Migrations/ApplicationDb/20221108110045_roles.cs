using Microsoft.EntityFrameworkCore.Migrations;

namespace automastAPI.Migrations.ApplicationDb
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a13da6895711", "fab4fac1-c546-41de-aebc-a13da6895711", "IdentityRole", "Admin", "ADMIN" },
                    { "c7b013f0-5201-4317-abd8-c211f91b730", "c7b013f0-5201-4317-abd8-c211f91b730", "IdentityRole", "Employee", "EMPLOYEE" },
                    { "fghiyu37-6790-6457-rty7-q5wyrty5j67", "fghiyu37-6790-6457-rty7-q5wyrty5j67", "IdentityRole", "Buyer", "BUYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "384fdb96-5e27-47bc-b844-97f5e24e34da", "adm@gmail.com", false, false, null, "ADM@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEBeNBdpWyaOkLLdZ8+EjdPDeX6/8tpzLI+EbdiIi67P7xfHkoGnDSZ0AgejGVPmdNw==", "1234567890", false, "d03293c6-aff9-42c5-a328-9de4c14d133b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a13da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b730");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fghiyu37-6790-6457-rty7-q5wyrty5j67");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a13da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a13da6895711");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
