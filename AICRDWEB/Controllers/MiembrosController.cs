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

        // GET: Miembros
        public ActionResult Index()
        {
            var miembros = dbContext.Miembros.Include(m => m.Asociasion).Include(m => m.Cargo).Include(m => m.Iglesia);
            return View(miembros.ToList());
        }

        // GET: Miembros/Details/5
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

        // GET: Miembros/Create
        public ActionResult Create()
        {
            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "LogoAsociacion");
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo");
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia");
            return View();
        }

        // POST: Miembros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMiembro,IdCargo,IdAsociacion,IdIglesia,Estado,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                dbContext.Miembros.Add(miembros);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "LogoAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }

        // GET: Miembros/Edit/5
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
            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "LogoAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }

        // POST: Miembros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMiembro,IdCargo,IdAsociacion,IdIglesia,Estado,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(miembros).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAsociacion = new SelectList(dbContext.Asociaciones, "IdAsociacion", "LogoAsociacion", miembros.IdAsociacion);
            ViewBag.IdCargo = new SelectList(dbContext.Cargos, "IdCargo", "Cargo", miembros.IdCargo);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", miembros.IdIglesia);
            return View(miembros);
        }

        // GET: Miembros/Delete/5
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

        // POST: Miembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembros miembros = dbContext.Miembros.Find(id);
            dbContext.Miembros.Remove(miembros);
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
