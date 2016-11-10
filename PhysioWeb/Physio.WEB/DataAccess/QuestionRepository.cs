using Physio.DAL;
using PhysioQA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioQA.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {        
         //public bool SaveAnswer(QuestionItem item)
        public int SaveAnswer(int questionnaireId, int questionId, string answer)
        {
            using (PhysioWebEntities db = new PhysioWebEntities())
            {
                var itemToSave = db.PatientAnswers.Where(s => s.QuestionId == questionId && s.QuestionnaireId == questionnaireId).FirstOrDefault();

                if(itemToSave == null)
                {
                    var patientId = db.PatientQuestionnaires.Where(s => s.Id == questionnaireId).First().PatientId;

                    itemToSave = new PatientAnswer
                    {
                        PatientId = patientId,
                        QuestionnaireId = questionnaireId,
                        QuestionId = questionId
                    };
                    db.PatientAnswers.Add(itemToSave);
                }

                itemToSave.Answer = answer;

                db.SaveChanges();

                return itemToSave.Id;
            }
        }

        public List<QuestionnaireModel> GetPatientQuestionnaire(int patientId, int questionnaireId)
        {
            using (PhysioWebEntities db = new PhysioWebEntities())
            {
                return db.vwPatientQuestionnaires.Where(s => s.PatientId == patientId && s.PatientQuestionnaireId == questionnaireId).Select(s => new QuestionnaireModel
                {
                    PatientId = s.PatientId,
                    PatientName = s.PatientName,
                    PatientQuestionnaireId = s.PatientQuestionnaireId,
                    QuestionSetName = s.QuestionSetName,
                    QuestionId = s.QuestionId,
                    QuestionnaireDate = s.QuestionnaireDate,
                    QuestionText = s.QuestionTitle,
                    QuestionAbbreviation = s.QuestionAbbreviation,
                    QuestionHint = s.QuestionHint,
                    UIcaption = s.UIcaption,
                    Answer = s.Answer
                }).ToList();
            }
        }


        public int CreateQuestionnaire(int patientId, int questionSetId)
        {
            using (PhysioWebEntities db = new PhysioWebEntities())
            {
                PatientQuestionnaire pq = new PatientQuestionnaire
                {
                    PatientId = patientId,
                    QuestionSetId = questionSetId,
                    QuestionnaireDate = DateTime.Now
                };

                db.PatientQuestionnaires.Add(pq);

                db.SaveChanges();

                return pq.Id;
            }

        }

        public List<QuestionSetModel> GetQuestionSets()
        {
            using (PhysioWebEntities db = new PhysioWebEntities())
            {
                return db.QuestionSets.Select(s => new QuestionSetModel
                    {
                        Id = s.Id,
                        QuestionSetName = s.QuestionSetName
                    }).ToList();
            }
        }

        public List<PatientChartModel> GetPatientChartData(int patientId, int questionnaireId)
        {
            using (PhysioWebEntities db = new PhysioWebEntities())
            {
                var chartData = db.vwPatientChartDatas
                    .Where(w => w.PatientId == patientId)  // && w.PatientQuestionnaireId == questionnaireId
                    .Select(s => new PatientChartModel
                    {
                        QuestionId = s.QuestionId,
                        QuestionAbbreviation = s.QuestionAbbreviation,
                        Answer = s.Answer,
                        QuestionnaireDate = s.QuestionnaireDate,
                        PatientQuestionnaireId = s.PatientQuestionnaireId
                    }).ToList();

                return chartData;
            }

        }


    }
}