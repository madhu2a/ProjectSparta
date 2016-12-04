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
    public class TableOfContentsController : ApiController
    {
        private DBSpartaEntities db = new DBSpartaEntities();

        // GET: api/TableOfContents
        public IQueryable<TableOfContent> GetTableOfContent()
        {
            return db.TableOfContent;
        }

        // GET: api/TableOfContents/5
        [ResponseType(typeof(TableOfContent))]
        public async Task<IHttpActionResult> GetTableOfContent(int id)
        {
            TableOfContent tableOfContent = await db.TableOfContent.FindAsync(id);
            if (tableOfContent == null)
            {
                return NotFound();
            }

            return Ok(tableOfContent);
        }

        // PUT: api/TableOfContents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTableOfContent(int id, TableOfContent tableOfContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableOfContent.CourseId)
            {
                return BadRequest();
            }

            db.Entry(tableOfContent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableOfContentExists(id))
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

        // POST: api/TableOfContents
        [ResponseType(typeof(TableOfContent))]
        public async Task<IHttpActionResult> PostTableOfContent(TableOfContent tableOfContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TableOfContent.Add(tableOfContent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableOfContentExists(tableOfContent.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tableOfContent.CourseId }, tableOfContent);
        }

        // DELETE: api/TableOfContents/5
        [ResponseType(typeof(TableOfContent))]
        public async Task<IHttpActionResult> DeleteTableOfContent(int id)
        {
            TableOfContent tableOfContent = await db.TableOfContent.FindAsync(id);
            if (tableOfContent == null)
            {
                return NotFound();
            }

            db.TableOfContent.Remove(tableOfContent);
            await db.SaveChangesAsync();

            return Ok(tableOfContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TableOfContentExists(int id)
        {
            return db.TableOfContent.Count(e => e.CourseId == id) > 0;
        }
    }
}