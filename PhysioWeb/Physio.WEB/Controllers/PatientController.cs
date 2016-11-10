using Newtonsoft.Json.Linq;
using PhysioQA.DataAccess;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mtosh.Common;
using Newtonsoft.Json;
using PhysioQA.Models;
using System.Data;

namespace PhysioQA.Controllers
{
    public class PatientController : Controller
    {
        static readonly IQuestionRepository repository = new QuestionRepository();

        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PatientChart()
        {
            //todo:
            //get patient id from login context

            //hardcode to 1 for now.
            return View();
        }

        public JsonResult GetPatientChartData(int patientId = 0, int questionnaireId = 0)
        {

            //var line_data = [{ date: '2016-02-05', Pain: 10, Work: 2, Family: 4 },
            //        { date: '2016-02-12', Pain: 8, Work: 5, Family: 4 },
            //        { date: '2016-02-18', Pain: 7, Work: 3, Family: 2 },
            //        { date: '2016-03-05', Pain: 5, Work: 6, Family: 7 },
            //        { date: '2016-04-05', Pain: 4, Work: 6, Family: 7 },
            //        { date: '2016-04-12', Pain: 2, Work: 8, Family: 9 }];

            if(patientId == 0)
            {
                patientId = 1;
            }
            if (questionnaireId == 0)
            {
                questionnaireId = 1;
            }

            try
            {
                var chartData = repository.GetPatientChartData(patientId, questionnaireId).ToList();


               // List<ChartModel> chartList = new List<ChartModel>();
                


                //var dynamicColumns = chartData.GroupBy(s => s.QuestionAbbreviation).ToList();

                //List<string> dc = dynamicColumns.Select(s => s.Key).ToList();

                ////dynamic eo = new ExpandoObject(); 
                ////var row = (IDictionary<string, string>)eo;
              
                //List<Dictionary<string, object>> rows;
                //List<object> newrows = new List<object>();
                //Dictionary<string, object> row;
                //List<object> newrow;
                //object newcol;
                ////KeyValuePair<string, string> col;

                ////rows = new List<Dictionary<string, object>>();

                
                ////number of questionnaires answered
                //var questionnaireList = chartData.GroupBy(s => s.PatientQuestionnaireId).ToList();
                //foreach (var q in questionnaireList)
                //{
                //    ChartModel chartItem = new ChartModel();
                //    chartItem.Date = q.FirstOrDefault().QuestionnaireDate.ToString("yyyy-MM-dd");

                //    int ans = 0;
                //    var oAns = q.Where(s => s.QuestionAbbreviation == "Pain" && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
                //    if (oAns != null && !oAns.Answer.NullOrEmpty())
                //    {
                //        ans = Convert.ToInt32(oAns.Answer);
                //    }
                //    chartItem.Pain = ans;

                //    ans = 0;
                //    oAns = q.Where(s => s.QuestionAbbreviation == "Work" && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
                //    if (oAns != null && !oAns.Answer.NullOrEmpty())
                //    {
                //        ans = Convert.ToInt32(oAns.Answer);
                //    }
                //    chartItem.Work = ans;

                //    ans = 0;
                //    oAns = q.Where(s => s.QuestionAbbreviation == "Family" && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
                //    if (oAns != null && !oAns.Answer.NullOrEmpty())
                //    {
                //        ans = Convert.ToInt32(oAns.Answer);
                //    }
                //    chartItem.Family = ans;

                //    chartList.Add(chartItem);


                //var dynamicColumns = chartData.GroupBy(s => s.QuestionAbbreviation).ToList();

                //PropertyBagList list = new PropertyBagList();
                //list.Columns.Add("Date");

                //foreach (var c in dynamicColumns)
                //{
                //    list.Columns.Add(c.Key);
                //}



                //var questionnaireList = chartData.GroupBy(s => s.PatientQuestionnaireId).ToList();
                //foreach (var q in questionnaireList)
                //{
                //    List<string> colValues = new List<string>();
                //    colValues.Add(q.FirstOrDefault().QuestionnaireDate.ToString("yyyy-MM-dd"));
                //    foreach (var c in dynamicColumns)
                //    {
                //        //int ans = 0;
                //        string ans = "0";
                //        var oAns = q.Where(s => s.QuestionAbbreviation == c.Key && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
                //        if (oAns != null && !oAns.Answer.NullOrEmpty())
                //        {
                //            //ans = Convert.ToInt32(oAns.Answer);
                //            ans = oAns.Answer;
                //        }
                //        colValues.Add(ans);
                //    }

                //    list.Add(colValues.ToArray());

                //}

                List<string> list = new List<string>();
                Dictionary<string, object> row = new Dictionary<string, object>();
                var dynamicColumns = chartData.GroupBy(s => s.QuestionAbbreviation).ToList();
                var questionnaireList = chartData.GroupBy(s => s.PatientQuestionnaireId).ToList();

                foreach (var q in questionnaireList)
                {
                    Dictionary<string, object> rowItem = new Dictionary<string, object>();
                    rowItem.Add("Date", q.FirstOrDefault().QuestionnaireDate.ToString("yyyy-MM-dd"));

                    foreach (var c in dynamicColumns)
                    {
                        int ans = 0;
                        //string ans = "0";
                        var oAns = q.Where(s => s.QuestionAbbreviation == c.Key && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
                        if (oAns != null && !oAns.Answer.NullOrEmpty())
                        {
                            ans = Convert.ToInt32(oAns.Answer);
                            //ans = oAns.Answer;
                        }
                        rowItem.Add(c.Key, ans);
                    }

                    string jsonRow = JsonConvert.SerializeObject(rowItem);
                    list.Add(jsonRow);

                }


          

                return Json(new { list }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {

                string d = e.Message;
            }

            return null;

        }

    }
}

//    row = new Dictionary<string, object>();
//    //newrow = new List<object>();

//    //string dateVal = q.Where(s => s.QuestionnaireDate == q.Key && q.Key == s.PatientQuestionnaireId).First().Answer;
//   // KeyValuePair<string, object> col = new KeyValuePair<string,object>("Date", q.FirstOrDefault().QuestionnaireDate.ToString("yyyy-MM-dd"));
//    row.Add("Date", q.FirstOrDefault().QuestionnaireDate.ToString("yyyy-MM-dd"));
//    //row.Add(col);
//    //newcol = JsonConvert.SerializeObject(col);
//    //newrow.Add(newcol);

//    foreach (var c in dc)
//    {
//        int ans = 0;
//        var oAns = q.Where(s => s.QuestionAbbreviation == c && q.Key == s.PatientQuestionnaireId).FirstOrDefault();
//        if (oAns != null && !oAns.Answer.NullOrEmpty())
//        {
//            ans = Convert.ToInt32(oAns.Answer);
//        }
//        row.Add(c, ans);

//        //col = new KeyValuePair<string,object>(c, ans);
//        //newcol = JsonConvert.SerializeObject(col);
//        //newrow.Add(newcol);
//    }

//    //rows.Add(row);

//    string json = JsonConvert.SerializeObject(row);
//    //object o = JsonConvert.DeserializeObject<object>(json);

//    newrows.Add(json);
//}


//string json = JsonConvert.SerializeObject(rows);

//string jsonOld = json;

//dc.Add("Date");

//foreach (var col in dc)
//{ 
//    string search = string.Format("\"{0}\"", col);
//    json = json.Replace(search, col);
//}