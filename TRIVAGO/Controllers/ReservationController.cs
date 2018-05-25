using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIVAGO.Domain;

namespace TRIVAGO.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private Db Db { get; }

        public ReservationController(Db db)
        {
            this.Db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Reservate([FromBody]Reservation reservation)
        {
            DateTime from = reservation.From, to = reservation.To;

            if (await Db.Reservations.AnyAsync(r =>
                             r.From <= from && from <= r.To ||
                             r.From <= to && to <= r.To ||
                             from <= r.From && r.From <= to ||
                             from <= r.To && r.To <= to))
                return NotFound();

            Db.Reservations.Add(reservation);
            await Db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Reservate2([FromBody]Reservation reservation)
        {
            DateTime from = reservation.From, to = reservation.To;
            if (!(await Db.Apartments.FreeBetween(reservation.From, reservation.To).Where(d => d.Id == reservation.ApartmentId).AnyAsync()))
                return NotFound();

            Db.Reservations.Add(reservation);
            await Db.SaveChangesAsync();
            return Ok();
        }
    }
}
