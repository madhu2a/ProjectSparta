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
    public class vwTableOfContentsController : ApiController
    {
        private dbSpartaEntities1 db = new dbSpartaEntities1();

        // GET: api/vwTableOfContents
        public IQueryable<vwTableOfContent> GetvwTableOfContents()
        {
            return db.vwTableOfContents;
        }

        // GET: api/vwTableOfContents/5
        [ResponseType(typeof(vwTableOfContent))]
        public async Task<IHttpActionResult> GetvwTableOfContent(int id)
        {
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            if (vwTableOfContent == null)
            {
                return NotFound();
            }

            return Ok(vwTableOfContent);
        }

        // PUT: api/vwTableOfContents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutvwTableOfContent(int id, vwTableOfContent vwTableOfContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vwTableOfContent.CourseId)
            {
                return BadRequest();
            }

            db.Entry(vwTableOfContent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vwTableOfContentExists(id))
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

        // POST: api/vwTableOfContents
        [ResponseType(typeof(vwTableOfContent))]
        public async Task<IHttpActionResult> PostvwTableOfContent(vwTableOfContent vwTableOfContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vwTableOfContents.Add(vwTableOfContent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (vwTableOfContentExists(vwTableOfContent.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vwTableOfContent.CourseId }, vwTableOfContent);
        }

        // DELETE: api/vwTableOfContents/5
        [ResponseType(typeof(vwTableOfContent))]
        public async Task<IHttpActionResult> DeletevwTableOfContent(int id)
        {
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            if (vwTableOfContent == null)
            {
                return NotFound();
            }

            db.vwTableOfContents.Remove(vwTableOfContent);
            await db.SaveChangesAsync();

            return Ok(vwTableOfContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vwTableOfContentExists(int id)
        {
            return db.vwTableOfContents.Count(e => e.CourseId == id) > 0;
        }
    }
}