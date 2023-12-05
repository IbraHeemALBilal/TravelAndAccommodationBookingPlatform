using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Domain.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$10$9ZWkEAfbtViqlvsIqkoy/OmYLu7THOQLopxoKNUQN2Dzqg86WSaLu", "Admin", "admin" },
                    { 2, "$2a$10$935GtjSbMKLITYeGpbRmMeSxOXvCMuqVLXpxrMrDns6VhKadGLrrC", "RegularUser", "User2" },
                    { 3, "$2a$10$7oI9wXkCI6.B6y8XzLA2T.k8VucOnicd3L5D4qFk/KHPhlfrIDf/O", "RegularUser", "User3" },
                    { 4, "$2a$10$F7UGLRuyoSBqqiy6KHf7t.XL57GLantKmHS4.A2uFpdrWZtmTuvvu", "RegularUser", "User4" },
                    { 5, "$2a$10$aD1rXbOSFtWmcCMcIGV1pelAXOOioykIUua7WaHR9Hh0FGqjsmXDG", "RegularUser", "User5" },
                    { 6, "$2a$10$HGguLdYnvADhTa3QVYJyzOdOTPNbGwHjsk.aAGAHRYJC/VdH7c30W", "RegularUser", "User6" },
                    { 7, "$2a$10$OEepZjdJOogt3MxEg25w8..IT0yPAi/aoifQJVK6SlSX2ovN/67s2", "RegularUser", "User7" },
                    { 8, "$2a$10$/4Iwy48kwg//yOzpgw06NuqNiI9WASa7HqgOjNnyDueyqqX4MIBrC", "RegularUser", "User8" },
                    { 9, "$2a$10$8Uh5Otsh8wNfeZZp1MtabOL6WZkAlkSKh1gd88RQyN7sU8smYx8li", "RegularUser", "User9" },
                    { 10, "$2a$10$o6oSnR33XX3KT.T1aRgunebn3dzWnDdkW2uM9/FPQKUubyqGQZU7y", "RegularUser", "User10" },
                    { 11, "$2a$10$rNKecs.UK6qwWJhgvO/3k.IAos.kpXa1yv4RgXZskTPwe3eL.gWV6", "RegularUser", "User11" },
                    { 12, "$2a$10$aUJJa9odD37ORTGnSGbZ7epsZ4jLWkNejhnh8YZGL01x1yTWhsbOu", "RegularUser", "User12" },
                    { 13, "$2a$10$hw8WQJ6JPz5UGcGri3npieahE7F5Umz5nUhVRdEhSO5LU155QJlOm", "RegularUser", "User13" },
                    { 14, "$2a$10$wNOmKz6hl.bxudaXsQMZwuNN3yP54MKFa9ZQDeb.Lj9CCXzRjw51S", "RegularUser", "User14" },
                    { 15, "$2a$10$8nrtxkKV8sZM/Se6YAL39OQSR163XReXErEhAUqImP24nMVWhjnkS", "RegularUser", "User15" },
                    { 16, "$2a$10$digfFZ.dDLTderlh1i6zdecKstQAY2pIXWoCniZpIXnyycohUAWZC", "RegularUser", "User16" },
                    { 17, "$2a$10$0vi8jlj/ew4aC98oM6n1Q.yHsPzilwPxBVGUoITlzi2RbiXxm9TZW", "RegularUser", "User17" },
                    { 18, "$2a$10$N6v6lYh0Ij2nbjiX2OTFNO1msqYAGCMIDtSi9cpiqMJpFej5EWhb.", "RegularUser", "User18" },
                    { 19, "$2a$10$j1ervRWfv0Zg4GSNqJb8reM8keeL6CPWhLx9ytjh8rQgd6PRbwfO.", "RegularUser", "User19" },
                    { 20, "$2a$10$jQAByxmJ57MUPmfCPsImpOlkcTxMOLCJGmgPEg/NU6DJttTz8crSm", "RegularUser", "User20" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20);
        }
    }
}
