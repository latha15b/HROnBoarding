using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class OtherProfessionalDetailsChangeinDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WrittenCommunicationLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VerbalCommunicationLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationSkillsLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerInterfactingLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "OtherProfessionalDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalDetailEmployeeId",
                table: "OtherProfessionalDetails");

            migrationBuilder.AlterColumn<int>(
                name: "WrittenCommunicationLevel",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "VerbalCommunicationLevel",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PresentationSkillsLevel",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInterfactingLevel",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
