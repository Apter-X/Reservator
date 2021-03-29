using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Models
{
    public class Reservation
    {
        [DisplayName("ID")]
        [Key]
        public int ReservationId { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        [DefaultValue("InProgress")]
        public string Statement { get; set; }

        [DisplayName("Timestamp")]
        [Timestamp]
        public byte[] RowID { get; set; }

        [DisplayName("Parent ID")]
        [ForeignKey("Session")]
        public int SessID { get; set; }

        //Navigation property
        public Session Session { get; set; }

        [DisplayName("User ID")]
        [ForeignKey("UserInfo")]
        public string UsrID { get; set; }

        //Navigation property
        public UserInfo UserInfo { get; set; }
    }
}
