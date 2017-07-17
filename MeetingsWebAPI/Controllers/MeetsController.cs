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
    public class MeetsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Meets
        public IQueryable<Meet> GetMeets()
        {
            return db.Meets;
        }

        // GET: api/Meets/5
        [ResponseType(typeof(Meet))]
        public IHttpActionResult GetMeet(int id)
        {
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return NotFound();
            }

            return Ok(meet);
        }

        // PUT: api/Meets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeet(int id, Meet meet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meet.MeetId)
            {
                return BadRequest();
            }

            db.Entry(meet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetExists(id))
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

        // POST: api/Meets
        [ResponseType(typeof(Meet))]
        public IHttpActionResult PostMeet(Meet meet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meets.Add(meet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meet.MeetId }, meet);
        }

        // DELETE: api/Meets/5
        [ResponseType(typeof(Meet))]
        public IHttpActionResult DeleteMeet(int id)
        {
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return NotFound();
            }

            db.Meets.Remove(meet);
            db.SaveChanges();

            return Ok(meet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetExists(int id)
        {
            return db.Meets.Count(e => e.MeetId == id) > 0;
        }
    }
}