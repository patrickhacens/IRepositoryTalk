using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIVAGO.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TRIVAGO.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        private Db Db { get; }

        public ApartmentController(Db db)
        {
            this.Db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Apartment>> Get() => await Db.Apartments.ToListAsync();

        [HttpGet]
        [Route("free")]
        public async Task<IEnumerable<Apartment>> GetFree(DateTime from, DateTime to) =>
            await Db.Apartments
                    .Include(a => a.Reservations)
                    .Where(a => !a.Reservations.Any(r =>
                           r.From <= from && from <= r.To ||
                           r.From <= to && to <= r.To ||
                           from <= r.From && r.From <= to ||
                           from <= r.To && r.To <= to
                        )).ToListAsync();

        [HttpGet]
        [Route("free2")]
        public async Task<IEnumerable<Apartment>> GetFree2(DateTime from, DateTime to) =>
            await Db.Apartments
                    .Include(a => a.Reservations)
                    .FreeBetween(from, to)
                    .ToListAsync();

    }
}
