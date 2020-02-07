using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp2.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "Video",
                value: "https://www.youtube.com/embed/uPlmijjHRvw?autoplay=1&mute=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/embed/PbW1FFarLrg?autoplay=1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "Video",
                value: "https://www.youtube.com/embed/uPlmijjHRvw?autoplay=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/embed/PbW1FFarLrg?autoplay=1&mute=1;");
        }
    }
}
