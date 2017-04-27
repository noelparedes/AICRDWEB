using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AICRDWEB.Models;

namespace AICRDWEB.Controllers
{
    public class AsociacionesController : BaseController
    {
      //  private AICRDWEBDbContext db = new AICRDWEBDbContext();

        // GET: Asociaciones
        public ActionResult Index()
        {
            //var asoci = dbContext.Asociaciones.Include();
            return View(dbContext.Asociaciones.ToList());
        }

        // GET: Asociaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociacion asociacion = dbContext.Asociaciones.Find(id);
            if (asociacion == null)
            {
                return HttpNotFound();
            }
            return View(asociacion);
        }

        // GET: Asociaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asociaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsociacion,LogoAsociacion,AlternateText,NombreAsociacion,LemaAsociacion")] Asociacion asociacion)
        {
            if (ModelState.IsValid)
            {
                dbContext.Asociaciones.Add(asociacion);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asociacion);
        }

        // GET: Asociaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociacion asociacion = dbContext.Asociaciones.Find(id);
            if (asociacion == null)
            {
                return HttpNotFound();
            }
            return View(asociacion);
        }

        // POST: Asociaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsociacion,LogoAsociacion,AlternateText,NombreAsociacion,LemaAsociacion")] Asociacion asociacion)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(asociacion).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asociacion);
        }

        // GET: Asociaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociacion asociacion = dbContext.Asociaciones.Find(id);
            if (asociacion == null)
            {
                return HttpNotFound();
            }
            return View(asociacion);
        }

        // POST: Asociaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asociacion asociacion = dbContext.Asociaciones.Find(id);
            dbContext.Asociaciones.Remove(asociacion);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
