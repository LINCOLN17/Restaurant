using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BLL.Entities
{
    public class Reservation
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public int NumberOfPeoples { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Duration { get; set; }

        public StatusReservation Status { get; set; }


        public DateTime DateCreated { get; set; }


        public virtual ICollection<SmallTableReservation> SmallTables { get; set; }
    }
}
