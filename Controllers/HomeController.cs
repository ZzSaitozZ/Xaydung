using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xaydung.ViewModel;


namespace Xaydung.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            XaydungEntities XdDal = new XaydungEntities();
            CProjectVM projectsVM = new CProjectVM();
            string command = "Select top 8 * from CProject order by Year desc";
            projectsVM.projects = XdDal.Database.SqlQuery<CProject>(command).ToList();
            string append1 = "", append2 = "";
            for(int i = 0; i <= 3; i++)
            {
                append1 +=
                   " <div class=\"col-sm-3 bl-listing\" style=\"text-align:center\">" +
                           "<div class=\"col-item\">" +
                              " <div class=\"blocks\">" +
                                   "<img class=\"rounded-circle\" itemprop=\"image\" src=\"" + projectsVM.projects[i].Image + "\" alt=\"Trung tâm thương mại\" onerror=\"this.src='/assets/images/listing-no-image.png'\">" +
                                   "<div class=\"block-info\">" +
                                       "<h3 itemprop = \"name\" class=\"module line-clamp\">" + projectsVM.projects[i].Name + "</h3>" +
                                   "</div>" +
                               "</div>" +
                           "</div>" +
                       "</div>";
            }
            for (int i = 4; i <= 7; i++)
            {
                append2 +=
                   " <div class=\"col-sm-3 bl-listing\" style=\"text-align:center\">" +
                           "<div class=\"col-item\">" +
                              " <div class=\"blocks\">" +
                                   "<img class=\"rounded-circle\" itemprop=\"image\" src=\"" + projectsVM.projects[i].Image + "\" alt=\"Trung tâm thương mại\" onerror=\"this.src='/assets/images/listing-no-image.png'\">" +
                                   "<div class=\"block-info\">" +
                                       "<h3 itemprop = \"name\" class=\"module line-clamp\">" + projectsVM.projects[i].Name + "</h3>" +
                                   "</div>" +
                               "</div>" +
                           "</div>" +
                       "</div>";
            }
            ViewBag.append1 = append1;
            ViewBag.append2 = append2;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()        {
            
            return View();
            
        }

        public ActionResult DuAn()
        {
            return View();
        }

        public ActionResult Xulynuoccap()
        {
            return View();
        }

        public ActionResult Tintuc()
        {
            return View();
        }
        public ActionResult Xulynuocthai()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getDuAn(int? page)
        {
            XaydungEntities XdDal = new XaydungEntities();
            CProjectVM projectsVM = new CProjectVM();
            var b = XdDal.Database.SqlQuery<int>("select count(*) from dbo.AddingNos").FirstOrDefault();
            projectsVM.pageSize = 9;
            if (b > 0)
            {
                projectsVM.pageCount = (int)Math.Ceiling((double)b / projectsVM.pageSize);
                if (page == null || page > projectsVM.pageCount || page < 1) page = 1;
            }
            else { projectsVM.pageCount = 0; page = 0; }
            projectsVM.pageNumber = (int)page;
            string command = "Select ID,Name,Place,Year,Status,Description,Image from dbo.AddingNos Where NO >" + (page - 1) * projectsVM.pageSize + "and NO <=" + page * projectsVM.pageSize;
            projectsVM.projects = XdDal.CProjects.SqlQuery(command).ToList();
            projectsVM.numberOfItems = projectsVM.projects.Count();
            return Json(projectsVM, JsonRequestBehavior.AllowGet);
        }

        
    }
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = RouteData.Values["lang"] as string;
                 if (lang != "en") lang = "vi";
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            base.OnActionExecuting(filterContext);
        }
        
    }
}