using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MUSE.BLL;
using MUSE.Model;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MUSE.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/

        public ActionResult List()
        {
            return View();
        }



        public JsonResult CourseList(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            List<Course> list = new CourseManager().GetModelList(keyword);
            Dictionary<string, object> json = ReturnJson(list);
            //System.Diagnostics.Debug.WriteLine(json);
            return Json(json, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult List(string keyword)
        {
            //string str = "";
            //List<Course> list = new CourseManager().GetModelList(str);
            //List<Course> list = new CourseManager().GetModelList(keyword);
            //Dictionary<string, object> json = ReturnJson(list);
            //return Json(json, JsonRequestBehavior.AllowGet);
            ViewBag.keyword = keyword;
            return View();

        }

        //[HttpPost]
        //public JsonResult CourseList()
        //{
        //    string str = "";
        //    List<Course> list = new CourseManager().GetModelList(str);
        //    Dictionary<string, object> json = new Dictionary<string, object>();
        //    json.Add("code", 0);
        //    json.Add("msg", "");
        //    json.Add("count", 30);
        //    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
        //    foreach (Course course in list)
        //    {
        //        Dictionary<string, object> dic = new Dictionary<string, object>();
        //        dic.Add("id", course._courseCode);
        //        dic.Add("name", course._Course);
        //        dic.Add("credit", course.CourseCredit);
        //        dic.Add("period", course._coursePeriod);
        //        dic.Add("type", course._courseType);
        //        dic.Add("college", course._academy);
        //        dic.Add("starttime", course._courseBeginTime);
        //        data.Add(dic);
        //    }
        //    json.Add("data", data);
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}

        [NonAction]
        public Dictionary<string, object> ReturnJson(List<Course> Courselist)
        {
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("code", 0);
            json.Add("msg", "");
            json.Add("count", 30);
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (Course course in Courselist)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("id", course._courseCode);
                dic.Add("name", course._Course);
                dic.Add("credit", course.CourseCredit);
                dic.Add("period", course._coursePeriod);
                dic.Add("type", course._courseType);
                dic.Add("college", course._academy);
                dic.Add("starttime", course._courseBeginTime);
                data.Add(dic);
            }
            json.Add("data", data);
            return json;
        }


        public ActionResult Detail(int? id)
        {
            //如果id为空则默认id为4969
            int courseId = id ?? 1;
            //调用根据图书id查询图书的方法
            Course book = new CourseManager().GetModel(courseId);
            //讲图书对象添加到view中
            return View(book);
        }

    }
}
