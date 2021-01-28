using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoardingAPI.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupMedicalCovers",
                columns: table => new
                {
                    GroupMedicalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfJoining = table.Column<DateTime>(nullable: false),
                    ParentOrInLawsName1 = table.Column<string>(nullable: true),
                    ParentOrInLawsName2 = table.Column<string>(nullable: true),
                    ParentOrInLawsName1Relationship = table.Column<string>(nullable: true),
                    ParentOrInLawsName2Relationship = table.Column<string>(nullable: true),
                    Married = table.Column<bool>(nullable: false),
                    DateOfMarriage = table.Column<DateTime>(nullable: false),
                    SpouseName = table.Column<string>(nullable: true),
                    SpouseDateOfBirth = table.Column<DateTime>(nullable: false),
                    SpouseGender = table.Column<string>(nullable: true),
                    DoYouHaveKids = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMedicalCovers", x => x.GroupMedicalId);
                });

            migrationBuilder.CreateTable(
                name: "OtherDetails",
                columns: table => new
                {
                    OtherDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PANNumber = table.Column<string>(nullable: true),
                    NameAsOnPANCard = table.Column<string>(nullable: true),
                    AadhaarNumber = table.Column<string>(maxLength: 50, nullable: false),
                    NameAsOnAadhaar = table.Column<string>(maxLength: 250, nullable: false),
                    PassportNumber = table.Column<string>(nullable: true),
                    NameAsOnPassport = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    PlaceOfIssue = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    IFSCCode = table.Column<string>(nullable: true),
                    NameAsInBankAccount = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(maxLength: 1000, nullable: false),
                    State = table.Column<string>(maxLength: 250, nullable: false),
                    Pincode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDetails", x => x.OtherDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "OtherProfessionalDetails",
                columns: table => new
                {
                    OtherProfessionalDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimarySkills = table.Column<string>(maxLength: 250, nullable: false),
                    PrimarySkillsLevel = table.Column<int>(nullable: false),
                    SecondarySkills = table.Column<string>(maxLength: 250, nullable: false),
                    SecondarySkillLevel = table.Column<int>(nullable: false),
                    VerbalCommunicationLevel = table.Column<int>(nullable: false),
                    WrittenCommunicationLevel = table.Column<int>(nullable: false),
                    PresentationSkillsLevel = table.Column<int>(nullable: false),
                    CustomerInterfactingLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherProfessionalDetails", x => x.OtherProfessionalDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "UploadDocuments",
                columns: table => new
                {
                    UploadDocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadPhoto = table.Column<byte>(nullable: false),
                    UploadPanCardCopy = table.Column<byte>(nullable: false),
                    UploadAadhaarCardCopy = table.Column<byte>(nullable: false),
                    UploadPassportCopy = table.Column<byte>(nullable: false),
                    HighestEducationCopy = table.Column<byte>(nullable: false),
                    PreviousEmployerOfferLetter = table.Column<byte>(nullable: false),
                    PreviousEmployerRelievingLetter = table.Column<byte>(nullable: false),
                    Payslip1 = table.Column<byte>(nullable: false),
                    Payslip2 = table.Column<byte>(nullable: false),
                    Payslip3 = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocuments", x => x.UploadDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Kids",
                columns: table => new
                {
                    KidId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KidName = table.Column<string>(maxLength: 250, nullable: false),
                    KidRelationship = table.Column<string>(nullable: false),
                    KidDateOfBirth = table.Column<DateTime>(nullable: false),
                    GroupMedicalCoverGroupMedicalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kids", x => x.KidId);
                    table.ForeignKey(
                        name: "FK_Kids_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                        column: x => x.GroupMedicalCoverGroupMedicalId,
                        principalTable: "GroupMedicalCovers",
                        principalColumn: "GroupMedicalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CellNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CurrentAddress = table.Column<string>(maxLength: 1000, nullable: false),
                    City = table.Column<string>(maxLength: 250, nullable: false),
                    Pincode = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 250, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    BloodGroup = table.Column<string>(maxLength: 10, nullable: false),
                    EmergencyContactNumber = table.Column<string>(nullable: false),
                    PersonalEmailId = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeclarationStatus = table.Column<bool>(nullable: false),
                    TotalYearsOfExperience = table.Column<int>(nullable: false),
                    GroupMedicalCoverGroupMedicalId = table.Column<int>(nullable: true),
                    OtherDetailsId = table.Column<int>(nullable: true),
                    OtherProfessionalDetailsId = table.Column<int>(nullable: true),
                    UploadDocumentsUploadDocumentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_GroupMedicalCovers_GroupMedicalCoverGroupMedicalId",
                        column: x => x.GroupMedicalCoverGroupMedicalId,
                        principalTable: "GroupMedicalCovers",
                        principalColumn: "GroupMedicalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_OtherDetails_OtherDetailsId",
                        column: x => x.OtherDetailsId,
                        principalTable: "OtherDetails",
                        principalColumn: "OtherDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_OtherProfessionalDetails_OtherProfessionalDetailsId",
                        column: x => x.OtherProfessionalDetailsId,
                        principalTable: "OtherProfessionalDetails",
                        principalColumn: "OtherProfessionalDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_UploadDocuments_UploadDocumentsUploadDocumentId",
                        column: x => x.UploadDocumentsUploadDocumentId,
                        principalTable: "UploadDocuments",
                        principalColumn: "UploadDocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationCertifications",
                columns: table => new
                {
                    EducationCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCertifcation = table.Column<string>(maxLength: 250, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CertificateNumber = table.Column<string>(maxLength: 250, nullable: false),
                    ExpiryDateOfCertificate = table.Column<DateTime>(nullable: false),
                    PersonalDetailEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCertifications", x => x.EducationCertificationId);
                    table.ForeignKey(
                        name: "FK_EducationCertifications_PersonalDetails_PersonalDetailEmployeeId",
                        column: x => x.PersonalDetailEmployeeId,
                        principalTable: "PersonalDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationQualifications",
                columns: table => new
                {
                    EducationQualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qualification = table.Column<string>(maxLength: 250, nullable: false),
                    YearOfPassing = table.Column<int>(nullable: false),
                    NameOfUniversity = table.Column<string>(maxLength: 250, nullable: false),
                    Specialization = table.Column<string>(maxLength: 100, nullable: false),
                    IsHighestQualification = table.Column<bool>(nullable: false),
                    PersonalDetailEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationQualifications", x => x.EducationQualificationId);
                    table.ForeignKey(
                        name: "FK_EducationQualifications_PersonalDetails_PersonalDetailEmployeeId",
                        column: x => x.PersonalDetailEmployeeId,
                        principalTable: "PersonalDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreviousEmployers",
                columns: table => new
                {
                    PreviousEmployerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousEmployerName = table.Column<string>(maxLength: 250, nullable: false),
                    DateOfJoining = table.Column<DateTime>(nullable: false),
                    LastWorkingDay = table.Column<DateTime>(nullable: false),
                    ReasonForLeaving = table.Column<string>(maxLength: 250, nullable: false),
                    AreTheExitFormalitiesCompleted = table.Column<bool>(nullable: false),
                    UniversalAccountNo = table.Column<string>(nullable: true),
                    ProvidentFundNo = table.Column<string>(nullable: true),
                    TypeOfPFAccount = table.Column<string>(nullable: true),
                    IsLatestLastEmployer = table.Column<bool>(nullable: false),
                    PersonalDetailEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEmployers", x => x.PreviousEmployerId);
                    table.ForeignKey(
                        name: "FK_PreviousEmployers_PersonalDetails_PersonalDetailEmployeeId",
                        column: x => x.PersonalDetailEmployeeId,
                        principalTable: "PersonalDetails",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationCertifications_PersonalDetailEmployeeId",
                table: "EducationCertifications",
                column: "PersonalDetailEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationQualifications_PersonalDetailEmployeeId",
                table: "EducationQualifications",
                column: "PersonalDetailEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_GroupMedicalCoverGroupMedicalId",
                table: "Kids",
                column: "GroupMedicalCoverGroupMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_GroupMedicalCoverGroupMedicalId",
                table: "PersonalDetails",
                column: "GroupMedicalCoverGroupMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_OtherDetailsId",
                table: "PersonalDetails",
                column: "OtherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_OtherProfessionalDetailsId",
                table: "PersonalDetails",
                column: "OtherProfessionalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_UploadDocumentsUploadDocumentId",
                table: "PersonalDetails",
                column: "UploadDocumentsUploadDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployers_PersonalDetailEmployeeId",
                table: "PreviousEmployers",
                column: "PersonalDetailEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationCertifications");

            migrationBuilder.DropTable(
                name: "EducationQualifications");

            migrationBuilder.DropTable(
                name: "Kids");

            migrationBuilder.DropTable(
                name: "PreviousEmployers");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "GroupMedicalCovers");

            migrationBuilder.DropTable(
                name: "OtherDetails");

            migrationBuilder.DropTable(
                name: "OtherProfessionalDetails");

            migrationBuilder.DropTable(
                name: "UploadDocuments");
        }
    }
}
