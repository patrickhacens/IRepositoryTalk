using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRIVAGO.Domain
{
    public class Db : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public Db()
        {

        }


        public Db(DbContextOptions options) : base(options)
        {

        }
    }
}
