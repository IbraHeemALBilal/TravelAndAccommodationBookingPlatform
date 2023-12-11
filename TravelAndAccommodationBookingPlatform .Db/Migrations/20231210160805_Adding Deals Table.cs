using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    public partial class AddingDealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealEndDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    DealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    DealPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.DealId);
                    table.ForeignKey(
                        name: "FK_Deals_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Deals_RoomId",
                table: "Deals",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.AddColumn<DateTime>(
                name: "DealEndDate",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$g5vCvlFOTZAvO5bJg9QeSutmlgzYZ5ql5OtoBfzMpCu52.CiBMgJ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$zffEKuRc.XvHmFch/hXEs.Yd2y/Wa.qew7XPnRLMMrElpNaDQoxhW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$DKUdu/3jKMi5Smd6y004R.xA2g/XTgZotBaHFSMlWUJZHQngrBm4e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$qYSZZvdJRokzJ6s4uXN1VOqYGBNoAjThp7uCDk.Y0sCscKPmCS0sq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$WqtTU4HEY1Z4LYB/L.AS.OvD00v.MqDMojIIHQXWbCGN/NyMEmd7S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$10$BGFfR5vquIo1jGkcziYEkOBiYgtwPv.o/y6GdkpWjTBKNi2r5e3.a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$10$4.K7pBQPZdlmDCOr.JozuuM.rRO801LgLHmMOzDjhPpW1g4kdRMg.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$10$eo4/dGeXUPmoT2/llA1gXeeUTEvglc/YC4RQ5eCrd8vR8X7pXan82");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$10$gUhIw1iVVmy5Vytj3fmmKeSZYGSEa4nY1uuVFjIbMYLAUbXx3lQxi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$10$sKCUgEgPDrI9V2ZkHY5v8.nusRHOQMQodUxyklqEB.5tcHwfzmS3K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "PasswordHash",
                value: "$2a$10$yBdOe4.Yl/ls55.st6Zb9u0sSDwBfJNz5A5oBmaROU2xkxon1PcNG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "PasswordHash",
                value: "$2a$10$S.Lj849F91fx9j4traSwd.YaUCM1AwZIorejTFVOXzDfeDM8zmyba");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "PasswordHash",
                value: "$2a$10$YazNnsERtgO6rf4bZXxRVeRNbFsBaAYN.nSTSaEIUK0a8vyQWju8m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "PasswordHash",
                value: "$2a$10$1gN/hTnBjmrxLvngBXQNa.frVaoJ5orEWwlFSG1YJtBtVheLf5P8i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "PasswordHash",
                value: "$2a$10$DR7gOraGt0qQ4c0RA0oC2OZCH991qxPWpxudmfr5/Loz7D42c0TVi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "PasswordHash",
                value: "$2a$10$jE7MJgP23lnPfeFscQYgCOB.k7dT5j5SBvFfxcN5hlwe7VIGjgLfO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "PasswordHash",
                value: "$2a$10$cqUWIkooHazRVyHN9OD20OVWjJOMoYCLwMUtlNVNFAqk6QF//ZPOu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "PasswordHash",
                value: "$2a$10$5ObsX2LZ3jfuy2r3fyF6P.cT5Je92h/1bWydM6EuUZbNi3gATo4vu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "PasswordHash",
                value: "$2a$10$xobcuFCjfQ.goAoKBQQJhuQu97xBORlDN2bnUWjL.mazp9FIIwF4O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "PasswordHash",
                value: "$2a$10$GyEpgg0Wf1WgWBwBjtQdvebsZLvTFPtb4LCowe4CcEoPW1sbQ72ay");
        }
    }
}
