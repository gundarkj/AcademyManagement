using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface IEstablishmentsRepository : IDisposable
    {
        IEnumerable<Academies> GetAcademies();
        IEnumerable<Establishments> GetEstablishments();
        IEnumerable<Users> GetUsers();
        Establishments GetEstablishmentByID(Guid? EstablishmentId);
        void InsertEstablishment(Establishments Establishment);
        void DeleteEstablishment(Guid? EstablishmentId);
        void UpdateEstablishment(Establishments Establishment);
        void Save();
    }
}
