using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MeetingsWebAPI.Models;

namespace MeetingsWebAPI.Controllers
{
    public class CoffeesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Coffees
        public IQueryable<Coffee> GetCoffees()
        {
            //return db.Coffees;
            return db.Coffees.Include(a => a.Meets);
        }

        // GET: api/Coffees/5
        [ResponseType(typeof(Coffee))]
        public IHttpActionResult GetCoffee(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            return Ok(coffee);
        }

        // PUT: api/Coffees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoffee(int id, Coffee coffee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coffee.CoffeeId)
            {
                return BadRequest();
            }

            db.Entry(coffee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeExists(id))
                {
                    return NotFound();
                }//comment

                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Coffees
        [ResponseType(typeof(Coffee))]
        public IHttpActionResult PostCoffee(Coffee coffee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coffees.Add(coffee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coffee.CoffeeId }, coffee);
        }

        // DELETE: api/Coffees/5
        [ResponseType(typeof(Coffee))]
        public IHttpActionResult DeleteCoffee(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            db.Coffees.Remove(coffee);
            db.SaveChanges();

            return Ok(coffee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoffeeExists(int id)
        {
            return db.Coffees.Count(e => e.CoffeeId == id) > 0;
        }
    }
}