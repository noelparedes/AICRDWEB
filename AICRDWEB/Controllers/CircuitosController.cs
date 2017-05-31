using AICRDWEB.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AICRDWEB.Controllers
{
    public class CircuitosController : BaseController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Circuitos
        public ActionResult Index(int? page)
        {
            var circuitos = dbContext.Circuitos.Include(c => c.Region);
            return View(circuitos.ToList().ToPagedList(page ?? 1,10));
        }

        // GET: Circuitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuitos circuitos = dbContext.Circuitos.Find(id);
            if (circuitos == null)
            {
                return HttpNotFound();
            }
            return View(circuitos);
        }

        // GET: Circuitos/Create
        public ActionResult Create()
        {
            ViewBag.IdRegion = new SelectList(dbContext.Regiones, "IdRegion", "NombreRegion");
            return View();
        }

        // POST: Circuitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCircuito,IdRegion,NombreCircuito,Descripcion")] Circuitos circuitos)
        {
            if (ModelState.IsValid)
            {
                dbContext.Circuitos.Add(circuitos);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRegion = new SelectList(dbContext.Regiones, "IdRegion", "NombreRegion", circuitos.IdRegion);
            return View(circuitos);
        }

        // GET: Circuitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuitos circuitos = dbContext.Circuitos.Find(id);
            if (circuitos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRegion = new SelectList(dbContext.Regiones, "IdRegion", "NombreRegion", circuitos.IdRegion);
            return View(circuitos);
        }

        // POST: Circuitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCircuito,IdRegion,NombreCircuito,Descripcion")] Circuitos circuitos)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(circuitos).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRegion = new SelectList(dbContext.Regiones, "IdRegion", "NombreRegion", circuitos.IdRegion);
            return View(circuitos);
        }

        // GET: Circuitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuitos circuitos = dbContext.Circuitos.Find(id);
            if (circuitos == null)
            {
                return HttpNotFound();
            }
            return View(circuitos);
        }

        // POST: Circuitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circuitos circuitos = dbContext.Circuitos.Find(id);
            dbContext.Circuitos.Remove(circuitos);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
