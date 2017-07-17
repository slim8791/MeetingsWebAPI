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
    public class PersonMeetsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/PersonMeets
        public IQueryable<PersonMeet> GetPersonMeets()
        {
            return db.PersonMeets;
        }

        // GET: api/PersonMeets/5
        [ResponseType(typeof(PersonMeet))]
        public IHttpActionResult GetPersonMeet(int id)
        {
            PersonMeet personMeet = db.PersonMeets.Find(id);
            if (personMeet == null)
            {
                return NotFound();
            }

            return Ok(personMeet);
        }

        // PUT: api/PersonMeets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonMeet(int id, PersonMeet personMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personMeet.MeetId)
            {
                return BadRequest();
            }

            db.Entry(personMeet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonMeetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonMeets
        [ResponseType(typeof(PersonMeet))]
        public IHttpActionResult PostPersonMeet(PersonMeet personMeet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonMeets.Add(personMeet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonMeetExists(personMeet.MeetId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personMeet.MeetId }, personMeet);
        }

        // DELETE: api/PersonMeets/5
        [ResponseType(typeof(PersonMeet))]
        public IHttpActionResult DeletePersonMeet(int id)
        {
            PersonMeet personMeet = db.PersonMeets.Find(id);
            if (personMeet == null)
            {
                return NotFound();
            }

            db.PersonMeets.Remove(personMeet);
            db.SaveChanges();

            return Ok(personMeet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonMeetExists(int id)
        {
            return db.PersonMeets.Count(e => e.MeetId == id) > 0;
        }
    }
}