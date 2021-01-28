// using System;
// using System.Collections.Generic;
// using OnBoardingAPI.Models;

// namespace OnBoardingAPI.Data
// {
//     public class MockPersonalDetailsRepo : IPersonalDetailsRepo
//     {
//         public IEnumerable<PersonalDetails> GetAllPersonalDetails()
//         {
//             //Screen 1 Personal Details
//             var personalDetails = new List<PersonalDetails>
//             {
//                 new PersonalDetails{
//                     EmployeeId=1, Title="Mr", FirstName="Sajith", LastName="Sasidharan", 
//                     DateOfBirth= new DateTime(1982,06,25) , CellNumber="7406313222", 
//                     CurrentAddress="Flat No L-604, Ittina Soupernika Apartment, Bangalore 560035",
//                     CityId=1,Pincode=560035,StateId=1,Gender="Male",
//                     BloodGroup="A Positive", EmergencyContactNumber="9739385588",
//                     PersonalEmailId="SAJITHESTATE@GMAIL.COM",IsDeclarationStatus = true,
//                     TotalYearsOfExperience = 10,
//                     GroupMedicalCover = new GroupMedicalCover{
//                             GroupMedicalId = 1, DateOfJoining = new DateTime(2020,10,05),
//                             ParentOrInLawsName1 = "Raja", ParentOrInLawsName2 = "Rosa",
//                             ParentOrInLawsName1Relationship = "Father",
//                             ParentOrInLawsName2Relationship = "Mother",
//                             Married = true,
//                             SpouseName = "Balaleka",
//                             SpouseDateOfBirth = new DateTime(1900,05,09),
//                             SpouseGender = "Female",
//                             DoYouHaveKids = true,
//                             Kids = new List<Kid> {
//                                 new Kid { KidId = 1, KidName = "Danand", 
//                                 KidDateOfBirth = new DateTime(2020,02,01),
//                                 KidRelationship = "Son" },
//                                 new Kid { KidId = 2, KidName = "Manand", 
//                                 KidDateOfBirth = new DateTime(2020,03,01),
//                                 KidRelationship = "Daughter" }
//                             }    
//                         },
//                         OtherDetails = new OtherDetails{
//                     OtherDetailsId = 1, PANNumber = "JJJAHSJA121", NameAsOnPANCard = "Raja Ram",
//                     AadhaarNumber = "998198912999", NameAsOnAadhaar = "Raja Ram",
//                     PassportNumber = "MDKSKDSKD123", NameAsOnPassport = "Raja Ram",
//                     Nationality = "Indian", PlaceOfIssue = "Bengaluru",
//                     ValidFrom = new DateTime(2020,10,10),
//                     ValidTo = new DateTime(2030,11,10),
//                     AccountNumber = "IFSCDATA",
//                     IFSCCode = "DATAMAN009",
//                     NameAsInBankAccount = "Raja Ram",
//                     Branch = "MG Road",
//                     PermanentAddress = "Flat No 604 Ittina Soupernika Sarjapur Road Bengaluru 560035",
//                     State = "Karnataka",
//                     Pincode = 560035
//                 },
//                 OtherProfessionalDetails = new OtherProfessionalDetails
//                 {
//                     OtherProfessionalDetailsId = 1, PrimarySkills = "C#",
//                     PrimarySkillsLevel = 1, SecondarySkills = "Angular",
//                     SecondarySkillLevel = 1, VerbalCommunicationLevel = 1,
//                     WrittenCommunicationLevel = 1, PresentationSkillsLevel = 1, 
//                     CustomerInterfactingLevel = 1
//                 },
//                     EducationQualifications
//                     = new List<EducationQualification> {
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 1, Qualification = "MCA", 
//                                 YearOfPassing = 2005, NameOfUniversity = "Anna University",
//                                 Specialization = "Computer Science", IsHighestQualification = true
//                             },
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 2, Qualification = "B SC Computer Science", 
//                                 YearOfPassing = 2002, NameOfUniversity = "",
//                                 Specialization = "Computer Science", IsHighestQualification = false
//                             }
//                     },
//                     EducationCertifications = new List<EducationCertification>{
//                             new EducationCertification {
//                                 EducationCertificationId = 0, NameOfCertifcation = "MCTS",
//                                 Year = 2012, CertificateNumber="23453535SDDASAS", 
//                                 ExpiryDateOfCertificate = new DateTime(2040, 11, 30),
//                             }
//                     },
//                     PreviousEmployers = new List<PreviousEmployer>{
//                             new PreviousEmployer{
//                                 PreviousEmployerId = 1, PreviousEmployerName = "TR", 
//                                 DateOfJoining = new DateTime(2019,10,12),
//                                 LastWorkingDay = new DateTime(2020,12,31),
//                                 ReasonForLeaving = "New Opportunities",
//                                 AreTheExitFormalitiesCompleted = true,
//                                 UniversalAccountNo = "12121SDSDSD", ProvidentFundNo = "SDSDSD232323",
//                                 TypeOfPFAccount = "Salary", IsLatestLastEmployer = true 
//                             }
//                     }
//                 },
//                 new PersonalDetails{
//                     EmployeeId=2, Title="Mr", FirstName="Harshith", LastName="Sajith", 
//                     DateOfBirth= new DateTime(2010,08,08) , CellNumber="7406313222", 
//                     CurrentAddress="Flat No L-604, Ittina Soupernika Apartment, Bangalore 560035",
//                     CityId=1,Pincode=560035,StateId=1,Gender="Male",
//                     BloodGroup="O Positive", EmergencyContactNumber="9739385588",
//                     PersonalEmailId="HARSHITHSAJITH@GMAIL.COM",TotalYearsOfExperience = 10
//                 },
//                 new PersonalDetails{
//                     EmployeeId=3, Title="Mr", FirstName="Sujesh", LastName="Sasidharan", 
//                     DateOfBirth= new DateTime(1987,10,17) , CellNumber="9035012345", 
//                     CurrentAddress="Flat No L-603, Ittina Soupernika Apartment, Bangalore 560035",
//                     CityId=1,Pincode=560035,StateId=1,Gender="Male",
//                     BloodGroup="A Positive", EmergencyContactNumber="7406313222",
//                     PersonalEmailId="SUJESHSASI@GMAIL.COM",TotalYearsOfExperience = 10
//                 }
//             };

