using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionManagementSystem.Model
{
    public class MPSeat
    {
        public int SeatId { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public int NoOfSeatsPerState { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
