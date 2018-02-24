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
    public class PupilsController : Controller
    {


        private AcademyModel db = new AcademyModel();
        private IPupilsRepository _pupilRepository;
        public PupilsController()
        {
            this._pupilRepository = new PupilsRepository(new AcademyModel());
        }


    
 

        // GET: Pupils
        public ActionResult Index()
        {
            var pupils = from pupil in _pupilRepository.GetPupil()
                            select pupil;
          //var pupils2=pupils.Include(p => p.Classrooms).Include(p => p.Levels).Include(p => p.Tutors);
            return View(pupils);

            //var pupils = db.Pupils.Include(p => p.Classrooms).Include(p => p.Levels).Include(p => p.Tutors);
           // return View(pupils.ToList());
        }

        // GET: Pupils/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pupils pupils = _pupilRepository.GetPupilByID(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        // GET: Pupils/Create
        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(_pupilRepository.GetClassroom(), "id", "Title");
            ViewBag.Level_Id = new SelectList(_pupilRepository.GetLevels(), "id", "Title");
            ViewBag.Tutor_Id = new SelectList(_pupilRepository.GetTutors(), "id", "LastName");
            return View();
        }

        // POST: Pupils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Sex,BirthdayDate,State,Tutor_Id,Classroom_Id,Level_Id")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                pupils.Id = Guid.NewGuid();
                _pupilRepository.InsertPupil(pupils);
                _pupilRepository.Save();
                //db.Pupils.Add(pupils);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(_pupilRepository.GetClassroom(), "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(_pupilRepository.GetLevels(), "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(_pupilRepository.GetTutors(), "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = _pupilRepository.GetPupilByID(id);
           // Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(_pupilRepository.GetClassroom(), "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(_pupilRepository.GetLevels(), "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(_pupilRepository.GetTutors(), "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // POST: Pupils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Sex,BirthdayDate,State,Tutor_Id,Classroom_Id,Level_Id")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                _pupilRepository.UpdatePupil(pupils);
                // db.Entry(pupils).State = EntityState.Modified;
                _pupilRepository.Save();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(_pupilRepository.GetClassroom(), "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(_pupilRepository.GetLevels(), "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(_pupilRepository.GetTutors(), "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = _pupilRepository.GetPupilByID(id);
            //Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            Pupils pupils = _pupilRepository.GetPupilByID(id);
            // Pupils pupils = db.Pupils.Find(id);
            _pupilRepository.DeletePupil(id);
            _pupilRepository.Save();
            //db.Pupils.Remove(pupils);
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
