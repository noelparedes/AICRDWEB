using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AICRDWEB.Models;
using PagedList;
using PagedList.Mvc;

namespace AICRDWEB.Controllers
{
    public class IglesiasController : BaseController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Iglesias
        public ActionResult Index(int? page)
        {
            var iglesias = dbContext.Iglesias.Include(i => i.Circuito);
            return View(iglesias.ToList().ToPagedList(page ?? 1,10));
        }




        public ActionResult IglesiasbyCircuito(int id)
        {
            var iglesias = dbContext.Iglesias.Where(i => i.IdCircuito == id);
            return Json(new { Iglesias = iglesias.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: Iglesias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesias iglesias = dbContext.Iglesias.Find(id);
            if (iglesias == null)
            {
                return HttpNotFound();
            }
            return View(iglesias);
        }

        // GET: Iglesias/Create
        public ActionResult Create()
        {
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito");
            return View();
        }

        // POST: Iglesias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIglesia,IdCircuito,NombreIglesia,Descripcion,Fundador,FechaFundacion,CantidadMiembro,Direccion")] Iglesias iglesias)
        {
            if (ModelState.IsValid)
            {
                dbContext.Iglesias.Add(iglesias);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", iglesias.IdCircuito);
            return View(iglesias);
        }

        // GET: Iglesias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesias iglesias = dbContext.Iglesias.Find(id);
            if (iglesias == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", iglesias.IdCircuito);
            return View(iglesias);
        }

        // POST: Iglesias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIglesia,IdCircuito,NombreIglesia,Descripcion,Fundador,FechaFundacion,CantidadMiembro,Direccion")] Iglesias iglesias)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(iglesias).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", iglesias.IdCircuito);
            return View(iglesias);
        }

        // GET: Iglesias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesias iglesias = dbContext.Iglesias.Find(id);
            if (iglesias == null)
            {
                return HttpNotFound();
            }
            return View(iglesias);
        }

        // POST: Iglesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iglesias iglesias = dbContext.Iglesias.Find(id);
            dbContext.Iglesias.Remove(iglesias);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        dbContext.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
