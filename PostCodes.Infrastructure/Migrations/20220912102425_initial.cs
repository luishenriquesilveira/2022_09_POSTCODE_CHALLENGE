using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostCodes.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post_code",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    post_code_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quality = table.Column<int>(type: "int", nullable: false),
                    eastings = table.Column<int>(type: "int", nullable: true),
                    northings = table.Column<int>(type: "int", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nhs_ha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<float>(type: "real", nullable: true),
                    latitude = table.Column<float>(type: "real", nullable: true),
                    parliamentary_constituency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    european_electoral_region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_care_trust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lsoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    msoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ced = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ccg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nuts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_admin_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_admin_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_admin_ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_parish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_ccg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_ccg_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_nuts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_lau2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_lsoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_msoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distance_to_airport = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_code", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_code");
        }
    }
}