//             return personalDetails;
//         }
    
//         public PersonalDetails GetPersonalDetailsById(int employeeId)
//         {
//             return new PersonalDetails{
//                 EmployeeId=0, Title="Mrs", FirstName="Shylaja", LastName="Sajiths", 
//                 DateOfBirth= new DateTime(1984,11,22) , CellNumber="9739385588", 
//                 CurrentAddress="Flat No L-604, Ittina Soupernika Apartment, Bangalore 560035",
//                 CityId=1,Pincode=560035,StateId=1,Gender="Female",
//                 BloodGroup="O Positive", EmergencyContactNumber="7406313222",
//                 PersonalEmailId="SHYLAJASAJITH@GMAIL.COM"
//             };
//         }

//         //Screen 2 Education Qualifications
//         public IEnumerable<EducationQualification> GetAllEducationQualifications()
//         {
//            return new List<EducationQualification> {
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 1, Qualification = "MCA", 
//                                 YearOfPassing = 2005, NameOfUniversity = "Anna University",
//                                 Specialization = "Computer Science", IsHighestQualification = true
//                             },
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 2, Qualification = "B SC Computer Science", 
//                                 YearOfPassing = 2002, NameOfUniversity = "",
//                                 Specialization = "Computer Science", IsHighestQualification = false
//                             }
//                         };
//         }

//         public IEnumerable<EducationQualification> GetEducationQualificationsById(int employeeId)
//         {
//             return new List<EducationQualification> {
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 0, Qualification = "MCA", 
//                                 YearOfPassing = 2005, NameOfUniversity = "Anna University",
//                                 Specialization = "Computer Science", IsHighestQualification = true
//                             },
//                             new EducationQualification 
//                             { 
//                                 EducationQualificationId = 2, Qualification = "B SC Computer Science", 
//                                 YearOfPassing = 2002, NameOfUniversity = "",
//                                 Specialization = "Computer Science", IsHighestQualification = false
//                             }
//                         };
//         }

//         //Screen 2 Education Certifications
//         public IEnumerable<EducationCertification> GetAllEducationCertifications()
//         {
//             return new List<EducationCertification>{
//                 new EducationCertification {
//                     EducationCertificationId = 1, NameOfCertifcation = "MCTS",
//                     Year = 2012, CertificateNumber="23453535SDDASAS", 
//                     ExpiryDateOfCertificate = new DateTime(2040, 11, 30),
//                 }
//             };
//         }

