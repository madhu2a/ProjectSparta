﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ThinkLogic;

namespace APISparta.Controllers
{
    public class CollegesController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/Colleges
        public IQueryable<College> GetColleges()
        {
            return db.Colleges;
        }

        // GET: api/Colleges/5
        [ResponseType(typeof(College))]
        public IHttpActionResult GetCollege(int id)
        {
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        // PUT: api/Colleges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollege(int id, College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != college.CollegeId)
            {
                return BadRequest();
            }

            db.Entry(college).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
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

        // POST: api/Colleges
        [ResponseType(typeof(College))]
        public IHttpActionResult PostCollege(College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colleges.Add(college);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CollegeExists(college.CollegeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = college.CollegeId }, college);
        }

        // DELETE: api/Colleges/5
        [ResponseType(typeof(College))]
        public IHttpActionResult DeleteCollege(int id)
        {
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            db.Colleges.Remove(college);
            db.SaveChanges();

            return Ok(college);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollegeExists(int id)
        {
            return db.Colleges.Count(e => e.CollegeId == id) > 0;
        }
    }
}