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
    public class ClassroomsController : Controller
    {

        private AcademyModel db = new AcademyModel();
        private IClassroomsRepository _classroomsRepository;
        public ClassroomsController()
        {
            this._classroomsRepository = new ClassroomsRepository(new AcademyModel());
        }


        // GET: Classrooms
        public ActionResult Index()
        {
            var classrooms = from classroom in _classroomsRepository.GetClassroom()
                         select classroom;
            //var pupils2=pupils.Include(p => p.Classrooms).Include(p => p.Levels).Include(p => p.Tutors);
            return View(classrooms);
        }

        // GET: Classrooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms= _classroomsRepository.GetClassroomByID(id);
           // Classrooms classrooms = db.Classrooms.Find(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        // GET: Classrooms/Create
        public ActionResult Create()
        {
            ViewBag.Establishment_Id = new SelectList(_classroomsRepository.GetEstablishments(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_classroomsRepository.GetUsers(), "Id", "UserName");
            ViewBag.Year_Id = new SelectList(_classroomsRepository.GetYears(), "Id", "Year");
            return View();
        }

        // POST: Classrooms/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                classrooms.Id = Guid.NewGuid();
                _classroomsRepository.InsertClassroom(classrooms);
                _classroomsRepository.Save();
                //db.Classrooms.Add(classrooms);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Establishment_Id = new SelectList(_classroomsRepository.GetEstablishments(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_classroomsRepository.GetUsers(), "Id", "UserName");
            ViewBag.Year_Id = new SelectList(_classroomsRepository.GetYears(), "Id", "Year");
            return View();
        }

        // GET: Classrooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = _classroomsRepository.GetClassroomByID(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.Establishment_Id = new SelectList(_classroomsRepository.GetEstablishments(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_classroomsRepository.GetUsers(), "Id", "UserName");
            ViewBag.Year_Id = new SelectList(_classroomsRepository.GetYears(), "Id", "Year");
            return View();
        }

        // POST: Classrooms/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                _classroomsRepository.UpdateClassroom(classrooms);
                _classroomsRepository.Save();
               // db.Entry(classrooms).State = EntityState.Modified;
               // db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Establishment_Id = new SelectList(_classroomsRepository.GetEstablishments(), "Id", "Name");
            ViewBag.User_Id = new SelectList(_classroomsRepository.GetUsers(), "Id", "UserName");
            ViewBag.Year_Id = new SelectList(_classroomsRepository.GetYears(), "Id", "Year");
            return View();
        }

        // GET: Classrooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = _classroomsRepository.GetClassroomByID(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Classrooms classrooms = _classroomsRepository.GetClassroomByID(id);
            _classroomsRepository.DeleteClassroom(id);
            _classroomsRepository.Save();
            //db.Classrooms.Remove(classrooms);
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
