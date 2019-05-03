using Shared.Enum;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
    {
    public class House
        {

        public int HouseId { get; set; }
        [Required]
        public string ApartmentNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string HeadName { get; set; }
        [Required]
        public OwnerShipStatus OwnershipStatus { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }

        public ICollection<Person> Persons { get; set; }
        }
    }
