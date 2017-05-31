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
    public class MiembrosController : BaseController
    {
        //private AICRDWEBDbContext db = new AICRDWEBDbContext();

        // GET: Miembro
        public ActionResult Index()
        {
            var miembros = dbContext.Miembros.Include(m => m.Asociasion).Include(m => m.Cargo).Include(m => m.Circuito).Include(m => m.Iglesia);
            return View(miembros.ToList());
            
        }


        // GET: Miembro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = dbContext.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // GET: Miembro/Create
        public ActionResult Create()
        {
          

            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "NombreAsociacion");
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo");
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito");
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia");
           return View();
        }
       

        // POST: Miembro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMiembro,IdCargo,IdAsociacion,IdIglesia,IdCircuito,Estado,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                dbContext.Miembros.Add(miembros);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "NombreAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", miembros.IdCircuito);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }
        public ActionResult IglesiasbyCircuito(int id)
        {
            var iglesias = dbContext.Iglesias.Where(i => i.IdCircuito == id);
            return Json(new { Iglesias = iglesias.ToList() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Select()
        {
            return View();
        }

        // GET: Miembro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = dbContext.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "NombreAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", miembros.IdCircuito);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }

        // POST: Miembro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMiembro,IdCargo,IdAsociacion,IdIglesia,IdCircuito,Estado,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(miembros).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "NombreAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdCircuito = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", miembros.IdCircuito);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }

        // GET: Miembro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = dbContext.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // POST: Miembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembros miembros = dbContext.Miembros.Find(id);
            dbContext.Miembros.Remove(miembros);
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
