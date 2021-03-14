using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Date required!")]
        public DateTime Date { get; set; }

        [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class TimestampAttribute : Attribute
        {
            public DateTime Timestamp { get; set; }
        }
        
    }
}
