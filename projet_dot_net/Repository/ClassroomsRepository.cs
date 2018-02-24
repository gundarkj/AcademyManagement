using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    public class ClassroomsRepository : IClassroomsRepository
    {

        private AcademyModel _context;
        public ClassroomsRepository(AcademyModel _classroomContext)
        {
            this._context = _classroomContext;
        }

        public void DeleteClassroom(Guid? ClassroomId)
        {
            Classrooms classroom = _context.Classrooms.Find(ClassroomId);
            _context.Classrooms.Remove(classroom);
        }

        public IEnumerable<Classrooms> GetClassroom()
        {
            return _context.Classrooms.ToList();
        }

        public Classrooms GetClassroomByID(Guid? ClassroomId)
        {
            return _context.Classrooms.Find(ClassroomId);
        }

        public void InsertClassroom(Classrooms Classroom)
        {
            _context.Classrooms.Add(Classroom);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateClassroom(Classrooms Classroom)
        {
            _context.Entry(Classroom).State = System.Data.Entity.EntityState.Modified;
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

        public IEnumerable<Establishments> GetEstablishments()
        {
            return _context.Establishments.ToList();
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<Years> GetYears()
        {
            return _context.Years.ToList();
        }
    }
}