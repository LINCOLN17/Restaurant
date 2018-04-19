using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Entities
{
    public class SmallTable
    {
        public int ID { get; set; }
        
        public int NumberOfChairs { get; set; }


        public virtual ICollection<SmallTableReservation> Reservations { get; set; }
    }
}
