using AICRDWEB.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AICRDWEB.Controllers
{
    public class RegionsController : BaseController
    {


        // GET: Regions
        public ActionResult Index()
        {
            return View(dbContext.Regiones.ToList());
        }

        // GET: Regiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = dbContext.Regiones.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRegion,NombreRegion")] Region region)
        {
            if (ModelState.IsValid)
            {
                dbContext.Regiones.Add(region);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(region);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = dbContext.Regiones.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRegion,NombreRegion")] Region region)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(region).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = dbContext.Regiones.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = dbContext.Regiones.Find(id);
            dbContext.Regiones.Remove(region);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
