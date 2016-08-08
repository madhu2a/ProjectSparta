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
    public class TableOfContentsController : Controller
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: TableOfContents
        public async Task<ActionResult> Index()
        {
            return View(await db.TableOfContents.ToListAsync());
        }

        // GET: TableOfContents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOfContent tableOfContent = await db.TableOfContents.FindAsync(id);
            if (tableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(tableOfContent);
        }

        // GET: TableOfContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableOfContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,ChapterId,SubChapterId")] TableOfContent tableOfContent)
        {
            if (ModelState.IsValid)
            {
                db.TableOfContents.Add(tableOfContent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tableOfContent);
        }

        // GET: TableOfContents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOfContent tableOfContent = await db.TableOfContents.FindAsync(id);
            if (tableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(tableOfContent);
        }

        // POST: TableOfContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,ChapterId,SubChapterId")] TableOfContent tableOfContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableOfContent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tableOfContent);
        }

        // GET: TableOfContents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOfContent tableOfContent = await db.TableOfContents.FindAsync(id);
            if (tableOfContent == null)
            {
                return HttpNotFound();
            }
            return View(tableOfContent);
        }

        // POST: TableOfContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TableOfContent tableOfContent = await db.TableOfContents.FindAsync(id);
            db.TableOfContents.Remove(tableOfContent);
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
