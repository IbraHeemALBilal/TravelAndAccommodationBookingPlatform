using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    public partial class AddingDealsFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealEndDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$9R0FcPSx431i9ksG5zdFze3BU2tZpRxfwUqehGWG6xkVlc/x/wQZK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$10$8Gmkt9NokWqbSM.HhrszbOJ5h0kZif7BxFfATO066FbxISuo6vBCW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$10$5hcw366yzEIq.aLmfSOoDu19ggGljkRtkiq8J9/NlfuxfXd35WuAq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$10$DSVRAkWXeFIb4I8mfu65EOSsSXzUhgmlfgSrhgIWv4KXtGLHWFEPG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$10$Iec0gvlCtwR4aWLH43StmOaKAIe/0kwBsYaAGjBdZPMA6eUj2nRTK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$10$eIbyjwCLcGD.Dv6ff7O8Q.roMhahbELTWCeszq6KFHV.VbACNQVwi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$10$Z0fqrwv5TLVrG4v16tDbXe3did6zX/cIpU0PdKj29WjcvGwHDP./m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$10$vES8yi/5oY/AbyMAS8MH/uiRMnVIq5cur2zPDb83gtuc6tsKbzkoi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$10$QpG13/phWRpatEwS7OwRh.r8OqDbtxpa.nDXWnyLPNgBHG0NXeYxS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$10$bOerF/px91ri.Nek4GaQL.2iGMlS8uc1MST6mRmPabLSqhDleVYXC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "PasswordHash",
                value: "$2a$10$lkho4R7mpnbKChsJagLy0u079Y6ZrSK5r8Xb5ZZMq/cNLQyEJCMvO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "PasswordHash",
                value: "$2a$10$zfQykgtbp4yR2ZiJd56FsugHqu1MTkAVieug1Bve7hUSpZFl219IW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "PasswordHash",
                value: "$2a$10$IVBcZPJpRDnGJpHWwdEWfuyp9wc6mX4y/rlOwo5jYSfpfxMrPgDmi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "PasswordHash",
                value: "$2a$10$PyDzw5EdC3HaTbUIWHYpkubdyKxpi33o14LhVFYMIn9CGoLxRFAXW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "PasswordHash",
                value: "$2a$10$b8bFLZFFRo2R828vXQoOIujzLRMNU90YSrJ9/N890UckC5xFsXjPO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "PasswordHash",
                value: "$2a$10$qahiHx4U3IwBBdO1rA4pBeJZaAtTAyjssLmZg27TQwSu1T.xgawci");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "PasswordHash",
                value: "$2a$10$J3VD2Oz6bHBZSIwP0AdQk..mUiNZUp4RMihBwOnE5OaublJ6KIApy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "PasswordHash",
                value: "$2a$10$nZMuThPfwA0qQZshEu0hg.ImiW5288LuTEPC9B2jnyObJFXheaRea");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "PasswordHash",
                value: "$2a$10$hbSRIeCPyKzc1XBdJ20Fpuu4p/cG9/ETyMj3h6YMtKzVEBzWkHQPy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "PasswordHash",
                value: "$2a$10$r9XfFxRgoM3HXMx/DzhCS.EGey0W1LvEFvwzGYFB7kj51.a5quYPO");
        }
    }
}
