using Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
    {
    public class Person
        {
        public int PersonId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int CensusHouseNumber { get; set; }

        [Required]
        public RelationShipStatus RelToHead { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public int AgeAtMarriage { get; set; }

        [Required]
        public OccupationStatus Occupation { get; set; }

        [Required]
        public OccupationType NatureOfOccupation { get; set; }

        [ForeignKey("CensusHouseNumber")]
        public virtual House house { get; set; }
        }
    }
