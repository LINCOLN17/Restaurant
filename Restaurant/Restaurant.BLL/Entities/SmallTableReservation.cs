using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BLL.Entities
{
    public class SmallTableReservation
    {
        public int SmallTableId { get; set; }
        public SmallTable SmallTable { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
