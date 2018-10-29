using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDPersona.Models;
using System.Data.Entity;
using System.Net;

namespace CRUDPersona.Controllers
{
    public class PersonaController : Controller
    {

        CRUDEntities db = new CRUDEntities();
        // GET: Persona
        public ActionResult Index()
        {
            return View(db.Persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona p = db.Persona.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Edad,Direccion,Telefono")] Persona p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Entry(p).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona p = db.Persona.Find(id);
            if(p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Apellido,Edad,Direccion,Telefono")] Persona p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona p = db.Persona.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Persona persona)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Persona p = db.Persona.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }

                persona = p;

                db.Entry(persona).State = EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
