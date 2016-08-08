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
    public class CollegesController : Controller
    {
        private dbSpartaEntities1 db = new dbSpartaEntities1();

        // GET: Colleges
        public async Task<ActionResult> Index()
        {
            var colleges = db.Colleges.Include(c => c.District).Include(c => c.State);
            return View(await colleges.ToListAsync());
        }

        // GET: Colleges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: Colleges/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name");
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name");
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CollegeId,Name,StateId,Address,DistrictId")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Colleges.Add(college);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", college.DistrictId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", college.StateId);
            return View(college);
        }

        // GET: Colleges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", college.DistrictId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", college.StateId);
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CollegeId,Name,StateId,Address,DistrictId")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", college.DistrictId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", college.StateId);
            return View(college);
        }

        // GET: Colleges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            College college = await db.Colleges.FindAsync(id);
            db.Colleges.Remove(college);
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
