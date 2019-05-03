using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
    {
    public class Member
        {

        public int MemberId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(12)]
        [Index(IsUnique = true)]
        public string AadharNumber { get;  set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsApprover { get; set; }

        }
    }
