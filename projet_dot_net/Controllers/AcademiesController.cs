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
    public class AcademiesController : Controller
    {
       
        private IAcademyRepository _academyRepository;
        public AcademiesController()
        {
            this._academyRepository = new AcademyRepository(new AcademyModel());
        }
        // GET: Academies
        public ActionResult Index()
        {

            var academies = from academy in _academyRepository.GetAcademy()
                        select academy;
            return View(academies);
            //return View(db.Academies.ToList());
        }

        // GET: Academies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Academies academies = _academyRepository.GetAcademyByID(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);

            //Book student = _bookRepository.GetBookByID(id);
            //return View(student);
        }

        // GET: Academies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academies/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Academies academies)
        {


            if (ModelState.IsValid)
            {
                academies.Id = Guid.NewGuid();
                _academyRepository.InsertAcademy(academies);
                _academyRepository.Save();
                return RedirectToAction("Index");
            }

            return View(academies);
        }

        // GET: Academies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = _academyRepository.GetAcademyByID(id);
            //Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        // POST: Academies/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Academies academies)
        {
            if (ModelState.IsValid)
            {
                _academyRepository.UpdateAcademy(academies);
                // db.Entry(academies).State = EntityState.Modified;
                _academyRepository.Save();
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academies);
        }

        // GET: Academies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = _academyRepository.GetAcademyByID(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            
            _academyRepository.DeleteAcademy(id);
            _academyRepository.Save();
            //db.Academies.Remove(academies);
           // db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _academyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
