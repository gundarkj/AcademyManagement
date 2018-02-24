using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_dot_net.Model;

namespace projet_dot_net.Repository
{
    interface IEvaluationRepository : IDisposable
    {
        IEnumerable<Classrooms> GetClassrooms();
        IEnumerable<Periods> GetPeriods();
        IEnumerable<Users> GetUsers();
        IEnumerable<Evaluations> GetEvaluation();
        Evaluations GetEvaluationsByID(Guid? EvaluationId);
        void InsertEvaluation(Evaluations Evaluation);
        void DeleteEvaluation(Guid? EvaluationId);
        void UpdateEvaluation(Evaluations Evaluation);
        void Save();
    }
}
