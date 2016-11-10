using Physio.DAL;
using PhysioQA.DataAccess;
using PhysioQA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysioQA.Controllers
{
    public class QuestionController : Controller
    {
        static readonly IQuestionRepository repository = new QuestionRepository();

        //P@ssword1

        // GET: 
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TakeQuestionnaire(int patientId)
        {
            int questionnaireId = repository.CreateQuestionnaire(patientId, 1);

            var questSet = repository.GetPatientQuestionnaire(patientId, questionnaireId);
           
            
            if (questSet == null)
            {
                //log
            }

            return Json(new { questSet = questSet }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult SaveAnswer(int questionId, int answer)
        public JsonResult SaveAnswer(QuestionnaireModel item)
        {
            int id = repository.SaveAnswer(item.PatientQuestionnaireId, item.QuestionId, item.Answer);

            return Json(new { result = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Questionnaire()
        {
            return View();
        }

        public ActionResult DoQuestionnaire()
        {
            return View();
        }

        public ActionResult UnderConstruction()
        {
            return View();
        }

    }
}