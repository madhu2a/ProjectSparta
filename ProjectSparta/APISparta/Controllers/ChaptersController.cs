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
    public class ChaptersController : ApiController
    {
        private DBSpartaEntities db = new DBSpartaEntities();

        // GET: api/Chapters
        public IQueryable<Chapter> GetChapter()
        {
            return db.Chapter;
        }

        // GET: api/Chapters/5
        [ResponseType(typeof(Chapter))]
        public async Task<IHttpActionResult> GetChapter(int id)
        {
            Chapter chapter = await db.Chapter.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter);
        }

        // PUT: api/Chapters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChapter(int id, Chapter chapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chapter.ChapterId)
            {
                return BadRequest();
            }

            db.Entry(chapter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        [ResponseType(typeof(Chapter))]
        public async Task<IHttpActionResult> PostChapter(Chapter chapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chapter.Add(chapter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chapter.ChapterId }, chapter);
        }

        // DELETE: api/Chapters/5
        [ResponseType(typeof(Chapter))]
        public async Task<IHttpActionResult> DeleteChapter(int id)
        {
            Chapter chapter = await db.Chapter.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            db.Chapter.Remove(chapter);
            await db.SaveChangesAsync();

            return Ok(chapter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChapterExists(int id)
        {
            return db.Chapter.Count(e => e.ChapterId == id) > 0;
        }
    }
}