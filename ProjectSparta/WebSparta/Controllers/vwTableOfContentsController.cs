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
    public class vwTableOfContentsController : Controller
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: vwTableOfContents
        public async Task<ActionResult> Index()
        {
            return View(await db.vwTableOfContents.ToListAsync());
        }

        // GET: vwTableOfContents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            if (vwTableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(vwTableOfContent);
        }

        // GET: vwTableOfContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vwTableOfContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,CourseName,ChapterId,ChapterName")] vwTableOfContent vwTableOfContent)
        {
            if (ModelState.IsValid)
            {
                db.vwTableOfContents.Add(vwTableOfContent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vwTableOfContent);
        }

        // GET: vwTableOfContents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            if (vwTableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(vwTableOfContent);
        }

        // POST: vwTableOfContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,CourseName,ChapterId,ChapterName")] vwTableOfContent vwTableOfContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwTableOfContent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vwTableOfContent);
        }

        // GET: vwTableOfContents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            if (vwTableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(vwTableOfContent);
        }

        // POST: vwTableOfContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vwTableOfContent vwTableOfContent = await db.vwTableOfContents.FindAsync(id);
            db.vwTableOfContents.Remove(vwTableOfContent);
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
