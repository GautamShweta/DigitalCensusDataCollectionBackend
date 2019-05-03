using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
    {
    public class MemberDTO
        {
        
        public int MemberId { get; set; }

       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        public string Email { get; set; }
       
        public string Password { get; set; }

        public string AadharNumber { get; set; }
        
        public string Image { get; set; }
       
        public bool IsApprover { get; set; }

        }
    }
