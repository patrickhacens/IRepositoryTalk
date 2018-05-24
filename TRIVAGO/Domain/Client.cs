using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRIVAGO.Domain
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
