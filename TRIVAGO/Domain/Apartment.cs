using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TRIVAGO.Domain
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ApartmentType Type { get; set; }

        public List<Reservation> Reservations { get; set; }
    }

    public enum ApartmentType
    {
        Single,
        Double,
        Couple,
        Luxury
    }

    public static class ApartmentExtensions
    {
        public static IQueryable<Apartment> FreeBetween(this IQueryable<Apartment> collection, DateTime from, DateTime to) =>
            collection.Where(a => !a.Reservations
                                    .Any(r => r.From <= from && from <= r.To ||
                                         r.From <= to && to <= r.To ||
                                         from <= r.From && r.From <= to ||
                                         from <= r.To && r.To <= to));        
    }
}
