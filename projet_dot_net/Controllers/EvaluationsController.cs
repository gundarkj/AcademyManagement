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
    public class EvaluationsController : Controller
    {
        private AcademyModel db = new AcademyModel();
        private IEvaluationRepository _evaluationRepository;
        public EvaluationsController()
        {
            this._evaluationRepository = new EvaluationRepository(new AcademyModel());
        }

        // GET: Evaluations
        public ActionResult Index()
        {
            var evaluations = _evaluationRepository.GetEvaluation();
            //var evaluations = db.Evaluations.Include(e => e.Classrooms).Include(e => e.Periods).Include(e => e.Users);
            return View(evaluations.ToList());
        }

        // GET: Evaluations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = _evaluationRepository.GetEvaluationsByID(id);
    
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(_evaluationRepository.GetClassrooms(), "Id", "Title");
            ViewBag.Period_Id = new SelectList(_evaluationRepository.GetPeriods(), "Id", "Id");
            ViewBag.User_Id = new SelectList(_evaluationRepository.GetUsers(), "Id", "UserName");
            return View();
        }

        // POST: Evaluations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                evaluations.Id = Guid.NewGuid();
                _evaluationRepository.InsertEvaluation(evaluations);
                _evaluationRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(_evaluationRepository.GetClassrooms(), "Id", "Title");
            ViewBag.Period_Id = new SelectList(_evaluationRepository.GetPeriods(), "Id", "Id");
            ViewBag.User_Id = new SelectList(_evaluationRepository.GetUsers(), "Id", "UserName");
            return View(evaluations);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Evaluations evaluations = db.Evaluations.Find(id);
            Evaluations evaluations = _evaluationRepository.GetEvaluationsByID(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(_evaluationRepository.GetClassrooms(), "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(_evaluationRepository.GetPeriods(), "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(_evaluationRepository.GetUsers(), "Id", "UserName", evaluations.User_Id);
            return View();
        }

        // POST: Evaluations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                _evaluationRepository.UpdateEvaluation(evaluations);
                _evaluationRepository.Save();
                //db.Entry(evaluations).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(_evaluationRepository.GetClassrooms(), "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(_evaluationRepository.GetPeriods(), "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(_evaluationRepository.GetUsers(), "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Evaluations evaluations = db.Evaluations.Find(id);
            Evaluations evaluations = _evaluationRepository.GetEvaluationsByID(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            _evaluationRepository.DeleteEvaluation(id);
            _evaluationRepository.Save();
            //db.Evaluations.Remove(evaluations);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _evaluationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
