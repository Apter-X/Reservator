﻿using System;
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
        [Key]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Date required!")]
        public DateTime Date { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}