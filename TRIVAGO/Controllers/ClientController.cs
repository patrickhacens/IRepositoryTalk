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
    public class ClientController : Controller
    {
        private Db Db { get; }

        public ClientController(Db db)
        {
            this.Db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Client>> Get() => await Db.Clients.ToListAsync();

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Client> Get(int id) => await Db.Clients.Include(c => c.Reservations).ThenInclude(r => r.Apartment).FirstOrDefaultAsync(d => d.Id == id);

        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody]Client client)
        {
            Db.Clients.Add(client);
            await Db.SaveChangesAsync();
        }
    }
}
