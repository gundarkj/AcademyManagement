using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface IAcademyRepository : IDisposable
    {
        IEnumerable<Academies> GetAcademy();
        Academies GetAcademyByID(Guid? AcademyId);
        void InsertAcademy(Academies Academy);
        void DeleteAcademy(Guid? Academy);
        void UpdateAcademy(Academies Academy);
        void Save();
    }
}
