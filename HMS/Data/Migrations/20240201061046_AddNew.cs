using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Bookings",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
