using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enum;

namespace Shared.DTO
    {
   public class HouseDTO
        {

        public int HouseId { get; set; }
       
        public string ApartmentNumber { get; set; }
      
        public string StreetName { get; set; }
        
        public string State { get; set; }
       
        public string HeadName { get; set; }
       
        public OwnerShipStatus OwnershipStatus { get; set; }

        
        public int NumberOfRooms { get; set; }

        
        }
    }
