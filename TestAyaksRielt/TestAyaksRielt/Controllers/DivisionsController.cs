using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAyaksRielt.Models;

namespace TestAyaksRielt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : Controller
    {
        RealtorContext db;
        public DivisionsController(RealtorContext context)
        {
            this.db = context;
            if (!db.Divisions.Any())
            {
                db.Divisions.Add(new Division
                {
                    Name = "First",
                    DateTime = DateTime.Now
                    
            });
                db.Divisions.Add(new Division
                {
                    Name = "Second",
                    DateTime = DateTime.Now,
                    
                });

                db.SaveChanges();
            }
        }
        // GET: api/divisions
        [HttpGet]
        public IEnumerable<Division> Get()
        {
            return db.Divisions.ToList();
        }

        // GET api/divisions/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Division division = db.Divisions.FirstOrDefault(x => x.Id == id);
            if (division == null)
                return NotFound();
            return new ObjectResult(division);
        }

        // POST api/divisions
        [HttpPost]
        public IActionResult Post([FromBody]Division division)
        {
            if (division == null)
            {

                return BadRequest();
            }
            division.DateTime = DateTime.Now;
            db.Add(division);
            db.SaveChanges();
            return Ok(division);
        }

        // PUT api/divisions/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Division division)
        {

            if (division == null)
            {
                return BadRequest();
            }
            if (!db.Divisions.Any(x => x.Id == division.Id))
            {
                return NotFound();
            }

            division.DateTime = DateTime.Now;
            db.Update(division);
            db.SaveChanges();
            return Ok(division);
        }

        // DELETE api/divisions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Division division = db.Divisions.FirstOrDefault(x => x.Id == id);

            if (division == null)
            {
                return NotFound();
            }
            db.Divisions.Remove(division);
            db.SaveChanges();
            return Ok(division);

        }
    }
}
