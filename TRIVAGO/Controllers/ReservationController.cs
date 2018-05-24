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
        private Db db { get; }
        public ReservationController(Db db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Reservate([FromBody]Reservation reservation)
        {
            DateTime from = reservation.From, to = reservation.To;

            if (await db.Reservations.AnyAsync(r =>
                             r.From <= from && from <= r.To ||
                             r.From <= to && to <= r.To ||
                             from <= r.From && r.From <= to ||
                             from <= r.To && r.To <= to))
                return Forbid();

            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
