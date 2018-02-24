using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    public class PupilsRepository : IPupilsRepository
    {
        private AcademyModel _context;
        public PupilsRepository(AcademyModel _pupilsContext)
        {
            this._context = _pupilsContext;
        }
        
        public void DeletePupil(Guid? PupilId)
        {
            Pupils pupil = _context.Pupils.Find(PupilId);
            _context.Pupils.Remove(pupil);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pupils> GetPupil()
        {
            return _context.Pupils.ToList();
        }

        public IEnumerable<Classrooms> GetClassroom()
        {
            return _context.Classrooms.ToList();
        }

        public IEnumerable<Tutors> GetTutors()
        {
            return _context.Tutors.ToList();
        }

        public IEnumerable<Levels> GetLevels()
        {
            return _context.Levels.ToList();
        }

        public Pupils GetPupilByID(Guid? PupilId)
        {
            return _context.Pupils.Find(PupilId);
        }

        public void InsertPupil(Pupils Pupil)
        {
            _context.Pupils.Add(Pupil);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePupil(Pupils Pupil)
        {
            _context.Entry(Pupil).State = System.Data.Entity.EntityState.Modified;

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