using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface ITutorsRepository : IDisposable
    {
        IEnumerable<Pupils> GetPupil();
        IEnumerable<Levels> GetLevels();
        IEnumerable<Tutors> GetTutors();
        IEnumerable<Classrooms> GetClassroom();
        Tutors GetTutorByID(Guid? TutorId);
        void InsertTutor(Tutors Tutor);
        void DeleteTutor(Guid? Tutor);
        void UpdateTutor(Tutors Tutor);
        void Save();
    }
}
