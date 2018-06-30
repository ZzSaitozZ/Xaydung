using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xaydung.ViewModel;

namespace Xaydung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DuAn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getDuAn(int? page)
        {
            XaydungDAL XdDal = new XaydungDAL();
            CProjectVM projectsVM = new CProjectVM();
            var b = XdDal.Database.SqlQuery<int>("select count(*) from dbo.AddingNos").FirstOrDefault();
            projectsVM.pageSize = 15;
            if (b > 0)
            {
                projectsVM.pageCount = (int)Math.Ceiling((double)b / projectsVM.pageSize);
                if (page == null || page > projectsVM.pageCount || page < 1) page = 1;
            }
            else { projectsVM.pageCount = 0; page = 0; }
            projectsVM.pageNumber = (int)page;
            string command = "Select ID,Name,Place,Year,Status,Description,Image from dbo.AddingNos Where NO >" + (page - 1) * projectsVM.pageSize + "and NO <=" + page * projectsVM.pageSize;
            projectsVM.projects = XdDal.CProjects.SqlQuery(command).ToList();
            return Json(projectsVM, JsonRequestBehavior.AllowGet);
        }
    }
}