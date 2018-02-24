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
    public class TutorsController : Controller
    {


        private AcademyModel db = new AcademyModel();
        private ITutorsRepository _tutorRepository;
        public TutorsController()
        {
            this._tutorRepository = new TutorsRepository(new AcademyModel());
        }
   

        // GET: Tutors
        public ActionResult Index()
        {
            var tutors = from tutor in _tutorRepository.GetTutors()
                         select tutor;
                       return View(tutors);
        }

        // GET: Tutors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = _tutorRepository.GetTutorByID(id);
            //Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                tutors.Id = Guid.NewGuid();
                _tutorRepository.InsertTutor(tutors);
                _tutorRepository.Save();
                //db.Tutors.Add(tutors);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutors);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = _tutorRepository.GetTutorByID(id);
            //Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                _tutorRepository.UpdateTutor(tutors);
                _tutorRepository.Save();
                //db.Entry(tutors).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutors);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = _tutorRepository.GetTutorByID(id);
            //Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tutors tutors = _tutorRepository.GetTutorByID(id);
            _tutorRepository.DeleteTutor(id);
            _tutorRepository.Save();
            //Tutors tutors = db.Tutors.Find(id);
            //db.Tutors.Remove(tutors);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
