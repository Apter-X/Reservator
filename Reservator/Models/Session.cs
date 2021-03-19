using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Models
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        [Required]
        public string DateID { get; set; }

        //Navigation property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
