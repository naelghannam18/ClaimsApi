using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insured",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    InsuredName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insured", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredId = table.Column<int>(type: "int", nullable: false),
                    Hospital = table.Column<int>(type: "int", nullable: false),
                    TreatingDoctor = table.Column<int>(type: "int", nullable: false),
                    ClaimStatus = table.Column<int>(type: "int", nullable: false),
                    MedicalCase = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_Insured_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insured",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Insured",
                columns: new[] { "Id", "CardNumber", "CreatedDate", "DateOfBirth", "Gender", "InsuredName" },
                values: new object[,]
                {
                    { 1, "VC4dNg7UkXwQQMDT", new DateTime(2023, 6, 7, 9, 4, 55, 344, DateTimeKind.Local).AddTicks(3179), new DateTime(1974, 5, 13, 8, 30, 11, 857, DateTimeKind.Local).AddTicks(3413), 1, "Ben White" },
                    { 2, "OHybnfk7frvyXngW", new DateTime(2023, 5, 12, 19, 11, 25, 251, DateTimeKind.Local).AddTicks(2904), new DateTime(1990, 10, 15, 1, 44, 37, 820, DateTimeKind.Local).AddTicks(3662), 1, "Bethany Mertz" },
                    { 3, "8SvgeEvU073lYRTt", new DateTime(2023, 6, 23, 19, 30, 22, 254, DateTimeKind.Local).AddTicks(9084), new DateTime(1999, 3, 29, 15, 2, 46, 132, DateTimeKind.Local).AddTicks(4536), 2, "Tony Cassin" },
                    { 4, "ULaWAFDxTRNpwIgC", new DateTime(2023, 5, 2, 2, 27, 19, 452, DateTimeKind.Local).AddTicks(8339), new DateTime(1956, 10, 1, 9, 13, 16, 902, DateTimeKind.Local).AddTicks(8584), 1, "Cora Towne" },
                    { 5, "XbPzzQloDGrRnyTL", new DateTime(2022, 10, 3, 11, 49, 18, 454, DateTimeKind.Local).AddTicks(5608), new DateTime(1969, 7, 25, 12, 11, 4, 713, DateTimeKind.Local).AddTicks(2715), 2, "Nicole Vandervort" },
                    { 6, "O1uq3zwUI2M9ELdK", new DateTime(2022, 9, 27, 16, 16, 19, 846, DateTimeKind.Local).AddTicks(8001), new DateTime(1954, 1, 30, 12, 47, 29, 859, DateTimeKind.Local).AddTicks(8909), 2, "Vera Becker" },
                    { 7, "d9eps2pNx6UE56zF", new DateTime(2023, 5, 15, 8, 49, 30, 325, DateTimeKind.Local).AddTicks(2545), new DateTime(1972, 12, 6, 0, 41, 55, 43, DateTimeKind.Local).AddTicks(4364), 1, "Nina Grimes" },
                    { 8, "QfSzyt2NGjveB7Wp", new DateTime(2023, 2, 22, 23, 14, 58, 836, DateTimeKind.Local).AddTicks(3615), new DateTime(1992, 2, 3, 16, 7, 3, 679, DateTimeKind.Local).AddTicks(7752), 1, "Carlos Gulgowski" },
                    { 9, "fr6Xnxt2XEnqw3lR", new DateTime(2023, 5, 4, 15, 15, 58, 153, DateTimeKind.Local).AddTicks(1003), new DateTime(1979, 3, 10, 1, 35, 38, 564, DateTimeKind.Local).AddTicks(2097), 2, "Veronica Mante" },
                    { 10, "ie17ANhTCj5vhcu9", new DateTime(2023, 6, 28, 10, 44, 42, 939, DateTimeKind.Local).AddTicks(5972), new DateTime(1995, 4, 18, 5, 41, 3, 900, DateTimeKind.Local).AddTicks(4045), 1, "Priscilla Weber" }
                });

            migrationBuilder.InsertData(
                table: "Claim",
                columns: new[] { "Id", "AdmissionDate", "Amount", "ClaimStatus", "CreatedDate", "Hospital", "InsuredId", "MedicalCase", "Remarks", "TreatingDoctor" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 28, 11, 12, 32, 476, DateTimeKind.Local).AddTicks(4801), 9737m, 1, new DateTime(2022, 7, 28, 21, 47, 49, 734, DateTimeKind.Local).AddTicks(8028), 10, 7, "Disease-2", "Remark-2", 3 },
                    { 2, new DateTime(2023, 6, 27, 17, 45, 58, 694, DateTimeKind.Local).AddTicks(1497), 4264m, 2, new DateTime(2022, 9, 20, 13, 34, 41, 942, DateTimeKind.Local).AddTicks(2912), 14, 9, "Disease-3", "Remark-3", 18 },
                    { 3, new DateTime(2023, 6, 28, 8, 36, 2, 983, DateTimeKind.Local).AddTicks(1216), 9723m, 0, new DateTime(2022, 10, 14, 5, 0, 51, 752, DateTimeKind.Local).AddTicks(7405), 41, 7, "Disease-4", "Remark-4", 19 },
                    { 4, new DateTime(2023, 6, 28, 6, 58, 22, 97, DateTimeKind.Local).AddTicks(5377), 675m, 0, new DateTime(2023, 5, 29, 12, 11, 16, 763, DateTimeKind.Local).AddTicks(4361), 5, 8, "Disease-5", "Remark-5", 17 },
                    { 5, new DateTime(2023, 6, 28, 1, 0, 33, 328, DateTimeKind.Local).AddTicks(310), 2102m, 2, new DateTime(2022, 9, 20, 9, 11, 58, 147, DateTimeKind.Local).AddTicks(4052), 23, 8, "Disease-6", "Remark-6", 3 },
                    { 6, new DateTime(2023, 6, 28, 5, 55, 8, 752, DateTimeKind.Local).AddTicks(1262), 1754m, 2, new DateTime(2022, 11, 27, 3, 56, 46, 845, DateTimeKind.Local).AddTicks(2148), 33, 10, "Disease-7", "Remark-7", 12 },
                    { 7, new DateTime(2023, 6, 27, 15, 7, 7, 349, DateTimeKind.Local).AddTicks(146), 2708m, 1, new DateTime(2023, 5, 24, 20, 38, 4, 644, DateTimeKind.Local).AddTicks(7465), 22, 6, "Disease-8", "Remark-8", 2 },
                    { 8, new DateTime(2023, 6, 27, 13, 25, 3, 362, DateTimeKind.Local).AddTicks(726), 6465m, 2, new DateTime(2022, 9, 12, 18, 44, 14, 29, DateTimeKind.Local).AddTicks(7397), 23, 7, "Disease-9", "Remark-9", 1 },
                    { 9, new DateTime(2023, 6, 28, 1, 7, 45, 972, DateTimeKind.Local).AddTicks(612), 9065m, 1, new DateTime(2023, 3, 27, 5, 45, 1, 802, DateTimeKind.Local).AddTicks(8515), 31, 6, "Disease-10", "Remark-10", 1 },
                    { 10, new DateTime(2023, 6, 28, 5, 52, 45, 561, DateTimeKind.Local).AddTicks(3804), 1801m, 2, new DateTime(2022, 8, 21, 10, 6, 10, 437, DateTimeKind.Local).AddTicks(4871), 33, 6, "Disease-11", "Remark-11", 14 },
                    { 11, new DateTime(2023, 6, 28, 8, 15, 5, 796, DateTimeKind.Local).AddTicks(1220), 8491m, 1, new DateTime(2022, 10, 31, 1, 11, 11, 880, DateTimeKind.Local).AddTicks(2487), 32, 1, "Disease-12", "Remark-12", 12 },
                    { 12, new DateTime(2023, 6, 28, 0, 43, 58, 537, DateTimeKind.Local).AddTicks(7828), 3668m, 2, new DateTime(2022, 7, 11, 10, 54, 22, 225, DateTimeKind.Local).AddTicks(7627), 31, 10, "Disease-13", "Remark-13", 8 },
                    { 13, new DateTime(2023, 6, 27, 18, 42, 39, 829, DateTimeKind.Local).AddTicks(3199), 3357m, 2, new DateTime(2023, 5, 21, 5, 18, 43, 121, DateTimeKind.Local).AddTicks(5963), 44, 10, "Disease-14", "Remark-14", 5 },
                    { 14, new DateTime(2023, 6, 28, 3, 5, 7, 338, DateTimeKind.Local).AddTicks(9247), 6409m, 2, new DateTime(2022, 8, 10, 12, 51, 59, 987, DateTimeKind.Local).AddTicks(9521), 16, 1, "Disease-15", "Remark-15", 9 },
                    { 15, new DateTime(2023, 6, 27, 22, 32, 31, 750, DateTimeKind.Local).AddTicks(3758), 5306m, 1, new DateTime(2022, 10, 7, 15, 49, 22, 861, DateTimeKind.Local).AddTicks(1738), 7, 8, "Disease-16", "Remark-16", 16 },
                    { 16, new DateTime(2023, 6, 27, 21, 38, 8, 343, DateTimeKind.Local).AddTicks(9932), 3378m, 0, new DateTime(2022, 12, 31, 13, 19, 3, 2, DateTimeKind.Local).AddTicks(1678), 17, 3, "Disease-17", "Remark-17", 14 },
                    { 17, new DateTime(2023, 6, 27, 14, 15, 54, 218, DateTimeKind.Local).AddTicks(7409), 5753m, 2, new DateTime(2023, 4, 2, 11, 18, 4, 480, DateTimeKind.Local).AddTicks(4526), 43, 6, "Disease-18", "Remark-18", 10 },
                    { 18, new DateTime(2023, 6, 27, 17, 30, 13, 28, DateTimeKind.Local).AddTicks(3432), 7075m, 2, new DateTime(2023, 5, 20, 23, 51, 4, 416, DateTimeKind.Local).AddTicks(9500), 24, 4, "Disease-19", "Remark-19", 0 },
                    { 19, new DateTime(2023, 6, 28, 11, 32, 43, 720, DateTimeKind.Local).AddTicks(3505), 1882m, 0, new DateTime(2022, 9, 4, 5, 56, 17, 356, DateTimeKind.Local).AddTicks(9945), 15, 1, "Disease-20", "Remark-20", 10 },
                    { 20, new DateTime(2023, 6, 28, 5, 55, 45, 706, DateTimeKind.Local).AddTicks(5695), 416m, 2, new DateTime(2022, 9, 5, 7, 47, 9, 534, DateTimeKind.Local).AddTicks(4720), 12, 5, "Disease-21", "Remark-21", 2 },
                    { 21, new DateTime(2023, 6, 27, 13, 55, 10, 661, DateTimeKind.Local).AddTicks(3923), 8725m, 2, new DateTime(2023, 3, 10, 3, 15, 52, 154, DateTimeKind.Local).AddTicks(7609), 43, 6, "Disease-22", "Remark-22", 14 },
                    { 22, new DateTime(2023, 6, 27, 19, 9, 5, 769, DateTimeKind.Local).AddTicks(5361), 3499m, 0, new DateTime(2022, 10, 5, 10, 3, 58, 749, DateTimeKind.Local).AddTicks(3389), 27, 7, "Disease-23", "Remark-23", 8 },
                    { 23, new DateTime(2023, 6, 27, 17, 19, 58, 553, DateTimeKind.Local).AddTicks(3757), 2609m, 2, new DateTime(2022, 10, 2, 3, 46, 58, 600, DateTimeKind.Local).AddTicks(3969), 15, 2, "Disease-24", "Remark-24", 14 },
                    { 24, new DateTime(2023, 6, 28, 11, 27, 34, 867, DateTimeKind.Local).AddTicks(1290), 5136m, 2, new DateTime(2022, 7, 22, 12, 5, 39, 904, DateTimeKind.Local).AddTicks(5631), 40, 7, "Disease-25", "Remark-25", 3 },
                    { 25, new DateTime(2023, 6, 27, 22, 31, 58, 902, DateTimeKind.Local).AddTicks(7526), 460m, 2, new DateTime(2023, 4, 16, 6, 11, 0, 946, DateTimeKind.Local).AddTicks(9857), 35, 6, "Disease-26", "Remark-26", 6 },
                    { 26, new DateTime(2023, 6, 28, 2, 23, 57, 263, DateTimeKind.Local).AddTicks(152), 314m, 0, new DateTime(2022, 7, 17, 16, 35, 58, 195, DateTimeKind.Local).AddTicks(574), 15, 10, "Disease-27", "Remark-27", 11 },
                    { 27, new DateTime(2023, 6, 27, 18, 18, 19, 170, DateTimeKind.Local).AddTicks(7200), 683m, 1, new DateTime(2023, 5, 21, 19, 53, 16, 626, DateTimeKind.Local).AddTicks(9215), 31, 4, "Disease-28", "Remark-28", 8 },
                    { 28, new DateTime(2023, 6, 28, 5, 39, 29, 481, DateTimeKind.Local).AddTicks(7796), 8216m, 1, new DateTime(2022, 11, 13, 1, 33, 52, 905, DateTimeKind.Local).AddTicks(4508), 45, 4, "Disease-29", "Remark-29", 16 },
                    { 29, new DateTime(2023, 6, 27, 18, 18, 53, 61, DateTimeKind.Local).AddTicks(3629), 9884m, 0, new DateTime(2022, 8, 2, 13, 45, 44, 667, DateTimeKind.Local).AddTicks(8495), 0, 1, "Disease-30", "Remark-30", 18 },
                    { 30, new DateTime(2023, 6, 27, 15, 36, 46, 833, DateTimeKind.Local).AddTicks(6555), 7423m, 1, new DateTime(2022, 11, 11, 20, 56, 2, 156, DateTimeKind.Local).AddTicks(9802), 13, 3, "Disease-31", "Remark-31", 13 },
                    { 31, new DateTime(2023, 6, 28, 9, 51, 44, 503, DateTimeKind.Local).AddTicks(3019), 6435m, 2, new DateTime(2022, 10, 14, 22, 36, 53, 845, DateTimeKind.Local).AddTicks(3782), 6, 6, "Disease-32", "Remark-32", 10 },
                    { 32, new DateTime(2023, 6, 28, 9, 32, 5, 162, DateTimeKind.Local).AddTicks(7390), 6542m, 0, new DateTime(2023, 1, 28, 9, 49, 49, 523, DateTimeKind.Local).AddTicks(6057), 43, 4, "Disease-33", "Remark-33", 7 },
                    { 33, new DateTime(2023, 6, 28, 6, 15, 32, 221, DateTimeKind.Local).AddTicks(8076), 4478m, 2, new DateTime(2023, 3, 25, 21, 20, 15, 333, DateTimeKind.Local).AddTicks(9325), 30, 8, "Disease-34", "Remark-34", 3 },
                    { 34, new DateTime(2023, 6, 27, 22, 39, 19, 945, DateTimeKind.Local).AddTicks(3583), 2475m, 1, new DateTime(2022, 11, 23, 16, 29, 9, 387, DateTimeKind.Local).AddTicks(4464), 13, 4, "Disease-35", "Remark-35", 15 },
                    { 35, new DateTime(2023, 6, 27, 13, 13, 23, 291, DateTimeKind.Local).AddTicks(5122), 6827m, 2, new DateTime(2023, 6, 12, 8, 1, 59, 912, DateTimeKind.Local).AddTicks(4600), 13, 8, "Disease-36", "Remark-36", 5 },
                    { 36, new DateTime(2023, 6, 28, 7, 23, 0, 710, DateTimeKind.Local).AddTicks(3209), 6786m, 1, new DateTime(2022, 8, 16, 15, 29, 24, 428, DateTimeKind.Local).AddTicks(2474), 36, 6, "Disease-37", "Remark-37", 4 },
                    { 37, new DateTime(2023, 6, 27, 18, 4, 33, 667, DateTimeKind.Local).AddTicks(8617), 3881m, 2, new DateTime(2023, 5, 12, 16, 20, 14, 699, DateTimeKind.Local).AddTicks(8767), 9, 2, "Disease-38", "Remark-38", 19 },
                    { 38, new DateTime(2023, 6, 28, 7, 33, 14, 686, DateTimeKind.Local).AddTicks(9573), 1582m, 1, new DateTime(2022, 8, 14, 12, 53, 42, 684, DateTimeKind.Local).AddTicks(8506), 42, 4, "Disease-39", "Remark-39", 10 },
                    { 39, new DateTime(2023, 6, 28, 9, 57, 38, 496, DateTimeKind.Local).AddTicks(1205), 3993m, 0, new DateTime(2022, 10, 5, 7, 43, 12, 807, DateTimeKind.Local).AddTicks(6663), 0, 3, "Disease-40", "Remark-40", 9 },
                    { 40, new DateTime(2023, 6, 28, 1, 47, 46, 707, DateTimeKind.Local).AddTicks(3851), 7093m, 1, new DateTime(2022, 12, 23, 7, 8, 49, 187, DateTimeKind.Local).AddTicks(9515), 42, 3, "Disease-41", "Remark-41", 11 },
                    { 41, new DateTime(2023, 6, 28, 1, 25, 41, 939, DateTimeKind.Local).AddTicks(4437), 6942m, 2, new DateTime(2022, 12, 31, 13, 25, 3, 27, DateTimeKind.Local).AddTicks(8553), 5, 3, "Disease-42", "Remark-42", 12 },
                    { 42, new DateTime(2023, 6, 28, 2, 13, 0, 50, DateTimeKind.Local).AddTicks(6801), 9835m, 2, new DateTime(2022, 9, 26, 12, 16, 55, 491, DateTimeKind.Local).AddTicks(3002), 38, 9, "Disease-43", "Remark-43", 11 },
                    { 43, new DateTime(2023, 6, 28, 3, 10, 44, 674, DateTimeKind.Local).AddTicks(8234), 6731m, 2, new DateTime(2023, 1, 2, 18, 46, 31, 175, DateTimeKind.Local).AddTicks(7972), 18, 7, "Disease-44", "Remark-44", 5 },
                    { 44, new DateTime(2023, 6, 28, 8, 34, 1, 500, DateTimeKind.Local).AddTicks(6324), 7888m, 1, new DateTime(2023, 4, 10, 21, 53, 57, 37, DateTimeKind.Local).AddTicks(779), 11, 1, "Disease-45", "Remark-45", 17 },
                    { 45, new DateTime(2023, 6, 28, 11, 8, 42, 349, DateTimeKind.Local).AddTicks(5839), 8176m, 1, new DateTime(2022, 10, 25, 4, 45, 41, 815, DateTimeKind.Local).AddTicks(5744), 2, 10, "Disease-46", "Remark-46", 4 },
                    { 46, new DateTime(2023, 6, 28, 3, 40, 31, 498, DateTimeKind.Local).AddTicks(2986), 4202m, 1, new DateTime(2022, 12, 26, 14, 24, 16, 767, DateTimeKind.Local).AddTicks(6733), 21, 10, "Disease-47", "Remark-47", 1 },
                    { 47, new DateTime(2023, 6, 27, 21, 59, 19, 748, DateTimeKind.Local).AddTicks(2638), 1291m, 1, new DateTime(2023, 3, 27, 7, 50, 15, 410, DateTimeKind.Local).AddTicks(4683), 24, 4, "Disease-48", "Remark-48", 12 },
                    { 48, new DateTime(2023, 6, 28, 0, 48, 23, 903, DateTimeKind.Local).AddTicks(7912), 2032m, 1, new DateTime(2022, 11, 16, 1, 8, 0, 345, DateTimeKind.Local).AddTicks(2742), 13, 1, "Disease-49", "Remark-49", 12 },
                    { 49, new DateTime(2023, 6, 27, 13, 26, 45, 555, DateTimeKind.Local).AddTicks(3556), 486m, 0, new DateTime(2023, 4, 20, 1, 9, 42, 210, DateTimeKind.Local).AddTicks(2794), 10, 10, "Disease-50", "Remark-50", 16 },
                    { 50, new DateTime(2023, 6, 28, 2, 57, 41, 475, DateTimeKind.Local).AddTicks(4448), 283m, 1, new DateTime(2022, 11, 10, 7, 30, 20, 331, DateTimeKind.Local).AddTicks(2368), 1, 10, "Disease-51", "Remark-51", 10 },
                    { 51, new DateTime(2023, 6, 27, 22, 45, 37, 320, DateTimeKind.Local).AddTicks(1841), 6786m, 2, new DateTime(2023, 5, 5, 4, 10, 27, 461, DateTimeKind.Local).AddTicks(6088), 10, 6, "Disease-52", "Remark-52", 13 },
                    { 52, new DateTime(2023, 6, 28, 8, 57, 16, 168, DateTimeKind.Local).AddTicks(8291), 8532m, 0, new DateTime(2023, 1, 13, 23, 41, 48, 480, DateTimeKind.Local).AddTicks(3635), 15, 3, "Disease-53", "Remark-53", 19 },
                    { 53, new DateTime(2023, 6, 27, 17, 39, 48, 914, DateTimeKind.Local).AddTicks(8876), 3496m, 2, new DateTime(2023, 1, 23, 4, 21, 38, 258, DateTimeKind.Local).AddTicks(9550), 27, 1, "Disease-54", "Remark-54", 9 },
                    { 54, new DateTime(2023, 6, 28, 4, 42, 2, 169, DateTimeKind.Local).AddTicks(1725), 3921m, 0, new DateTime(2022, 8, 14, 2, 18, 11, 261, DateTimeKind.Local).AddTicks(5402), 23, 5, "Disease-55", "Remark-55", 10 },
                    { 55, new DateTime(2023, 6, 27, 12, 49, 59, 824, DateTimeKind.Local).AddTicks(2876), 5857m, 1, new DateTime(2022, 12, 14, 4, 35, 27, 968, DateTimeKind.Local).AddTicks(3958), 29, 2, "Disease-56", "Remark-56", 5 },
                    { 56, new DateTime(2023, 6, 28, 10, 6, 29, 477, DateTimeKind.Local).AddTicks(9887), 4625m, 2, new DateTime(2023, 6, 9, 22, 8, 28, 513, DateTimeKind.Local).AddTicks(7573), 30, 3, "Disease-57", "Remark-57", 7 },
                    { 57, new DateTime(2023, 6, 27, 17, 8, 57, 258, DateTimeKind.Local).AddTicks(4178), 6809m, 2, new DateTime(2022, 12, 24, 11, 52, 4, 781, DateTimeKind.Local).AddTicks(8007), 33, 2, "Disease-58", "Remark-58", 2 },
                    { 58, new DateTime(2023, 6, 28, 6, 29, 40, 667, DateTimeKind.Local).AddTicks(732), 2127m, 0, new DateTime(2023, 4, 1, 18, 50, 0, 123, DateTimeKind.Local).AddTicks(4975), 32, 9, "Disease-59", "Remark-59", 6 },
                    { 59, new DateTime(2023, 6, 27, 12, 26, 22, 413, DateTimeKind.Local).AddTicks(5259), 3566m, 1, new DateTime(2023, 5, 23, 5, 52, 36, 653, DateTimeKind.Local).AddTicks(1148), 40, 10, "Disease-60", "Remark-60", 7 },
                    { 60, new DateTime(2023, 6, 28, 7, 33, 58, 802, DateTimeKind.Local).AddTicks(9986), 6854m, 1, new DateTime(2022, 8, 26, 18, 59, 35, 329, DateTimeKind.Local).AddTicks(8910), 11, 7, "Disease-61", "Remark-61", 9 },
                    { 61, new DateTime(2023, 6, 28, 9, 24, 37, 61, DateTimeKind.Local).AddTicks(5044), 3273m, 0, new DateTime(2022, 9, 8, 21, 4, 30, 797, DateTimeKind.Local).AddTicks(5444), 11, 1, "Disease-62", "Remark-62", 12 },
                    { 62, new DateTime(2023, 6, 28, 6, 8, 30, 633, DateTimeKind.Local).AddTicks(2739), 7127m, 0, new DateTime(2022, 9, 27, 8, 3, 35, 536, DateTimeKind.Local).AddTicks(5493), 0, 5, "Disease-63", "Remark-63", 15 },
                    { 63, new DateTime(2023, 6, 28, 6, 17, 1, 986, DateTimeKind.Local).AddTicks(7713), 4620m, 0, new DateTime(2023, 6, 5, 22, 59, 23, 488, DateTimeKind.Local).AddTicks(9120), 43, 2, "Disease-64", "Remark-64", 5 },
                    { 64, new DateTime(2023, 6, 27, 17, 28, 57, 978, DateTimeKind.Local).AddTicks(8389), 2539m, 0, new DateTime(2022, 9, 29, 20, 42, 10, 504, DateTimeKind.Local).AddTicks(4909), 42, 6, "Disease-65", "Remark-65", 13 },
                    { 65, new DateTime(2023, 6, 27, 21, 16, 52, 426, DateTimeKind.Local).AddTicks(779), 4550m, 1, new DateTime(2023, 2, 15, 2, 27, 15, 941, DateTimeKind.Local).AddTicks(1983), 15, 3, "Disease-66", "Remark-66", 6 },
                    { 66, new DateTime(2023, 6, 28, 5, 36, 22, 207, DateTimeKind.Local).AddTicks(5254), 3202m, 2, new DateTime(2023, 5, 30, 17, 48, 0, 513, DateTimeKind.Local).AddTicks(5791), 5, 1, "Disease-67", "Remark-67", 12 },
                    { 67, new DateTime(2023, 6, 28, 2, 24, 41, 781, DateTimeKind.Local).AddTicks(7206), 506m, 2, new DateTime(2023, 1, 16, 13, 16, 29, 610, DateTimeKind.Local).AddTicks(4270), 3, 6, "Disease-68", "Remark-68", 13 },
                    { 68, new DateTime(2023, 6, 27, 13, 9, 11, 721, DateTimeKind.Local).AddTicks(939), 2311m, 1, new DateTime(2022, 12, 31, 10, 5, 10, 106, DateTimeKind.Local).AddTicks(6000), 17, 4, "Disease-69", "Remark-69", 19 },
                    { 69, new DateTime(2023, 6, 27, 23, 49, 6, 213, DateTimeKind.Local).AddTicks(1674), 3663m, 0, new DateTime(2022, 8, 20, 18, 44, 17, 625, DateTimeKind.Local).AddTicks(6107), 7, 6, "Disease-70", "Remark-70", 6 },
                    { 70, new DateTime(2023, 6, 28, 5, 34, 48, 685, DateTimeKind.Local).AddTicks(1707), 2934m, 2, new DateTime(2022, 12, 1, 23, 16, 3, 139, DateTimeKind.Local).AddTicks(7705), 38, 9, "Disease-71", "Remark-71", 8 },
                    { 71, new DateTime(2023, 6, 28, 2, 52, 56, 789, DateTimeKind.Local).AddTicks(6017), 3950m, 2, new DateTime(2023, 2, 27, 22, 39, 8, 152, DateTimeKind.Local).AddTicks(3242), 5, 3, "Disease-72", "Remark-72", 0 },
                    { 72, new DateTime(2023, 6, 27, 22, 40, 40, 478, DateTimeKind.Local).AddTicks(1623), 4080m, 2, new DateTime(2023, 3, 18, 12, 39, 57, 182, DateTimeKind.Local).AddTicks(7963), 35, 6, "Disease-73", "Remark-73", 9 },
                    { 73, new DateTime(2023, 6, 28, 0, 20, 34, 816, DateTimeKind.Local).AddTicks(2141), 7481m, 1, new DateTime(2023, 2, 12, 22, 10, 52, 521, DateTimeKind.Local).AddTicks(8084), 44, 8, "Disease-74", "Remark-74", 5 },
                    { 74, new DateTime(2023, 6, 27, 14, 59, 52, 186, DateTimeKind.Local).AddTicks(6703), 2909m, 1, new DateTime(2023, 1, 10, 12, 3, 35, 573, DateTimeKind.Local).AddTicks(3049), 30, 9, "Disease-75", "Remark-75", 3 },
                    { 75, new DateTime(2023, 6, 27, 21, 46, 30, 464, DateTimeKind.Local).AddTicks(900), 4111m, 1, new DateTime(2022, 8, 5, 8, 1, 19, 418, DateTimeKind.Local).AddTicks(4740), 42, 4, "Disease-76", "Remark-76", 12 },
                    { 76, new DateTime(2023, 6, 28, 0, 25, 10, 386, DateTimeKind.Local).AddTicks(1021), 6801m, 2, new DateTime(2023, 5, 27, 13, 9, 43, 276, DateTimeKind.Local).AddTicks(9407), 34, 2, "Disease-77", "Remark-77", 6 },
                    { 77, new DateTime(2023, 6, 27, 20, 32, 33, 99, DateTimeKind.Local).AddTicks(3879), 7194m, 2, new DateTime(2022, 10, 2, 9, 33, 20, 372, DateTimeKind.Local).AddTicks(5315), 40, 6, "Disease-78", "Remark-78", 13 },
                    { 78, new DateTime(2023, 6, 27, 22, 39, 46, 750, DateTimeKind.Local).AddTicks(1131), 3162m, 0, new DateTime(2023, 5, 24, 2, 59, 47, 493, DateTimeKind.Local).AddTicks(240), 40, 6, "Disease-79", "Remark-79", 9 },
                    { 79, new DateTime(2023, 6, 27, 23, 14, 18, 640, DateTimeKind.Local).AddTicks(7636), 2618m, 0, new DateTime(2022, 9, 13, 19, 45, 32, 635, DateTimeKind.Local).AddTicks(2130), 4, 6, "Disease-80", "Remark-80", 5 },
                    { 80, new DateTime(2023, 6, 28, 9, 51, 54, 570, DateTimeKind.Local).AddTicks(8131), 9938m, 0, new DateTime(2022, 7, 31, 3, 3, 26, 256, DateTimeKind.Local).AddTicks(5050), 24, 5, "Disease-81", "Remark-81", 13 },
                    { 81, new DateTime(2023, 6, 27, 12, 15, 4, 168, DateTimeKind.Local).AddTicks(3803), 5310m, 0, new DateTime(2022, 7, 9, 2, 46, 31, 838, DateTimeKind.Local).AddTicks(1555), 12, 5, "Disease-82", "Remark-82", 3 },
                    { 82, new DateTime(2023, 6, 28, 8, 14, 14, 547, DateTimeKind.Local).AddTicks(4623), 627m, 1, new DateTime(2023, 5, 1, 4, 40, 34, 901, DateTimeKind.Local).AddTicks(7720), 31, 1, "Disease-83", "Remark-83", 1 },
                    { 83, new DateTime(2023, 6, 27, 20, 48, 4, 994, DateTimeKind.Local).AddTicks(2148), 2713m, 1, new DateTime(2022, 6, 30, 23, 43, 0, 137, DateTimeKind.Local).AddTicks(1433), 45, 6, "Disease-84", "Remark-84", 0 },
                    { 84, new DateTime(2023, 6, 28, 2, 4, 36, 564, DateTimeKind.Local).AddTicks(1335), 7223m, 1, new DateTime(2023, 6, 21, 21, 8, 43, 655, DateTimeKind.Local).AddTicks(1146), 15, 1, "Disease-85", "Remark-85", 18 },
                    { 85, new DateTime(2023, 6, 27, 20, 28, 58, 127, DateTimeKind.Local).AddTicks(1974), 5708m, 0, new DateTime(2022, 9, 11, 1, 51, 7, 51, DateTimeKind.Local).AddTicks(258), 34, 10, "Disease-86", "Remark-86", 4 },
                    { 86, new DateTime(2023, 6, 27, 17, 28, 51, 364, DateTimeKind.Local).AddTicks(3158), 1390m, 0, new DateTime(2023, 4, 26, 5, 10, 11, 285, DateTimeKind.Local).AddTicks(4530), 30, 9, "Disease-87", "Remark-87", 16 },
                    { 87, new DateTime(2023, 6, 27, 12, 13, 59, 116, DateTimeKind.Local).AddTicks(1225), 2755m, 0, new DateTime(2022, 8, 22, 4, 15, 23, 505, DateTimeKind.Local).AddTicks(9950), 35, 10, "Disease-88", "Remark-88", 9 },
                    { 88, new DateTime(2023, 6, 27, 19, 40, 4, 435, DateTimeKind.Local).AddTicks(3200), 3524m, 0, new DateTime(2023, 2, 11, 20, 14, 28, 306, DateTimeKind.Local).AddTicks(143), 41, 7, "Disease-89", "Remark-89", 16 },
                    { 89, new DateTime(2023, 6, 27, 18, 48, 9, 123, DateTimeKind.Local).AddTicks(1690), 7925m, 0, new DateTime(2022, 10, 23, 13, 16, 22, 113, DateTimeKind.Local).AddTicks(963), 30, 1, "Disease-90", "Remark-90", 14 },
                    { 90, new DateTime(2023, 6, 28, 10, 21, 14, 53, DateTimeKind.Local).AddTicks(1589), 6877m, 1, new DateTime(2023, 4, 15, 6, 30, 5, 585, DateTimeKind.Local).AddTicks(2260), 9, 7, "Disease-91", "Remark-91", 1 },
                    { 91, new DateTime(2023, 6, 27, 15, 7, 21, 490, DateTimeKind.Local).AddTicks(1066), 932m, 0, new DateTime(2023, 5, 29, 6, 33, 15, 344, DateTimeKind.Local).AddTicks(4342), 27, 4, "Disease-92", "Remark-92", 19 },
                    { 92, new DateTime(2023, 6, 27, 20, 41, 29, 749, DateTimeKind.Local).AddTicks(7788), 1242m, 1, new DateTime(2023, 3, 22, 22, 0, 31, 744, DateTimeKind.Local).AddTicks(3108), 20, 10, "Disease-93", "Remark-93", 8 },
                    { 93, new DateTime(2023, 6, 27, 23, 50, 6, 164, DateTimeKind.Local).AddTicks(4593), 9213m, 1, new DateTime(2022, 11, 16, 8, 8, 44, 207, DateTimeKind.Local).AddTicks(7266), 19, 1, "Disease-94", "Remark-94", 1 },
                    { 94, new DateTime(2023, 6, 27, 15, 14, 15, 14, DateTimeKind.Local).AddTicks(4130), 8287m, 0, new DateTime(2023, 3, 23, 0, 46, 30, 745, DateTimeKind.Local).AddTicks(8788), 26, 7, "Disease-95", "Remark-95", 9 },
                    { 95, new DateTime(2023, 6, 28, 4, 38, 11, 71, DateTimeKind.Local).AddTicks(3689), 6276m, 0, new DateTime(2023, 3, 29, 3, 26, 21, 101, DateTimeKind.Local).AddTicks(8468), 0, 5, "Disease-96", "Remark-96", 16 },
                    { 96, new DateTime(2023, 6, 27, 17, 21, 6, 990, DateTimeKind.Local).AddTicks(5431), 9936m, 0, new DateTime(2023, 6, 9, 3, 18, 46, 534, DateTimeKind.Local).AddTicks(1263), 19, 9, "Disease-97", "Remark-97", 17 },
                    { 97, new DateTime(2023, 6, 28, 1, 37, 49, 809, DateTimeKind.Local).AddTicks(2566), 7700m, 1, new DateTime(2022, 11, 30, 14, 10, 57, 97, DateTimeKind.Local).AddTicks(2724), 11, 10, "Disease-98", "Remark-98", 7 },
                    { 98, new DateTime(2023, 6, 28, 10, 25, 34, 261, DateTimeKind.Local).AddTicks(4397), 6776m, 0, new DateTime(2022, 10, 21, 3, 9, 21, 410, DateTimeKind.Local).AddTicks(6452), 37, 6, "Disease-99", "Remark-99", 15 },
                    { 99, new DateTime(2023, 6, 28, 4, 11, 44, 239, DateTimeKind.Local).AddTicks(2535), 1173m, 2, new DateTime(2022, 10, 16, 10, 59, 56, 391, DateTimeKind.Local).AddTicks(1495), 38, 5, "Disease-100", "Remark-100", 4 },
                    { 100, new DateTime(2023, 6, 28, 6, 41, 37, 733, DateTimeKind.Local).AddTicks(4066), 9572m, 1, new DateTime(2022, 12, 9, 18, 27, 55, 293, DateTimeKind.Local).AddTicks(9905), 7, 2, "Disease-101", "Remark-101", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_Id",
                table: "Claim",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_InsuredId",
                table: "Claim",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Insured_CardNumber",
                table: "Insured",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insured_Id",
                table: "Insured",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Insured");
        }
    }
}
