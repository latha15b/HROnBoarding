using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class DocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_UploadDocuments_UploadDocumentsUploadDocumentId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_UploadDocumentsUploadDocumentId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "HighestEducationCopy",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "Payslip1",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "Payslip2",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "Payslip3",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "PreviousEmployerOfferLetter",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "PreviousEmployerRelievingLetter",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "UploadAadhaarCardCopy",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "UploadPanCardCopy",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "UploadPassportCopy",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "UploadPhoto",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "UploadDocumentsUploadDocumentId",
                table: "PersonalDetails");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "UploadDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "UploadDocuments",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "UploadDocuments",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "UploadDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailEmployeeId",
                table: "UploadDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeName = table.Column<string>(nullable: false),
                    IsMandatory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_DocumentTypeId",
                table: "UploadDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_PersonalDetailEmployeeId",
                table: "UploadDocuments",
                column: "PersonalDetailEmployeeId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadDocuments_DocumentType_DocumentTypeId",
                table: "UploadDocuments",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadDocuments_PersonalDetails_PersonalDetailEmployeeId",
                table: "UploadDocuments",
                column: "PersonalDetailEmployeeId",
                principalTable: "PersonalDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadDocuments_DocumentType_DocumentTypeId",
                table: "UploadDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadDocuments_PersonalDetails_PersonalDetailEmployeeId",
                table: "UploadDocuments");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropIndex(
                name: "IX_UploadDocuments_DocumentTypeId",
                table: "UploadDocuments");

            migrationBuilder.DropIndex(
                name: "IX_UploadDocuments_PersonalDetailEmployeeId",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "UploadDocuments");

            migrationBuilder.DropColumn(
                name: "PersonalDetailEmployeeId",
                table: "UploadDocuments");

            migrationBuilder.AddColumn<byte>(
                name: "HighestEducationCopy",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Payslip1",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Payslip2",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Payslip3",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PreviousEmployerOfferLetter",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PreviousEmployerRelievingLetter",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "UploadAadhaarCardCopy",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "UploadPanCardCopy",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "UploadPassportCopy",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "UploadPhoto",
                table: "UploadDocuments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "UploadDocumentsUploadDocumentId",
                table: "PersonalDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_UploadDocumentsUploadDocumentId",
                table: "PersonalDetails",
                column: "UploadDocumentsUploadDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_UploadDocuments_UploadDocumentsUploadDocumentId",
                table: "PersonalDetails",
                column: "UploadDocumentsUploadDocumentId",
                principalTable: "UploadDocuments",
                principalColumn: "UploadDocumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
