using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_dot_net.Model;
using projet_dot_net.Repository;

namespace projet_dot_net.Repository
{
    public class AcademyRepository : IAcademyRepository
    {
        private AcademyModel _context;

        public AcademyRepository(AcademyModel _academyContext)
        {
            this._context = _academyContext;
        }

        public void DeleteAcademy(Guid? AcademyId)
        {
            Academies Academy = _context.Academies.Find(AcademyId);
            _context.Academies.Remove(Academy);
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
        public IEnumerable<Academies> GetAcademy()
        {
            return _context.Academies.ToList();
        }

        public Academies GetAcademyByID(Guid? AcademyId)
        {
            return _context.Academies.Find(AcademyId);
        }

        public void InsertAcademy(Academies Academy)
        {
            _context.Academies.Add(Academy);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAcademy(Academies Academy)
        {
            _context.Entry(Academy).State = System.Data.Entity.EntityState.Modified;
        }

       
    }
}