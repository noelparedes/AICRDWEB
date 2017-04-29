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
    public class RegistroGeneralController : BaseController
    {
        //private AICRDWEBDbContext db = new AICRDWEBDbContext();

        // GET: RegistroGeneral
        public ActionResult Index()
        {
            var registros = dbContext.Registros.Include(r => r.Circuito).Include(r => r.Iglesia).Include(r => r.Miembro);
            return View(registros.ToList());
        }

        // GET: RegistroGeneral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroConvencion registroConvencion = dbContext.Registros.Find(id);
            if (registroConvencion == null)
            {
                return HttpNotFound();
            }
            return View(registroConvencion);
        }

        // GET: RegistroGeneral/Create
        public ActionResult Create()
        {
            ViewBag.IdCircuitos = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito");
          
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia");
            ViewBag.IdMiembro = new SelectList(dbContext.Miembros, "IdMiembro", "Nombres");
            return View();
        }

        // POST: RegistroGeneral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRegistro,IdMiembro,IdCircuitos,IdIglesia,Costo,FechaRegistro,Exhonerado,Observaciones,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] RegistroConvencion registroConvencion)
        {
            if (ModelState.IsValid)
            {
                dbContext.Registros.Add(registroConvencion);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCircuitos = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", registroConvencion.IdCircuitos);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", registroConvencion.IdIglesia);
            ViewBag.IdMiembro = new SelectList(dbContext.Miembros, "IdMiembro", "Nombres", registroConvencion.IdMiembro);
            return View(registroConvencion);
        }

        // GET: RegistroGeneral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroConvencion registroConvencion = dbContext.Registros.Find(id);
            if (registroConvencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCircuitos = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", registroConvencion.IdCircuitos);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", registroConvencion.IdIglesia);
            ViewBag.IdMiembro = new SelectList(dbContext.Miembros, "IdMiembro", "Nombres", registroConvencion.IdMiembro);
            return View(registroConvencion);
        }

        // POST: RegistroGeneral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRegistro,IdMiembro,IdCircuitos,IdIglesia,Costo,FechaRegistro,Exhonerado,Observaciones,Nombres,Apellidos,Direccion,FechaNacimiento,Telefono")] RegistroConvencion registroConvencion)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(registroConvencion).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCircuitos = new SelectList(dbContext.Circuitos, "IdCircuito", "NombreCircuito", registroConvencion.IdCircuitos);
            ViewBag.IdIglesia = new SelectList(dbContext.Iglesias, "IdIglesia", "NombreIglesia", registroConvencion.IdIglesia);
            ViewBag.IdMiembro = new SelectList(dbContext.Miembros, "IdMiembro", "Nombres", registroConvencion.IdMiembro);
            return View(registroConvencion);
        }

        // GET: RegistroGeneral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroConvencion registroConvencion = dbContext.Registros.Find(id);
            if (registroConvencion == null)
            {
                return HttpNotFound();
            }
            return View(registroConvencion);
        }

        // POST: RegistroGeneral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroConvencion registroConvencion = dbContext.Registros.Find(id);
            dbContext.Registros.Remove(registroConvencion);
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
