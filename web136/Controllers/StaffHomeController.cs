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
            return View();
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

    }
}
