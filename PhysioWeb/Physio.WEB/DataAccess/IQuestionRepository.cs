using PhysioQA.Models;
using System.Collections.Generic;

namespace PhysioQA.DataAccess
{
    interface IQuestionRepository
    {
       // QuestionModel GetQuestionItem();

        int SaveAnswer(int questionnaireId, int questionId, string answer);

        List<QuestionnaireModel> GetPatientQuestionnaire(int patientId, int questionnaireId);

        int CreateQuestionnaire(int patientId, int questionSetId);

        List<QuestionSetModel> GetQuestionSets();

        List<PatientChartModel> GetPatientChartData(int patientId, int questionnaireId);
    }
}
