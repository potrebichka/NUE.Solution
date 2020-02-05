using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp2.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 2,
                column: "Video",
                value: "https://www.youtube.com/embed/opXnPgW8FdY?autoplay=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "Video",
                value: "https://www.youtube.com/embed/bzlMCtirKRU?autoplay=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/embed/bzlMCtirKRU?autoplay=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "Video",
                value: "https://www.youtube.com/embed/rD_iJSEBBmE?autoplay=1");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "Video",
                value: "https://www.youtube.com/embed/vALaiN71aVI?autoplay=1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "Video",
                value: "https://www.youtube.com/embed/uPlmijjHRvw");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "Video",
                value: "https://www.youtube.com/embed/opXnPgW8FdY");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "Video",
                value: "https://www.youtube.com/embed/bzlMCtirKRU");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/embed/bzlMCtirKRU");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "Video",
                value: "https://www.youtube.com/embed/rD_iJSEBBmE");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "Video",
                value: "https://www.youtube.com/embed/vALaiN71aVI");
        }
    }
}
