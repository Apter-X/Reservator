using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Models
{
    public class UserInfo : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

        //Navigation property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
