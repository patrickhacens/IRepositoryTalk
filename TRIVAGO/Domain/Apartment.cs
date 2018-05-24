using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRIVAGO.Domain
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ApartmentType Type { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }

    public enum ApartmentType
    {
        Single,
        Double,
        Couple,
        Luxury
    }
}
