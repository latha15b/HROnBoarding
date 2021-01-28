using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class AddBankName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationCertifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationCertifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Kids_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                table: "Kids");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousEmployers_PersonalDetails_PersonalDetailEmployeeId",
                table: "PreviousEmployers");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "PreviousEmployers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OtpCode",
                table: "OtpGenerator",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "OtherDetails",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupMedicalCoverGroupMedicalId",
                table: "Kids",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "EducationCertifications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationCertifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationCertifications",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                table: "Kids",
                column: "GroupMedicalCoverGroupMedicalId",
                principalTable: "GroupMedicalCovers",
                principalColumn: "GroupMedicalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousEmployers_PersonalDetails_PersonalDetailEmployeeId",
                table: "PreviousEmployers",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationCertifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationCertifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Kids_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                table: "Kids");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousEmployers_PersonalDetails_PersonalDetailEmployeeId",
                table: "PreviousEmployers");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "OtherDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "PreviousEmployers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OtpCode",
                table: "OtpGenerator",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupMedicalCoverGroupMedicalId",
                table: "Kids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "EducationCertifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EducationCertifications_PersonalDetails_PersonalDetailEmployeeId",
                table: "EducationCertifications",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                table: "Kids",
                column: "GroupMedicalCoverGroupMedicalId",
                principalTable: "GroupMedicalCovers",
                principalColumn: "GroupMedicalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousEmployers_PersonalDetails_PersonalDetailEmployeeId",
                table: "PreviousEmployers",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
