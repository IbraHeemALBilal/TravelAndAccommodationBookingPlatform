using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
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
                    { 1, "$2a$10$4BWLqbBdjU5AUrz9hWSlP.DFNA41eyP5rJGTXuZY9nxQpX6m0y4RW", "Admin", "admin" },
                    { 2, "$2a$10$zwr3fuiVExH8Kzy1I/sDce5FdI8wpDnKSdR0R1WTNbhAMOhdJP4Zi", "RegularUser", "User2" },
                    { 3, "$2a$10$f4usmcGNDPBJp/lt1.VUfOGerUx/.szx0DS/3cMLp4XF2B1p23/KO", "RegularUser", "User3" },
                    { 4, "$2a$10$MQKZdgzdDQgVqRuG1dckxO4VnGOHVx5H6hHaKtygAO1eUMbfLKHtO", "RegularUser", "User4" },
                    { 5, "$2a$10$taTjZrx9Ti3KJLS0LiDi4usZiBDzPh8itMXRY6ssyMupG96Xz5Cqq", "RegularUser", "User5" },
                    { 6, "$2a$10$CyQQOTcZUZlp.N00FWMXhOoNGW0Dpm2ANX/wCTYYEIOCGjJpHqjVa", "RegularUser", "User6" },
                    { 7, "$2a$10$D10Edid6MPbYQXnhskK85.LR0eiIWxS0cHBEHpijFKCoVA66jVA0S", "RegularUser", "User7" },
                    { 8, "$2a$10$vzhB79SF9VD0RzdBCQq9J.5TxKyqUJ1EF76TMcpSQqsb17lPjUzVG", "RegularUser", "User8" },
                    { 9, "$2a$10$0veNSF4j3dgb5joi/qShE.WhleAb7rzWQUuy.gzwSMxnFEcJlnKAa", "RegularUser", "User9" },
                    { 10, "$2a$10$CONaoWvkpxa6mimVWMTvFeW64xNEqksFYjqoH/bfW1Yojg.AcugSa", "RegularUser", "User10" },
                    { 11, "$2a$10$q/f7xNRWj4fD9yINGuRkg.IWBFw7SU4oQMCo/OlBsf6nx7hy6xzoK", "RegularUser", "User11" },
                    { 12, "$2a$10$oU60qReLaYrrbx2wGtsV9eeQSWHz9oHJKc9VyHsRY8.hDS4Xlaw2e", "RegularUser", "User12" },
                    { 13, "$2a$10$QdLLosxo0ohK0HTtegpLfeSaHxInVIn/LKqfF3s3WMdbwj0LCO1u2", "RegularUser", "User13" },
                    { 14, "$2a$10$n8CbgB.jS8fHV2hDBN/W6.wWYRyEGemAMDCuqf/V7.UajJybp2DIi", "RegularUser", "User14" },
                    { 15, "$2a$10$NWPqX4dLaad5BKzCUUPRkeKX6xVT68w8diqhKVBl2OjOB.zJe4WYi", "RegularUser", "User15" },
                    { 16, "$2a$10$KUzNGcX2kDgYbQ0cLjrm0OKWxsm6xwYJyHR5CzWoZ5hjdgqJ2xH7O", "RegularUser", "User16" },
                    { 17, "$2a$10$cZ/RepVh/JACB/WC.K/rrO.Meaap3Ut88.kcn9dS3kdxR4FY83O5e", "RegularUser", "User17" },
                    { 18, "$2a$10$Mk3GBDCb9rwiPglrxLSxvet120DrEjCswdkCE/bg/1ri1OSdWbe06", "RegularUser", "User18" },
                    { 19, "$2a$10$cZ/H1POlRvxXQzzn.QvQxOAS.nFTS3ys0irMUsFclZADcNuJW4UUy", "RegularUser", "User19" },
                    { 20, "$2a$10$yIzM5YWeA/njcNnKFA6g7.IQA1x5X.lq5GXJuwTdlzkUBv3Al4fAu", "RegularUser", "User20" }
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
