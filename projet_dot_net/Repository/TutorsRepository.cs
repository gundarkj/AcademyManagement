using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    public class TutorsRepository : ITutorsRepository
    {

        private AcademyModel _context;
        public TutorsRepository(AcademyModel _tutorContext)
        {
            this._context = _tutorContext;
        }
        public void DeleteTutor(Guid? TutorId)
        {
            Tutors tutor = _context.Tutors.Find(TutorId);
            _context.Tutors.Remove(tutor);
        }

        

        public IEnumerable<Classrooms> GetClassroom()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Levels> GetLevels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pupils> GetPupil()
        {
            return _context.Pupils.ToList();
        }

        public Tutors GetTutorByID(Guid? TutorId)
        {
            return _context.Tutors.Find(TutorId);
        }

        public IEnumerable<Tutors> GetTutors()
        {
            return _context.Tutors.ToList();
        }

        public void InsertTutor(Tutors Tutor)
        {
            _context.Tutors.Add(Tutor);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTutor(Tutors Tutor)
        {
            _context.Entry(Tutor).State = System.Data.Entity.EntityState.Modified;
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
    }
}