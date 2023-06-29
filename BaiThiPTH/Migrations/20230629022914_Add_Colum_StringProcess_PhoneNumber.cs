using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiThiPTH.Migrations
{
    /// <inheritdoc />
    public partial class Add_Colum_StringProcess_PhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "StringProcess",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "StringProcess");
        }
    }
}
