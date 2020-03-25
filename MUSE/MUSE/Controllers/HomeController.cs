using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MUSE.Model;
using MUSE.BLL;

namespace MUSE.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            String str = "";
            List<Course> list = new CourseManager().GetModelList(str);
            return View(list);
        }

    }
}
