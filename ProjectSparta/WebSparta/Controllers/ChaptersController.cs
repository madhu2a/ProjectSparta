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
    public class ChaptersController : Controller
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: Chapters
        public async Task<ActionResult> Index()
        {
            var chapters = db.Chapters.Include(c => c.Course);
            return View(await chapters.ToListAsync());
        }

        // GET: Chapters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chapter chapter = await db.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return HttpNotFound();
            }
            return View(chapter);
        }

        // GET: Chapters/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: Chapters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ChapterId,ChapterName,Duration,CourseId")] Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Chapters.Add(chapter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            return View(chapter);
        }

        // GET: Chapters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chapter chapter = await db.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            return View(chapter);
        }

        // POST: Chapters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ChapterId,ChapterName,Duration,CourseId")] Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chapter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            return View(chapter);
        }

        // GET: Chapters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chapter chapter = await db.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return HttpNotFound();
            }
            return View(chapter);
        }

        // POST: Chapters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Chapter chapter = await db.Chapters.FindAsync(id);
            db.Chapters.Remove(chapter);
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
