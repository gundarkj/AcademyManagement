using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface IClassroomsRepository : IDisposable
    {

   
        IEnumerable<Classrooms> GetClassroom();
        IEnumerable<Establishments> GetEstablishments();
        IEnumerable<Users> GetUsers();
        IEnumerable<Years> GetYears();
        Classrooms GetClassroomByID(Guid? ClassroomId);
        void InsertClassroom(Classrooms Classroom);
        void DeleteClassroom(Guid? ClassroomId);
        void UpdateClassroom(Classrooms Classroom);
        void Save();
    }
}
