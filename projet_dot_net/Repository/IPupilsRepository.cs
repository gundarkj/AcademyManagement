using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface IPupilsRepository : IDisposable
    {
        IEnumerable<Pupils> GetPupil();
        IEnumerable<Levels> GetLevels();
        IEnumerable<Tutors> GetTutors();
        IEnumerable<Classrooms> GetClassroom();
        Pupils GetPupilByID(Guid? APupilId);
        void InsertPupil(Pupils Pupil);
        void DeletePupil(Guid? Pupil);
        void UpdatePupil(Pupils Pupil);
        void Save();

    }
}
