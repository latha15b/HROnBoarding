using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class AddStateCityOtpGenerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationQualifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationQualifications");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PersonalDetails");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtpGeneratorOtpId",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "EducationQualifications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OtpGenerator",
                columns: table => new
                {
                    OtpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNumber = table.Column<string>(nullable: false),
                    OtpCode = table.Column<string>(nullable: false),
                    TimeoutTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpGenerator", x => x.OtpId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_CityId",
                table: "PersonalDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_OtpGeneratorOtpId",
                table: "PersonalDetails",
                column: "OtpGeneratorOtpId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_StateId",
                table: "PersonalDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationQualifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationQualifications",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_City_CityId",
                table: "PersonalDetails",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_OtpGenerator_OtpGeneratorOtpId",
                table: "PersonalDetails",
                column: "OtpGeneratorOtpId",
                principalTable: "OtpGenerator",
                principalColumn: "OtpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_State_StateId",
                table: "PersonalDetails",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationQualifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_City_CityId",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_OtpGenerator_OtpGeneratorOtpId",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_State_StateId",
                table: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "OtpGenerator");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_CityId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_OtpGeneratorOtpId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_StateId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "OtpGeneratorOtpId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "PersonalDetails");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonalDetails",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PersonalDetails",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "EducationQualifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EducationQualifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationQualifications",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
