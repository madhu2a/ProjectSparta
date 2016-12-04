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
    public class SubChaptersController : Controller
    {
        private DBSpartaEntities db = new DBSpartaEntities();

        // GET: SubChapters
        public async Task<ActionResult> Index()
        {
            var subChapter = db.SubChapter.Include(s => s.Chapter);
            return View(await subChapter.ToListAsync());
        }

        // GET: SubChapters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubChapter subChapter = await db.SubChapter.FindAsync(id);
            if (subChapter == null)
            {
                return HttpNotFound();
            }
            return View(subChapter);
        }

        // GET: SubChapters/Create
        public ActionResult Create()
        {
            ViewBag.ChapterId = new SelectList(db.Chapter, "ChapterId", "ChapterName");
            return View();
        }

        // POST: SubChapters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubChapterId,SubChapterName,Duration,ChapterId")] SubChapter subChapter)
        {
            if (ModelState.IsValid)
            {
                db.SubChapter.Add(subChapter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChapterId = new SelectList(db.Chapter, "ChapterId", "ChapterName", subChapter.ChapterId);
            return View(subChapter);
        }

        // GET: SubChapters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubChapter subChapter = await db.SubChapter.FindAsync(id);
            if (subChapter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChapterId = new SelectList(db.Chapter, "ChapterId", "ChapterName", subChapter.ChapterId);
            return View(subChapter);
        }

        // POST: SubChapters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubChapterId,SubChapterName,Duration,ChapterId")] SubChapter subChapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subChapter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChapterId = new SelectList(db.Chapter, "ChapterId", "ChapterName", subChapter.ChapterId);
            return View(subChapter);
        }

        // GET: SubChapters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubChapter subChapter = await db.SubChapter.FindAsync(id);
            if (subChapter == null)
            {
                return HttpNotFound();
            }
            return View(subChapter);
        }

        // POST: SubChapters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubChapter subChapter = await db.SubChapter.FindAsync(id);
            db.SubChapter.Remove(subChapter);
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
