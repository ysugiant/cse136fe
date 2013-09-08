using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Schedule;

namespace web136.Controllers
{
    public class StaffHomeController : Controller
    {
        //
        // GET: /StaffHome/

        public ActionResult Index()
        {
            if (Session["role"] != null)
            {
                if (Session["role"].Equals("instructor") || Session["role"].Equals("advisor") || Session["role"].Equals("staff"))
                    return View();
            }
            return View("Error");
        }

        public ActionResult ClassList(int instID)
        {
            List<PLScheduledCourse> list = ScheduleClientService.GetScheduleList(2012, "FALL");
            List<PLScheduledCourse> res = new List<PLScheduledCourse>();
            if (list != null)
            {
                foreach (PLScheduledCourse tmp in list)
                {
                    if (instID == tmp.instructorID)
                        res.Add(tmp);
                }
            }
            return View("ClassList", res);
        }

        //View
        public ActionResult Student()
        {
            return RedirectToAction("Index", "Student");
        }

        public ActionResult ScheduleDay()
        {
            return RedirectToAction("Index", "ScheduleDay");
        }

        public ActionResult ScheduleTime()
        {
            return RedirectToAction("Index", "ScheduleTime");
        }

        public ActionResult Staff()
        {
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult Course()
        {
            return RedirectToAction("Index", "Course");
        }

        public ActionResult Major()
        {
            return RedirectToAction("Index", "Major");
        }

        public ActionResult Schedule()
        {
            return RedirectToAction("Index", "ScheduledCourse");
        }

        public ActionResult Enrollment()
        {
            return RedirectToAction("Index", "Enrollment");
        }

        public ActionResult Department()
        {
            return RedirectToAction("Index", "Department");
        }
        
    }
}