//         public IEnumerable<EducationCertification> GetEducationCertificationsById(int employeeId)
//         {
//              return new List<EducationCertification>{
//                 new EducationCertification {
//                     EducationCertificationId = 0, NameOfCertifcation = "MCTS",
//                     Year = 2012, CertificateNumber="23453535SDDASAS", 
//                     ExpiryDateOfCertificate = new DateTime(2040, 11, 30),
//                 }
//             };
//         }

//         //Screen 2 Education Certifications
//         public IEnumerable<PreviousEmployer> GetAllPreviousEmployers()
//         {
//             return new List<PreviousEmployer>{
//                 new PreviousEmployer{
//                     PreviousEmployerId = 1, PreviousEmployerName = "TR", 
//                     DateOfJoining = new DateTime(2019,10,12),
//                     LastWorkingDay = new DateTime(2020,12,31),
//                     ReasonForLeaving = "New Opportunities",
//                     AreTheExitFormalitiesCompleted = true,
//                     UniversalAccountNo = "12121SDSDSD", ProvidentFundNo = "SDSDSD232323",
//                     TypeOfPFAccount = "Salary", IsLatestLastEmployer = true 
//                 }
//             };
//         }

//         public IEnumerable<PreviousEmployer> GetPreviousEmployersById(int employeeId)
//         {
//             return new List<PreviousEmployer>{
//                 new PreviousEmployer{
//                     PreviousEmployerId = 0, PreviousEmployerName = "TR", 
//                     DateOfJoining = new DateTime(2019,10,12),
//                     LastWorkingDay = new DateTime(2020,12,31),
//                     ReasonForLeaving = "New Opportunities",
//                     AreTheExitFormalitiesCompleted = true,
//                     UniversalAccountNo = "12121SDSDSD", ProvidentFundNo = "SDSDSD232323",
//                     TypeOfPFAccount = "Salary", IsLatestLastEmployer = true 
//                 }
//             };
//         }

//         public IEnumerable<GroupMedicalCover> GetAllGroupMedicalCovers()
//         {
//             return new List<GroupMedicalCover>{
//                 new GroupMedicalCover{
//                     GroupMedicalId = 1, DateOfJoining = new DateTime(2020,10,05),
//                     ParentOrInLawsName1 = "Raja", ParentOrInLawsName2 = "Rosa",
//                     ParentOrInLawsName1Relationship = "Father",
//                     ParentOrInLawsName2Relationship = "Mother",
//                     Married = true,
//                     SpouseName = "Balaleka",
//                     SpouseDateOfBirth = new DateTime(1900,05,09),
//                     SpouseGender = "Female",
//                     DoYouHaveKids = true,
//                     Kids = new List<Kid> {
//                         new Kid { KidId = 1, KidName = "Danand", 
//                         KidDateOfBirth = new DateTime(2020,02,01),
//                         KidRelationship = "Son" },
//                         new Kid { KidId = 2, KidName = "Manand", 
//                         KidDateOfBirth = new DateTime(2020,03,01),
//                         KidRelationship = "Daughter" }

//                     }    
//                 }
//             };
//         }

//         public GroupMedicalCover GetGroupMedicalCoverById(int employeeId)
//         {
//             return new GroupMedicalCover{
//                     GroupMedicalId = 1, DateOfJoining = new DateTime(2020,10,05),
//                     ParentOrInLawsName1 = "Raja", ParentOrInLawsName2 = "Rosa",
//                     ParentOrInLawsName1Relationship = "Father",
//                     ParentOrInLawsName2Relationship = "Mother",
//                     Married = true,
//                     SpouseName = "Balaleka",
//                     SpouseDateOfBirth = new DateTime(1900,05,09),
//                     SpouseGender = "Female",
//                     DoYouHaveKids = true,
//                     Kids = new List<Kid> {
//                         new Kid { KidId = 1, KidName = "Danand", 
//                         KidDateOfBirth = new DateTime(2020,02,01),
//                         KidRelationship = "Son" },
//                         new Kid { KidId = 2, KidName = "Manand", 
//                         KidDateOfBirth = new DateTime(2020,03,01),
//                         KidRelationship = "Daughter" }

//                     }    
//                 };
//            }

