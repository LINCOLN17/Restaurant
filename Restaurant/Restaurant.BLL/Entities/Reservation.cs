using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BLL.Entities
{
    public class Reservation
    {
        
        public int ReservationId { get; set; }

        public string UserId { get; set; }

        public int NumberOfPeoples { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Duration { get; set; }

        public StatusReservation Status { get; set; }


        public DateTime DateCreated { get; set; }


        public virtual ICollection<SmallTableReservation> SmallTables { get; set; }
    }

    public enum StatusReservation
    {
        Cancelled,
        Reserved
    }
        
}
