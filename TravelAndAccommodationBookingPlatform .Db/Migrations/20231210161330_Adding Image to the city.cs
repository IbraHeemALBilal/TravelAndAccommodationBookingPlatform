using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    public partial class AddingImagetothecity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$wEnIrH5ShlVpWcbIJpMDl.Ibzh/rlKI938/K7spUFyPoOhr06p.Im");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$Wze9RE4Q/fUifWIG2VX9webaK6Ay7xYhdJcUhxpvprCPxF2hiIKGK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$FD0/.xPXzMYjJvJ68cS7peeTPPlKc0TpqJ52pbT6lAok8kyee3CQS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$Uhj6iEYdml/B5skLz32G.e.ppzIF7sb14dDFGdnPdmbi2CF3aZcuC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$btTnCSZcSkJEydsRrlrkwOiRM8AY5iHXDVA/oE9xAb0U8zLGhhOc2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$10$5YQo0d1DbphoYxXJRL1kYeeT4LXzA1xg7HeTQy9ux3EZH9Sx1wxS6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$10$TYo.C6v7V/LrId72kIhGleJhmh6MXpXlCr4EfyWbJYNl50LDmQwRe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$10$f3DDY6zAj0ZFoEJiIFCNPudFRC4Pj9JR0k7/KiiKWH7NLKKvoCUnO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$10$3uv56znrejFwL3std2PC.uxuaCTUbdStkFl5/PfkTvkrExZ4rbV32");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$10$71A4i32h1L8hnvIZU3KDR.U1UCkHeotbrh3RiNr76AmE.EoQBraGm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "PasswordHash",
                value: "$2a$10$v.dOWMh6LItm1kdtWQQ2ceG28cPCHjvE5FXyCloqyg6F4PKaDlodq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "PasswordHash",
                value: "$2a$10$ynY33n32XlQ.hlpAd8bDBO.BiyPj6jlOr1XMByiDxijKsFmS0t2yC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "PasswordHash",
                value: "$2a$10$JV/VhXBIcTkgnDnXoQr/A.hgIdsqobnjUPiuZ513Pvcgm1rLoctgq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "PasswordHash",
                value: "$2a$10$qHjg7WMklUaVQBoD8S1v9.1WVMbElgoKf7sqUtEWulfW57oPJ/UNG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "PasswordHash",
                value: "$2a$10$h.w5qE.5SsEs2Ucnq1u9Be63a7VonsI1bTzYBniOMeiKOzROMlyHS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "PasswordHash",
                value: "$2a$10$4zOtjKFftdcg2FPd9b8oO.p9Xre0xdxVXUXtUMSzq7suoKq1YwDAa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "PasswordHash",
                value: "$2a$10$s/p2KHPOPIlm0OlTugWRVehoucjbPSJkv7REPRPeozAhvxfbm3s.e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "PasswordHash",
                value: "$2a$10$UcR6Wp98w3UOCrsiTItqr.zutCDxqVH93dpA1uU0VkpCVQxCUiKZO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "PasswordHash",
                value: "$2a$10$qL7TN1QbGe0mGH04fnkfQuXluys1R.ulZKf885GHxY1RjW6VbE2mm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "PasswordHash",
                value: "$2a$10$SnfFuaGTZMvD0e2pbbhQWOS5xP1Hwvku6KHrGiaLJQ.ESPhsu5VNC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cities");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$CFTSwFwdNtFS2kW5MeYLZOJdfcMxYJDOPDO6.ak6EGRnbOlqP3jUa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$UuAVqw/uAUuax/TZc1tBtO6E1H0qsDsbWFOvSt4MLAdRBF95lj9ZG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$fa6RUtaLL6n.hVNmQB0zK.DkMe/xDDdi5kkzrtKG8q1WNNlQbDozq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$07jm5B5WmhkNFZw1zFYmOOZZfhEvQpOgGa4X3Q2NK9qg./ciAkuma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$97ujgKzPJt2cnnCdy8RNdumiQrsfQyj4nxqF5KKlfJG1k3Z1Cyky6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$10$K8LLMLQfK/NC4DBtoN6E1OoYszP15JP5IATdEXAeQDW8WYG/5ZdUm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$10$e1lG079p5InQWlWVgriEnuFU0Tl9riHinHQl2tAkMJ5Zb2hEH07F2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$10$HFBw0U6Ypkil.TA6asfiQe.jG5/duHiKBFZuvbeAm6S7TCIlsB4IC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$10$U6hQWxT8K/FLXCcu6bncC.gLO2WyCfye1cb2T.n/QWn3ywCXCDR1e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$10$.V9zcq9G7NXKlda5gdR0ze8k01Io0piE0fSiaGcMA39hMcF8fU3M6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "PasswordHash",
                value: "$2a$10$fdbwlzji19LhhuOjB61lMulyKQTRts3/ibuymQrGZaBV60dDNeuli");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "PasswordHash",
                value: "$2a$10$cjhngMALbGCWrvJ2Ra9yluH1ULEMDbiIz5Na2NKNpvmIHBt5hkd4u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "PasswordHash",
                value: "$2a$10$PV7DrZZgokXLcxf68HD9KOAOkfydDnJwMc48MDRizxyaAyx8HfXD6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "PasswordHash",
                value: "$2a$10$.eGjOkpM4GRIT.mmoiFNgeQL6qavrGDRLTeZRt.dAP03jd5wn4Tg6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "PasswordHash",
                value: "$2a$10$E90YDC/.jOGHOWeKiW1Soe.IcjPULEkSadaKdZlN/vEb59wXhTfVC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "PasswordHash",
                value: "$2a$10$xtOqBE5aNEINvRH7QCKP9u1qD8dUse7dqzitu7MIvhYpHguCCareK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "PasswordHash",
                value: "$2a$10$hXfRJqRxlKtxLi8El9QvgOHr5lFR8C.PhLBFB5sMixPi3U6j.8eFu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "PasswordHash",
                value: "$2a$10$ufIJLVrpGegyxYBs7ervQufoPA1BqKS.6n6RlI7yTvBImGwhlda2i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "PasswordHash",
                value: "$2a$10$bXrxtC4AFVWt7khjwODQoOJp4426yQ8EE8qANRhg9cOu0tLoPfJnu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "PasswordHash",
                value: "$2a$10$7gz9q0OkPhX.UT.FqJC2B.t6.G.jJVVjJAM3/tM/99prwCpJOyCo.");
        }
    }
}
