using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    public class EvaluationRepository : IEvaluationRepository
    {

        private AcademyModel _context;
        public EvaluationRepository(AcademyModel _evaluationContext)
        {
            this._context = _evaluationContext;
        }

        public void DeleteEvaluation(Guid? EvaluationId)
        {
            Evaluations evaluations = _context.Evaluations.Find(EvaluationId);
            _context.Evaluations.Remove(evaluations);
        }

        public Evaluations GetEvaluationsByID(Guid? EvaluationId)
        {
            return _context.Evaluations.Find(EvaluationId);
        }

        public IEnumerable<Evaluations> GetEvaluation()
        {
            return _context.Evaluations.ToList();
        }

        public IEnumerable<Periods> GetPeriods()
        {
            return _context.Periods.ToList();
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void InsertEvaluation(Evaluations Evaluation)
        {
            _context.Evaluations.Add(Evaluation);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEvaluation(Evaluations Evaluation)
        {
            _context.Entry(Evaluation).State = System.Data.Entity.EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IEnumerable<Classrooms> GetClassrooms()
        {
            
                return _context.Classrooms.ToList();
           
        }
    }
}