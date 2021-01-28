using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class AddUpdateDatatypeOPDandKid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KidRelationship",
                table: "Kids");

            migrationBuilder.AlterColumn<int>(
                name: "WrittenCommunicationLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VerbalCommunicationLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SecondarySkillLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PrimarySkillsLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PresentationSkillsLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInterfactingLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "KidGender",
                table: "Kids",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KidGender",
                table: "Kids");

            migrationBuilder.AlterColumn<string>(
                name: "WrittenCommunicationLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "VerbalCommunicationLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SecondarySkillLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PrimarySkillsLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PresentationSkillsLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerInterfactingLevel",
                table: "OtherProfessionalDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "KidRelationship",
                table: "Kids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
