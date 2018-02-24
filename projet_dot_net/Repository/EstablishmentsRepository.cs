using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    public class EstablishmentsRepository : IEstablishmentsRepository
    {

        private AcademyModel _context;
        public EstablishmentsRepository(AcademyModel _establishmentContext)
        {
            this._context = _establishmentContext;
        }
        public void DeleteEstablishment(Guid? EstablishmentId)
        {
            Establishments establishments = _context.Establishments.Find(EstablishmentId);
            _context.Establishments.Remove(establishments);
        }

        public IEnumerable<Academies> GetAcademies()
        {
            return _context.Academies.ToList();
        }

        public Establishments GetEstablishmentByID(Guid? EstablishmentId)
        {
            return _context.Establishments.Find(EstablishmentId);
        }

        public IEnumerable<Establishments> GetEstablishments()
        {
            return _context.Establishments.ToList();
        }

        public IEnumerable<Users> GetUsers()
        {
           return _context.Users.ToList();
        }

        public void InsertEstablishment(Establishments Establishment)
        {
            _context.Establishments.Add(Establishment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEstablishment(Establishments Establishment)
        {
            _context.Entry(Establishment).State = System.Data.Entity.EntityState.Modified;
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