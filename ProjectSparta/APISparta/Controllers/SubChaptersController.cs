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
    public class SubChaptersController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/SubChapters
        public IQueryable<SubChapter> GetSubChapters()
        {
            return db.SubChapters;
        }

        // GET: api/SubChapters/5
        [ResponseType(typeof(SubChapter))]
        public IHttpActionResult GetSubChapter(int id)
        {
            SubChapter subChapter = db.SubChapters.Find(id);
            if (subChapter == null)
            {
                return NotFound();
            }

            return Ok(subChapter);
        }

        // PUT: api/SubChapters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubChapter(int id, SubChapter subChapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subChapter.SubChapterId)
            {
                return BadRequest();
            }

            db.Entry(subChapter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubChapterExists(id))
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

        // POST: api/SubChapters
        [ResponseType(typeof(SubChapter))]
        public IHttpActionResult PostSubChapter(SubChapter subChapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubChapters.Add(subChapter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SubChapterExists(subChapter.SubChapterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subChapter.SubChapterId }, subChapter);
        }

        // DELETE: api/SubChapters/5
        [ResponseType(typeof(SubChapter))]
        public IHttpActionResult DeleteSubChapter(int id)
        {
            SubChapter subChapter = db.SubChapters.Find(id);
            if (subChapter == null)
            {
                return NotFound();
            }

            db.SubChapters.Remove(subChapter);
            db.SaveChanges();

            return Ok(subChapter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubChapterExists(int id)
        {
            return db.SubChapters.Count(e => e.SubChapterId == id) > 0;
        }
    }
}