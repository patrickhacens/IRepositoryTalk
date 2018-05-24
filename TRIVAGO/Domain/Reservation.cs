using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRIVAGO.Domain
{
    public class Reservation
    {
        public int Id { get; set; }

        public Apartment Apartment { get; set; }

        public int ApartmentId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
