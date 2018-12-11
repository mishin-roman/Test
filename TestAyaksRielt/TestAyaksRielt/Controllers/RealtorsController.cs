using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAyaksRielt.Models;


namespace TestAyaksRielt.Controllers
{
    [Route("api/[controller]")]
    public class RealtorsController : Controller
    {
        
        RealtorContext db;
        public RealtorsController(RealtorContext context)
        {
            this.db = context;
    //        if (!db.Realtors.Any())
    //        {
    //            db.Realtors.Add(new Realtor { FirstName = "Roman", LastName = "Mishin", DateTime = DateTime.Now
    //});
    //            db.Realtors.Add(new Realtor { FirstName = "Jon", LastName = "Dow", DateTime = DateTime.Now
    //            });
                
    //            db.SaveChanges();
    //        }
        }
        // GET: api/realtors
        [HttpGet]
        public IEnumerable<Realtor> Get()
        {
            return db.Realtors.ToList();
        }

        // GET api/realtors/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Realtor realtor = db.Realtors.FirstOrDefault(x=> x.Id==id);
            if (realtor == null)
                return NotFound();
            return new ObjectResult(realtor);
        }

        // POST api/realtors
        [HttpPost]
        public IActionResult Post([FromBody]Realtor realtor)
        {
            if (realtor == null)
            {
               
                return BadRequest();
            }
            realtor.DateTime = DateTime.Now;
            db.Add(realtor);
            db.SaveChanges();
            return Ok(realtor);
        }

        // PUT api/realtors/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Realtor realtor)
        {
            
            if (realtor == null)
            {
                return BadRequest();
            }
            if (!db.Realtors.Any(x => x.Id == realtor.Id))
            {
                return NotFound();
            }

            realtor.DateTime = DateTime.Now;
            db.Update(realtor);
            db.SaveChanges();
            return Ok(realtor);
        }

        // DELETE api/realtors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Realtor realtor = db.Realtors.FirstOrDefault(x => x.Id == id);

            if (realtor == null)
            {
                return NotFound();
            }
            db.Realtors.Remove(realtor);
            db.SaveChanges();
            return Ok(realtor);

        }
    }
}
