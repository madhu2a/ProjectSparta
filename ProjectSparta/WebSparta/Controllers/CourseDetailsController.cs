using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThinkLogic;

namespace WebSparta.Controllers
{
    public class CourseDetailsController : Controller
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: CourseDetails
        public async Task<ActionResult> Index()
        {
            var courseDetails = db.CourseDetails.Include(c => c.Author).Include(c => c.Course);
            return View(await courseDetails.ToListAsync());
        }

        // GET: CourseDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDetail courseDetail = await db.CourseDetails.FindAsync(id);
            if (courseDetail == null)
            {
                return HttpNotFound();
            }
            return View(courseDetail);
        }

        // GET: CourseDetails/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: CourseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,AuthorId,Level,DateOfAdd,Duration,Rating")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.CourseDetails.Add(courseDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", courseDetail.AuthorId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseDetail.CourseId);
            return View(courseDetail);
        }

        // GET: CourseDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDetail courseDetail = await db.CourseDetails.FindAsync(id);
            if (courseDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", courseDetail.AuthorId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseDetail.CourseId);
            return View(courseDetail);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,AuthorId,Level,DateOfAdd,Duration,Rating")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", courseDetail.AuthorId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseDetail.CourseId);
            return View(courseDetail);
        }

        // GET: CourseDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDetail courseDetail = await db.CourseDetails.FindAsync(id);
            if (courseDetail == null)
            {
                return HttpNotFound();
            }
            return View(courseDetail);
        }

        // POST: CourseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CourseDetail courseDetail = await db.CourseDetails.FindAsync(id);
            db.CourseDetails.Remove(courseDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
