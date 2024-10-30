using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MY2.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string Name { get; set; }
        public string  Phone { get; set; }
        public string  PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
    }
}