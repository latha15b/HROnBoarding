using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class AddUpdateDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalDetailEmployeeId",
                table: "OtherProfessionalDetails");

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
                name: "SecondarySkillLevel",
                table: "OtherProfessionalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PrimarySkillsLevel",
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

            migrationBuilder.CreateTable(
                name: "RatingLevel",
                columns: table => new
                {
                    RatingLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingLevelDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingLevel", x => x.RatingLevelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingLevel");

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
                name: "SecondarySkillLevel",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PrimarySkillsLevel",
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

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "OtherProfessionalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
