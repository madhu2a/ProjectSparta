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
    public class SubChaptersController : ApiController
    {
        private dbSpartaEntities1 db = new dbSpartaEntities1();

        // GET: api/SubChapters
        public IQueryable<SubChapter> GetSubChapters()
        {
            return db.SubChapters;
        }

        // GET: api/SubChapters/5
        [ResponseType(typeof(SubChapter))]
        public async Task<IHttpActionResult> GetSubChapter(int id)
        {
            SubChapter subChapter = await db.SubChapters.FindAsync(id);
            if (subChapter == null)
            {
                return NotFound();
            }

            return Ok(subChapter);
        }

        // PUT: api/SubChapters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubChapter(int id, SubChapter subChapter)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostSubChapter(SubChapter subChapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubChapters.Add(subChapter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subChapter.SubChapterId }, subChapter);
        }

        // DELETE: api/SubChapters/5
        [ResponseType(typeof(SubChapter))]
        public async Task<IHttpActionResult> DeleteSubChapter(int id)
        {
            SubChapter subChapter = await db.SubChapters.FindAsync(id);
            if (subChapter == null)
            {
                return NotFound();
            }

            db.SubChapters.Remove(subChapter);
            await db.SaveChangesAsync();

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