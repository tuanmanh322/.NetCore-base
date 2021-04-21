using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QRCODE_API.Migrations
{
    public partial class QrCodeApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "codesetting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLASS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NO = table.Column<int>(type: "int", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLACEHOLDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODEDATA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CRT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHG_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHG_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codesetting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "customer_info",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUS_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUS_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUS_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUS_TEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EXPIRED_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_NUM_ALLOW = table.Column<int>(type: "int", nullable: false),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CRT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHG_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHG_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_info", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "qrcode_image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUS_ID = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CRT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHG_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHG_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qrcode_image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "qrcode_info",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_INFO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COUNT = table.Column<int>(type: "int", nullable: false),
                    STARTDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QRCODEYN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BODYTEMPER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENTRANCETIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WHOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WHERE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qrcode_info", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CRT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHG_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CHG_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FULLNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETE_YN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CRT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHG_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHG_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    LAST_TIME_LOGIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOGIN_YN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "codesetting");

            migrationBuilder.DropTable(
                name: "customer_info");

            migrationBuilder.DropTable(
                name: "qrcode_image");

            migrationBuilder.DropTable(
                name: "qrcode_info");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_login");
        }
    }
}
