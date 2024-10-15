using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_02.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class adduserpermissioncustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permission_Permission_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId");
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Townships",
                columns: table => new
                {
                    TownshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownshipName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Townships", x => x.TownshipId);
                    table.ForeignKey(
                        name: "FK_Townships_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    TownshipId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Townships_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Townships",
                        principalColumn: "TownshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "آذربایجان شرقی" },
                    { 2, "آذربایجان غربی" },
                    { 3, "اردبیل" },
                    { 4, "اصفهان" },
                    { 5, "البرز" },
                    { 6, "ایلام" },
                    { 7, "بوشهر" },
                    { 8, "تهران" },
                    { 9, "چهارمحال وبختیاری" },
                    { 10, "خراسان جنوبی" },
                    { 11, "خراسان رضوی" },
                    { 12, "خراسان شمالی" },
                    { 13, "خوزستان" },
                    { 14, "زنجان" },
                    { 15, "سمنان" },
                    { 16, "سیستان وبلوچستان" },
                    { 17, "فارس" },
                    { 18, "قزوین" },
                    { 19, "قم" },
                    { 20, "کردستان" },
                    { 21, "کرمان" },
                    { 22, "کرمانشاه" },
                    { 23, "کهگیلویه وبویراحمد" },
                    { 24, "گلستان" },
                    { 25, "گیلان" },
                    { 26, "لرستان" },
                    { 27, "مازندران" },
                    { 28, "مرکزی" },
                    { 29, "هرمزگان" },
                    { 30, "همدان" },
                    { 31, "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Townships",
                columns: new[] { "TownshipId", "ProvinceId", "TownshipName" },
                values: new object[,]
                {
                    { 1, 13, "آبادان" },
                    { 2, 17, "آباده" },
                    { 3, 6, "آبدانان" },
                    { 4, 18, "آبیک" },
                    { 5, 1, "آذرشهر" },
                    { 6, 15, "آرادان" },
                    { 7, 4, "آران وبیدگل" },
                    { 8, 24, "آزادشهر" },
                    { 9, 25, "آستارا" },
                    { 10, 25, "آستانه اشرفیه" },
                    { 11, 28, "آشتیان" },
                    { 12, 13, "آغاجاری" },
                    { 13, 24, "آق قلا" },
                    { 14, 27, "آمل" },
                    { 15, 18, "آوج" },
                    { 16, 31, "ابرکوه" },
                    { 17, 29, "ابوموسی" },
                    { 18, 14, "ابهر" },
                    { 19, 28, "اراک" },
                    { 20, 3, "اردبیل" },
                    { 21, 4, "اردستان" },
                    { 22, 31, "اردکان" },
                    { 23, 9, "اردل" },
                    { 24, 21, "ارزوییه" },
                    { 25, 17, "ارسنجان" },
                    { 26, 2, "ارومیه" },
                    { 27, 26, "ازنا" },
                    { 28, 17, "استهبان" },
                    { 29, 30, "اسدآباد" },
                    { 30, 12, "اسفراین" },
                    { 31, 1, "اسکو" },
                    { 32, 22, "اسلام آبادغرب" },
                    { 33, 8, "اسلامشهر" },
                    { 34, 5, "اشتهارد" },
                    { 35, 31, "اشکذر" },
                    { 36, 2, "اشنویه" },
                    { 37, 4, "اصفهان" },
                    { 38, 3, "اصلاندوز" },
                    { 39, 17, "اقلید" },
                    { 40, 18, "البرز" },
                    { 41, 26, "الیگودرز" },
                    { 42, 25, "املش" },
                    { 43, 13, "امیدیه" },
                    { 44, 21, "انار" },
                    { 45, 13, "اندیکا" },
                    { 46, 13, "اندیمشک" },
                    { 47, 17, "اوز" },
                    { 48, 1, "اهر" },
                    { 49, 13, "اهواز" },
                    { 50, 14, "ایجرود" },
                    { 51, 13, "ایذه" },
                    { 52, 16, "ایرانشهر" },
                    { 53, 6, "ایلام" },
                    { 54, 6, "ایوان" },
                    { 55, 27, "بابل" },
                    { 56, 27, "بابلسر" },
                    { 57, 11, "باخرز" },
                    { 58, 23, "باشت" },
                    { 59, 13, "باغ ملک" },
                    { 60, 21, "بافت" },
                    { 61, 31, "بافق" },
                    { 62, 20, "بانه" },
                    { 63, 13, "باوی" },
                    { 64, 11, "بجستان" },
                    { 65, 12, "بجنورد" },
                    { 66, 17, "بختگان" },
                    { 67, 6, "بدره" },
                    { 68, 4, "برخوار" },
                    { 69, 11, "بردسکن" },
                    { 70, 21, "بردسیر" },
                    { 71, 26, "بروجرد" },
                    { 72, 9, "بروجن" },
                    { 73, 1, "بستان آباد" },
                    { 74, 29, "بستک" },
                    { 75, 29, "بشاگرد" },
                    { 76, 10, "بشرویه" },
                    { 77, 21, "بم" },
                    { 78, 16, "بمپور" },
                    { 79, 9, "بن" },
                    { 80, 1, "بناب" },
                    { 81, 25, "بندرانزلی" },
                    { 82, 29, "بندرعباس" },
                    { 83, 24, "بندرگز" },
                    { 84, 29, "بندرلنگه" },
                    { 85, 13, "بندرماهشهر" },
                    { 86, 4, "بو یین و میاندشت" },
                    { 87, 17, "بوانات" },
                    { 88, 7, "بوشهر" },
                    { 89, 2, "بوکان" },
                    { 90, 23, "بویراحمد" },
                    { 91, 18, "بویین زهرا" },
                    { 92, 31, "بهاباد" },
                    { 93, 30, "بهار" },
                    { 94, 8, "بهارستان" },
                    { 95, 13, "بهبهان" },
                    { 96, 27, "بهشهر" },
                    { 97, 23, "بهمیی" },
                    { 98, 20, "بیجار" },
                    { 99, 10, "بیرجند" },
                    { 100, 17, "بیضا" },
                    { 101, 3, "بیله سوار" },
                    { 102, 11, "بینالود" },
                    { 103, 3, "پارس آباد" },
                    { 104, 29, "پارسیان" },
                    { 105, 17, "پاسارگاد" },
                    { 106, 8, "پاکدشت" },
                    { 107, 22, "پاوه" },
                    { 108, 8, "پردیس" },
                    { 109, 26, "پلدختر" },
                    { 110, 2, "پلدشت" },
                    { 111, 2, "پیرانشهر" },
                    { 112, 8, "پیشوا" },
                    { 113, 18, "تاکستان" },
                    { 114, 11, "تایباد" },
                    { 115, 1, "تبریز" },
                    { 116, 11, "تربت جام" },
                    { 117, 11, "تربت حیدریه" },
                    { 118, 24, "ترکمن" },
                    { 119, 31, "تفت" },
                    { 120, 16, "تفتان" },
                    { 121, 28, "تفرش" },
                    { 122, 2, "تکاب" },
                    { 123, 27, "تنکابن" },
                    { 124, 7, "تنگستان" },
                    { 125, 30, "تویسرکان" },
                    { 126, 8, "تهران" },
                    { 127, 4, "تیران وکرون" },
                    { 128, 22, "ثلاث باباجانی" },
                    { 129, 12, "جاجرم" },
                    { 130, 29, "جاسک" },
                    { 131, 11, "جغتای" },
                    { 132, 1, "جلفا" },
                    { 133, 7, "جم" },
                    { 134, 22, "جوانرود" },
                    { 135, 27, "جویبار" },
                    { 136, 11, "جوین" },
                    { 137, 17, "جهرم" },
                    { 138, 21, "جیرفت" },
                    { 139, 4, "چادگان" },
                    { 140, 1, "چاراویماق" },
                    { 141, 2, "چالدران" },
                    { 142, 27, "چالوس" },
                    { 143, 16, "چاه بهار" },
                    { 144, 2, "چایپاره" },
                    { 145, 23, "چرام" },
                    { 146, 6, "چرداول" },
                    { 147, 26, "چگنی" },
                    { 148, 11, "چناران" },
                    { 149, 29, "حاجی اباد" },
                    { 150, 13, "حمیدیه" },
                    { 151, 31, "خاتم" },
                    { 152, 16, "خاش" },
                    { 153, 9, "خانمیرزا" },
                    { 154, 1, "خداآفرین" },
                    { 155, 14, "خدابنده" },
                    { 156, 17, "خرامه" },
                    { 157, 26, "خرم آباد" },
                    { 158, 17, "خرم بید" },
                    { 159, 14, "خرمدره" },
                    { 160, 13, "خرمشهر" },
                    { 161, 17, "خفر" },
                    { 162, 3, "خلخال" },
                    { 163, 11, "خلیل آباد" },
                    { 164, 29, "خمیر" },
                    { 165, 28, "خمین" },
                    { 166, 4, "خمینی شهر" },
                    { 167, 17, "خنج" },
                    { 168, 28, "خنداب" },
                    { 169, 11, "خواف" },
                    { 170, 4, "خوانسار" },
                    { 171, 4, "خور و بیابانک" },
                    { 172, 10, "خوسف" },
                    { 173, 11, "خوشاب" },
                    { 174, 2, "خوی" },
                    { 175, 17, "داراب" },
                    { 176, 22, "دالاهو" },
                    { 177, 15, "دامغان" },
                    { 178, 11, "داورزن" },
                    { 179, 11, "درگز" },
                    { 180, 30, "درگزین" },
                    { 181, 10, "درمیان" },
                    { 182, 6, "دره شهر" },
                    { 183, 13, "دزفول" },
                    { 184, 13, "دشت آزادگان" },
                    { 185, 7, "دشتستان" },
                    { 186, 7, "دشتی" },
                    { 187, 16, "دشتیاری" },
                    { 188, 26, "دلفان" },
                    { 189, 16, "دلگان" },
                    { 190, 28, "دلیجان" },
                    { 191, 8, "دماوند" },
                    { 192, 23, "دنا" },
                    { 193, 26, "دورود" },
                    { 194, 4, "دهاقان" },
                    { 195, 20, "دهگلان" },
                    { 196, 6, "دهلران" },
                    { 197, 7, "دیر" },
                    { 198, 7, "دیلم" },
                    { 199, 20, "دیواندره" },
                    { 200, 21, "رابر" },
                    { 201, 12, "راز و جرگلان" },
                    { 202, 16, "راسک" },
                    { 203, 27, "رامسر" },
                    { 204, 13, "رامشیر" },
                    { 205, 13, "رامهرمز" },
                    { 206, 24, "رامیان" },
                    { 207, 21, "راور" },
                    { 208, 8, "رباط کریم" },
                    { 209, 30, "رزن" },
                    { 210, 17, "رستم" },
                    { 211, 25, "رشت" },
                    { 212, 11, "رشتخوار" },
                    { 213, 25, "رضوانشهر" },
                    { 214, 21, "رفسنجان" },
                    { 215, 22, "روانسر" },
                    { 216, 29, "رودان" },
                    { 217, 25, "رودبار" },
                    { 218, 21, "رودبارجنوب" },
                    { 219, 25, "رودسر" },
                    { 220, 26, "رومشکان" },
                    { 221, 8, "ری" },
                    { 222, 21, "ریگان" },
                    { 223, 16, "زابل" },
                    { 224, 11, "زاوه" },
                    { 225, 16, "زاهدان" },
                    { 226, 17, "زرقان" },
                    { 227, 21, "زرند" },
                    { 228, 28, "زرندیه" },
                    { 229, 17, "زرین دشت" },
                    { 230, 14, "زنجان" },
                    { 231, 16, "زهک" },
                    { 232, 10, "زیرکوه" },
                    { 233, 27, "ساری" },
                    { 234, 9, "سامان" },
                    { 235, 5, "ساوجبلاغ" },
                    { 236, 28, "ساوه" },
                    { 237, 11, "سبزوار" },
                    { 238, 17, "سپیدان" },
                    { 239, 1, "سراب" },
                    { 240, 16, "سراوان" },
                    { 241, 10, "سرایان" },
                    { 242, 16, "سرباز" },
                    { 243, 10, "سربیشه" },
                    { 244, 22, "سرپل ذهاب" },
                    { 245, 17, "سرچهان" },
                    { 246, 11, "سرخس" },
                    { 247, 15, "سرخه" },
                    { 248, 2, "سردشت" },
                    { 249, 3, "سرعین" },
                    { 250, 20, "سروآباد" },
                    { 251, 17, "سروستان" },
                    { 252, 20, "سقز" },
                    { 253, 26, "سلسله" },
                    { 254, 14, "سلطانیه" },
                    { 255, 2, "سلماس" },
                    { 256, 15, "سمنان" },
                    { 257, 4, "سمیرم" },
                    { 258, 22, "سنقر" },
                    { 259, 20, "سنندج" },
                    { 260, 27, "سوادکوه" },
                    { 261, 27, "سوادکوه شمالی" },
                    { 262, 25, "سیاهکل" },
                    { 263, 16, "سیب و سوران" },
                    { 264, 21, "سیرجان" },
                    { 265, 6, "سیروان" },
                    { 266, 29, "سیریک" },
                    { 267, 27, "سیمرغ" },
                    { 268, 13, "شادگان" },
                    { 269, 28, "شازند" },
                    { 270, 15, "شاهرود" },
                    { 271, 2, "شاهین دژ" },
                    { 272, 4, "شاهین شهرومیمه" },
                    { 273, 1, "شبستر" },
                    { 274, 25, "شفت" },
                    { 275, 8, "شمیرانات" },
                    { 276, 13, "شوش" },
                    { 277, 13, "شوشتر" },
                    { 278, 2, "شوط" },
                    { 279, 21, "شهربابک" },
                    { 280, 4, "شهرضا" },
                    { 281, 9, "شهرکرد" },
                    { 282, 8, "شهریار" },
                    { 283, 17, "شیراز" },
                    { 284, 12, "شیروان" },
                    { 285, 11, "صالح آباد" },
                    { 286, 22, "صحنه" },
                    { 287, 25, "صومعه سرا" },
                    { 288, 14, "طارم" },
                    { 289, 5, "طالقان" },
                    { 290, 10, "طبس" },
                    { 291, 25, "طوالش" },
                    { 292, 27, "عباس آباد" },
                    { 293, 1, "عجب شیر" },
                    { 294, 7, "عسلویه" },
                    { 295, 24, "علی آباد کتول" },
                    { 296, 21, "عنبرآباد" },
                    { 297, 9, "فارسان" },
                    { 298, 12, "فاروج" },
                    { 299, 21, "فاریاب" },
                    { 300, 30, "فامنین" },
                    { 301, 17, "فراشبند" },
                    { 302, 28, "فراهان" },
                    { 303, 10, "فردوس" },
                    { 304, 5, "فردیس" },
                    { 305, 4, "فریدن" },
                    { 306, 4, "فریدونشهر" },
                    { 307, 27, "فریدونکنار" },
                    { 308, 11, "فریمان" },
                    { 309, 17, "فسا" },
                    { 310, 4, "فلاورجان" },
                    { 311, 16, "فنوج" },
                    { 312, 25, "فومن" },
                    { 313, 21, "فهرج" },
                    { 314, 17, "فیروزآباد" },
                    { 315, 8, "فیروزکوه" },
                    { 316, 11, "فیروزه" },
                    { 317, 27, "قایم شهر" },
                    { 318, 10, "قاینات" },
                    { 319, 8, "قدس" },
                    { 320, 8, "قرچک" },
                    { 321, 20, "قروه" },
                    { 322, 18, "قزوین" },
                    { 323, 29, "قشم" },
                    { 324, 22, "قصرشیرین" },
                    { 325, 16, "قصرقند" },
                    { 326, 21, "قلعه گنج" },
                    { 327, 19, "قم" },
                    { 328, 11, "قوچان" },
                    { 329, 17, "قیروکارزین" },
                    { 330, 13, "کارون" },
                    { 331, 17, "کازرون" },
                    { 332, 4, "کاشان" },
                    { 333, 11, "کاشمر" },
                    { 334, 20, "کامیاران" },
                    { 335, 30, "کبودرآهنگ" },
                    { 336, 5, "کرج" },
                    { 337, 24, "کردکوی" },
                    { 338, 21, "کرمان" },
                    { 339, 22, "کرمانشاه" },
                    { 340, 11, "کلات" },
                    { 341, 27, "کلاردشت" },
                    { 342, 24, "کلاله" },
                    { 343, 1, "کلیبر" },
                    { 344, 28, "کمیجان" },
                    { 345, 16, "کنارک" },
                    { 346, 7, "کنگان" },
                    { 347, 22, "کنگاور" },
                    { 348, 17, "کوار" },
                    { 349, 3, "کوثر" },
                    { 350, 17, "کوه چنار" },
                    { 351, 21, "کوهبنان" },
                    { 352, 26, "کوهدشت" },
                    { 353, 9, "کوهرنگ" },
                    { 354, 11, "کوهسرخ" },
                    { 355, 23, "کهگیلویه" },
                    { 356, 21, "کهنوج" },
                    { 357, 9, "کیار" },
                    { 358, 24, "گالیکش" },
                    { 359, 13, "گتوند" },
                    { 360, 23, "گچساران" },
                    { 361, 17, "گراش" },
                    { 362, 24, "گرگان" },
                    { 363, 15, "گرمسار" },
                    { 364, 12, "گرمه" },
                    { 365, 3, "گرمی" },
                    { 366, 4, "گلپایگان" },
                    { 367, 27, "گلوگاه" },
                    { 368, 24, "گمیشان" },
                    { 369, 11, "گناباد" },
                    { 370, 7, "گناوه" },
                    { 371, 24, "گنبدکاووس" },
                    { 372, 22, "گیلانغرب" },
                    { 373, 17, "لارستان" },
                    { 374, 13, "لالی" },
                    { 375, 17, "لامرد" },
                    { 376, 25, "لاهیجان" },
                    { 377, 9, "لردگان" },
                    { 378, 4, "لنجان" },
                    { 379, 23, "لنده" },
                    { 380, 25, "لنگرود" },
                    { 381, 23, "مارگون" },
                    { 382, 25, "ماسال" },
                    { 383, 2, "ماکو" },
                    { 384, 12, "مانه وسملقان" },
                    { 385, 14, "ماهنشان" },
                    { 386, 4, "مبارکه" },
                    { 387, 28, "محلات" },
                    { 388, 27, "محمودآباد" },
                    { 389, 1, "مراغه" },
                    { 390, 24, "مراوه تپه" },
                    { 391, 1, "مرند" },
                    { 392, 17, "مرودشت" },
                    { 393, 20, "مریوان" },
                    { 394, 13, "مسجدسلیمان" },
                    { 395, 3, "مشگین شهر" },
                    { 396, 11, "مشهد" },
                    { 397, 8, "ملارد" },
                    { 398, 30, "ملایر" },
                    { 399, 1, "ملکان" },
                    { 400, 6, "ملکشاهی" },
                    { 401, 17, "ممسنی" },
                    { 402, 21, "منوجان" },
                    { 403, 11, "مه ولات" },
                    { 404, 2, "مهاباد" },
                    { 405, 15, "مهدی شهر" },
                    { 406, 17, "مهر" },
                    { 407, 6, "مهران" },
                    { 408, 16, "مهرستان" },
                    { 409, 31, "مهریز" },
                    { 410, 15, "میامی" },
                    { 411, 2, "میاندوآب" },
                    { 412, 27, "میاندورود" },
                    { 413, 1, "میانه" },
                    { 414, 31, "میبد" },
                    { 415, 16, "میرجاوه" },
                    { 416, 29, "میناب" },
                    { 417, 24, "مینودشت" },
                    { 418, 4, "نایین" },
                    { 419, 4, "نجف آباد" },
                    { 420, 21, "نرماشیر" },
                    { 421, 4, "نطنز" },
                    { 422, 5, "نظرآباد" },
                    { 423, 2, "نقده" },
                    { 424, 27, "نکا" },
                    { 425, 3, "نمین" },
                    { 426, 27, "نور" },
                    { 427, 27, "نوشهر" },
                    { 428, 30, "نهاوند" },
                    { 429, 10, "نهبندان" },
                    { 430, 17, "نی ریز" },
                    { 431, 3, "نیر" },
                    { 432, 11, "نیشابور" },
                    { 433, 16, "نیک شهر" },
                    { 434, 16, "نیمروز" },
                    { 435, 8, "ورامین" },
                    { 436, 1, "ورزقان" },
                    { 437, 16, "هامون" },
                    { 438, 22, "هرسین" },
                    { 439, 1, "هریس" },
                    { 440, 1, "هشترود" },
                    { 441, 13, "هفتکل" },
                    { 442, 6, "هلیلان" },
                    { 443, 30, "همدان" },
                    { 444, 13, "هندیجان" },
                    { 445, 1, "هوراند" },
                    { 446, 13, "هویزه" },
                    { 447, 16, "هیرمند" },
                    { 448, 31, "یزد" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ParentId",
                table: "Permission",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Townships_ProvinceId",
                table: "Townships",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Townships");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
