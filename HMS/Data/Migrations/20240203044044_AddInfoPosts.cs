using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MinSalaryRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxSalaryRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JobMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalLocation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    HospitalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostInfos");
        }
    }
}
