using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.BLL.Entities;

namespace Restaurant.ViewModels
{
    public class ReservationVm
    {
        public int ReservationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Duration { get; set; }
        public StatusReservation Status { get; set; }
        public int NumberOfPeoples { get; set; }
        public ICollection<SmallTableReservation> SmallTables { get; set; }
    }
}
