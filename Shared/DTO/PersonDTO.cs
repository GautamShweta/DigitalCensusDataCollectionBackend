using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enum;

namespace Shared.DTO
    {
   public class PersonDTO
        {
        public int PersonId { get; set; }

       
        public string FullName { get; set; }

       
        public int CensusHouseNumber { get; set; }

       
        public RelationShipStatus RelToHead { get; set; }

       
        public Gender Gender { get; set; }

       
        public DateTime BirthDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public int AgeAtMarriage { get; set; }

       
        public OccupationStatus Occupation { get; set; }

        
        public OccupationType NatureOfOccupation { get; set; }
        }
    }
