using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ThinkLogic;

namespace APISparta.Controllers
{
    public class CourseDetailsController : ApiController
    {
        private DBSpartaEntities db = new DBSpartaEntities();

        // GET: api/CourseDetails
        public IQueryable<CourseDetails> GetCourseDetails()
        {
            return db.CourseDetails;
        }

        // GET: api/CourseDetails/5
        [ResponseType(typeof(CourseDetails))]
        public async Task<IHttpActionResult> GetCourseDetails(int id)
        {
            CourseDetails courseDetails = await db.CourseDetails.FindAsync(id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return Ok(courseDetails);
        }

        // PUT: api/CourseDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourseDetails(int id, CourseDetails courseDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseDetails.CourseId)
            {
                return BadRequest();
            }

            db.Entry(courseDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseDetailsExists(id))
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
        [ResponseType(typeof(CourseDetails))]
        public async Task<IHttpActionResult> PostCourseDetails(CourseDetails courseDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseDetails.Add(courseDetails);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseDetailsExists(courseDetails.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = courseDetails.CourseId }, courseDetails);
        }

        // DELETE: api/CourseDetails/5
        [ResponseType(typeof(CourseDetails))]
        public async Task<IHttpActionResult> DeleteCourseDetails(int id)
        {
            CourseDetails courseDetails = await db.CourseDetails.FindAsync(id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            db.CourseDetails.Remove(courseDetails);
            await db.SaveChangesAsync();

            return Ok(courseDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseDetailsExists(int id)
        {
            return db.CourseDetails.Count(e => e.CourseId == id) > 0;
        }
    }
}