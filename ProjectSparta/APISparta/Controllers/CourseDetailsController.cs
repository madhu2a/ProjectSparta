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
using ThinkLogic;

namespace APISparta.Controllers
{
    public class CourseDetailsController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/CourseDetails
        public IQueryable<CourseDetail> GetCourseDetails()
        {
            return db.CourseDetails;
        }

        // GET: api/CourseDetails/5
        [ResponseType(typeof(CourseDetail))]
        public IHttpActionResult GetCourseDetail(int id)
        {
            CourseDetail courseDetail = db.CourseDetails.Find(id);
            if (courseDetail == null)
            {
                return NotFound();
            }

            return Ok(courseDetail);
        }

        // PUT: api/CourseDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseDetail(int id, CourseDetail courseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseDetail.CourseId)
            {
                return BadRequest();
            }

            db.Entry(courseDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseDetailExists(id))
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

        // POST: api/CourseDetails
        [ResponseType(typeof(CourseDetail))]
        public IHttpActionResult PostCourseDetail(CourseDetail courseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseDetails.Add(courseDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CourseDetailExists(courseDetail.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = courseDetail.CourseId }, courseDetail);
        }

        // DELETE: api/CourseDetails/5
        [ResponseType(typeof(CourseDetail))]
        public IHttpActionResult DeleteCourseDetail(int id)
        {
            CourseDetail courseDetail = db.CourseDetails.Find(id);
            if (courseDetail == null)
            {
                return NotFound();
            }

            db.CourseDetails.Remove(courseDetail);
            db.SaveChanges();

            return Ok(courseDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseDetailExists(int id)
        {
            return db.CourseDetails.Count(e => e.CourseId == id) > 0;
        }
    }
}