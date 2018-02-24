using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projet_dot_net.Model;
using projet_dot_net.Repository;

namespace projet_dot_net.Controllers
{
    public class EstablishmentsController : Controller
    {

        private IEstablishmentsRepository _establishmentRepository;
        public EstablishmentsController()
        {
            this._establishmentRepository = new EstablishmentsRepository(new AcademyModel());
        }

        // GET: Establishments
        public ActionResult Index()
        {
            var establishments = _establishmentRepository.GetEstablishments();
            return View(establishments);
        }

        // GET: Establishments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = _establishmentRepository.GetEstablishmentByID(id);
            //Establishments establishments = db.Establishments.Find(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        // GET: Establishments/Create
        public ActionResult Create()
        {
            ViewBag.Academie_Id = new SelectList(_establishmentRepository.GetAcademies(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_establishmentRepository.GetUsers(), "Id", "UserName");
            return View();
        }

        // POST: Establishments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                establishments.Id = Guid.NewGuid();
                _establishmentRepository.InsertEstablishment(establishments);
                _establishmentRepository.Save();
                //db.Establishments.Add(establishments);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Academie_Id = new SelectList(_establishmentRepository.GetAcademies(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_establishmentRepository.GetUsers(), "Id", "UserName");
            return View();
        }

        // GET: Establishments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = _establishmentRepository.GetEstablishmentByID(id);
           // Establishments establishments = db.Establishments.Find(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Academie_Id = new SelectList(_establishmentRepository.GetAcademies(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_establishmentRepository.GetUsers(), "Id", "UserName");
            return View();
        }

        // POST: Establishments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                _establishmentRepository.UpdateEstablishment(establishments);
                _establishmentRepository.Save();
                //db.Entry(establishments).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Academie_Id = new SelectList(_establishmentRepository.GetAcademies(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_establishmentRepository.GetUsers(), "Id", "UserName");
            return View();
        }

        // GET: Establishments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = _establishmentRepository.GetEstablishmentByID(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _establishmentRepository.DeleteEstablishment(id);
            _establishmentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _establishmentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
