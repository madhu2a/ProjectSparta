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
    public class TableOfContentsController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/TableOfContents
        public IQueryable<TableOfContent> GetTableOfContents()
        {
            return db.TableOfContents;
        }

        // GET: api/TableOfContents/5
        [ResponseType(typeof(TableOfContent))]
        public IHttpActionResult GetTableOfContent(int id)
        {
            TableOfContent tableOfContent = db.TableOfContents.Find(id);
            if (tableOfContent == null)
            {
                return NotFound();
            }

            return Ok(tableOfContent);
        }

        // PUT: api/TableOfContents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTableOfContent(int id, TableOfContent tableOfContent)
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
                db.SaveChanges();
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
        public IHttpActionResult PostTableOfContent(TableOfContent tableOfContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TableOfContents.Add(tableOfContent);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult DeleteTableOfContent(int id)
        {
            TableOfContent tableOfContent = db.TableOfContents.Find(id);
            if (tableOfContent == null)
            {
                return NotFound();
            }

            db.TableOfContents.Remove(tableOfContent);
            db.SaveChanges();

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
            return db.TableOfContents.Count(e => e.CourseId == id) > 0;
        }
    }
}