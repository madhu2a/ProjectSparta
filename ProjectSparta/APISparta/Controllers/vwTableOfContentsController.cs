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
    public class vwTableOfContentsController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/vwTableOfContents
        public IQueryable<vwTableOfContent> GetvwTableOfContents()
        {
            return db.vwTableOfContents;
        }

        // GET: api/vwTableOfContents/5
        [ResponseType(typeof(vwTableOfContent))]
        public IHttpActionResult GetvwTableOfContent(int id)
        {
            vwTableOfContent vwTableOfContent = db.vwTableOfContents.Find(id);
            if (vwTableOfContent == null)
            {
                return NotFound();
            }

            return Ok(vwTableOfContent);
        }

        //// PUT: api/vwTableOfContents/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutvwTableOfContent(int id, vwTableOfContent vwTableOfContent)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != vwTableOfContent.CourseId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(vwTableOfContent).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!vwTableOfContentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/vwTableOfContents
        //[ResponseType(typeof(vwTableOfContent))]
        //public IHttpActionResult PostvwTableOfContent(vwTableOfContent vwTableOfContent)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.vwTableOfContents.Add(vwTableOfContent);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (vwTableOfContentExists(vwTableOfContent.CourseId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = vwTableOfContent.CourseId }, vwTableOfContent);
        //}

        //// DELETE: api/vwTableOfContents/5
        //[ResponseType(typeof(vwTableOfContent))]
        //public IHttpActionResult DeletevwTableOfContent(int id)
        //{
        //    vwTableOfContent vwTableOfContent = db.vwTableOfContents.Find(id);
        //    if (vwTableOfContent == null)
        //    {
        //        return NotFound();
        //    }

        //    db.vwTableOfContents.Remove(vwTableOfContent);
        //    db.SaveChanges();

        //    return Ok(vwTableOfContent);
        //}

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