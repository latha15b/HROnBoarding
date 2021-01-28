using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class GroupMedicalCoversCreateDto
    {
        [Required]
        public DateTime DateOfJoining { get; set; }

        public string ParentOrInLawsName1 { get; set; }

        public string ParentOrInLawsName2 { get; set; }

        public string ParentOrInLawsName1Relationship { get; set; }

        public string ParentOrInLawsName2Relationship { get; set; }

        [Required]
        public bool Married { get; set; }

        public DateTime DateOfMarriage { get; set; }

        public string SpouseName { get; set; }

        public DateTime SpouseDateOfBirth { get; set; }

        public string SpouseGender { get; set; }

        public bool DoYouHaveKids { get; set; }
        
        public List<Kid> Kids { get; set; }

        public int personalDetailEmployeeId { get; set; }
        public IEnumerable<PersonalDetails> PersonalDetails { get; set; }

        
    }
}