//         public IEnumerable<OtherDetails> GetAllOtherDetails()
//         {
//             return new List<OtherDetails>{
//                 new OtherDetails{
//                     OtherDetailsId = 1, PANNumber = "JJJAHSJA121", NameAsOnPANCard = "Raja Ram",
//                     AadhaarNumber = "998198912999", NameAsOnAadhaar = "Raja Ram",
//                     PassportNumber = "MDKSKDSKD123", NameAsOnPassport = "Raja Ram",
//                     Nationality = "Indian", PlaceOfIssue = "Bengaluru",
//                     ValidFrom = new DateTime(2020,10,10),
//                     ValidTo = new DateTime(2030,11,10),
//                     AccountNumber = "IFSCDATA",
//                     IFSCCode = "DATAMAN009",
//                     NameAsInBankAccount = "Raja Ram",
//                     Branch = "MG Road",
//                     PermanentAddress = "Flat No 604 Ittina Soupernika Sarjapur Road Bengaluru 560035",
//                     State = "Karnataka",
//                     Pincode = 560035
                    
//                 }
//             };
//         }

//         public OtherDetails GetOtherDetailsById(int employeeId)
//         {
//             return new OtherDetails{
//                     OtherDetailsId = 1, PANNumber = "JJJAHSJA121", NameAsOnPANCard = "Raja Ram",
//                     AadhaarNumber = "998198912999", NameAsOnAadhaar = "Raja Ram",
//                     PassportNumber = "MDKSKDSKD123", NameAsOnPassport = "Raja Ram",
//                     Nationality = "Indian", PlaceOfIssue = "Bengaluru",
//                     ValidFrom = new DateTime(2020,10,10),
//                     ValidTo = new DateTime(2030,11,10),
//                     AccountNumber = "IFSCDATA",
//                     IFSCCode = "DATAMAN009",
//                     NameAsInBankAccount = "Raja Ram",
//                     Branch = "MG Road",
//                     PermanentAddress = "Flat No 604 Ittina Soupernika Sarjapur Road Bengaluru 560035",
//                     State = "Karnataka",
//                     Pincode = 560035
//                 };
//         }

//         public IEnumerable<OtherProfessionalDetails> GetAllOtherProfessionalDetails()
//         {
//             return new List<OtherProfessionalDetails>{
//                 new OtherProfessionalDetails
//                 {
//                     OtherProfessionalDetailsId = 1, PrimarySkills = "C#",
//                     PrimarySkillsLevel = 1, SecondarySkills = "Angular",
//                     SecondarySkillLevel = 1, VerbalCommunicationLevel = 1,
//                     WrittenCommunicationLevel = 1, PresentationSkillsLevel = 1, 
//                     CustomerInterfactingLevel = 1
//                 }
//             };
//         }

//         public OtherProfessionalDetails GetOtherProfessionalDetailsById(int employeeId)
//         {
//             return new OtherProfessionalDetails
//             {
//                     OtherProfessionalDetailsId = 0, PrimarySkills = "C#",
//                     PrimarySkillsLevel = 1, SecondarySkills = "Angular",
//                     SecondarySkillLevel = 1, VerbalCommunicationLevel = 1,
//                     WrittenCommunicationLevel = 1, PresentationSkillsLevel = 1, 
//                     CustomerInterfactingLevel = 1
//             };
//         }

//         public bool SaveChanges()
//         {
//             throw new NotImplementedException();
//         }

//         public void CreatePersonalDetails(PersonalDetails personalDetails)
//         {
//             throw new NotImplementedException();
//         }

//         bool IPersonalDetailsRepo.SaveChanges()
//         {
//             throw new NotImplementedException();
//         }

//         IEnumerable<PersonalDetails> IPersonalDetailsRepo.GetAllPersonalDetails()
//         {
//             throw new NotImplementedException();
//         }

//         PersonalDetails IPersonalDetailsRepo.GetPersonalDetailsById(int employeeId)
//         {
//             throw new NotImplementedException();
//         }

//         void IPersonalDetailsRepo.CreatePersonalDetails(PersonalDetails personalDetails)
//         {
//             throw new NotImplementedException();
//         }

//         void IPersonalDetailsRepo.UpdatePersonalDetails(PersonalDetails personalDetails)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeletePersonalDetails(PersonalDetails personalDetails)
//         {
//             throw new NotImplementedException();
//         }

//         public IEnumerable<State> GetAllStateDetails()
//         {
//             throw new NotImplementedException();
//         }

//         public IEnumerable<City> GetAllCityDetails(int stateId)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }