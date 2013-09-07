using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Schedule;
using web136.Models.Student;

namespace web136.Controllers
{
  public class ScheduledCourseController : Controller
  {

      //
      // CREATE: /Schedule/Create/
      public ActionResult Create()
      {
          if (HttpContext != null)
          {
              UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
              ViewBag.breadCrumbData = "<a href='" + url.Action("Create", "Schedule") + "'>Create Schedule</a>";
              ViewBag.breadCrumbData += " > Create";
          }
          PLScheduledCourse sched = new PLScheduledCourse();
          return View("Create", sched);
      }

      //
      // POST: /Schedule/Create
      [HttpPost]
      public ActionResult Create(FormCollection collection)
      {
          try
          {
              PLScheduledCourse sched = new PLScheduledCourse();
              sched.schedule_id = Convert.ToInt32(collection["schedule_id"]);
              sched.year = Convert.ToInt32(collection["year"]);
              sched.quarter = collection["quarter"];
              sched.session = collection["session"];
              sched.course = new Models.Course.PLCourse();
              sched.course.id = Convert.ToInt32(collection["course_id"]);
              sched.course.description = collection["course_description"];
              sched.course.title = collection["course_title"];
              sched.course.courseLevel = collection["course_level"];
              sched.course.units = Convert.ToInt32(collection["units"]);
              sched.timeID = Convert.ToInt32(collection["timeID"]);
              sched.dayID = Convert.ToInt32(collection["dayID"]);
              sched.time = collection["time"];
              sched.day = collection["day"];
              sched.instructorID = Convert.ToInt32(collection["instructorID"]);
              sched.firstName = collection["firstName"];
              sched.lastName = collection["lastName"];
              ScheduleClientService.InsertScheduledCourse(sched);
              return RedirectToAction("Create");
          }
          catch (Exception e)
          {
              Console.Write(e.ToString());
              return View();
          }
      }

      //
      // GET: /Schedule/Edit/
      public ActionResult Edit()
      {
          if (HttpContext != null)
          {
              UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
              ViewBag.breadCrumbData = "<a href='" + url.Action("Edit", "Schedule") + "'>Edit Schedule</a>";
              ViewBag.breadCrumbData += " > Edit";
          }
          PLScheduledCourse sched = new PLScheduledCourse();
          return View("Edit", sched);
      }

      //
      // POST: /Schedule/Edit/
      [HttpPost]
      public ActionResult Edit(FormCollection collection)
      {
          try
          {
              PLScheduledCourse sched = new PLScheduledCourse();
              sched.schedule_id = Convert.ToInt32(collection["schedule_id"]);
              sched.year = Convert.ToInt32(collection["year"]);
              sched.quarter = collection["quarter"];
              sched.session = collection["session"];
              sched.course = new Models.Course.PLCourse();
              sched.course.id = Convert.ToInt32(collection["course_id"]);
              sched.course.description = collection["course_description"];
              sched.course.title = collection["course_title"];
              sched.course.courseLevel = collection["course_level"];
              sched.course.units = Convert.ToInt32(collection["units"]);
              sched.timeID = Convert.ToInt32(collection["timeID"]);
              sched.dayID = Convert.ToInt32(collection["dayID"]);
              sched.time = collection["time"];
              sched.day = collection["day"];
              sched.instructorID = Convert.ToInt32(collection["instructorID"]);
              sched.firstName = collection["firstName"];
              sched.lastName = collection["lastName"];

              ScheduleClientService.UpdateScheduledCourse(sched);
              return RedirectToAction("Edit");
          }
          catch
          {
              return View();
          }
      }

      //
      // GET: /Schedule/Get/
      public ActionResult Get()
      {
          if (HttpContext != null)
          {
              UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
              ViewBag.breadCrumbData = "<a href='" + url.Action("Get", "Schedule") + "'>Get Schedule</a>";
              ViewBag.breadCrumbData += " > Get";
          }
          PLScheduledCourse major = new PLScheduledCourse();
          return View("Get", major);
      }

      //
      // GET: /Schedule/Delete/
      public ActionResult Delete()
      {
          if (HttpContext != null)
          {
              UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
              ViewBag.breadCrumbData = "<a href='" + url.Action("Delete", "Schedule") + "'>Delete Schedule</a>";
              ViewBag.breadCrumbData += " > Delete";
          }
          PLScheduledCourse sched = new PLScheduledCourse();
          return View("Delete", sched);
      }

      //
      // POST: /Schedule/Delete/
      [HttpPost]
      public ActionResult Delete(FormCollection collection)
      {
          try
          {
              int sched_id = Convert.ToInt32(collection["schedule_id"]);
              bool success = ScheduleClientService.DeleteScheduledCourse(sched_id);

              if (success)
                  return RedirectToAction("Delete");

              return RedirectToAction("Error");
          }
          catch
          {
              return View();
          }
      }

      /*

    public ActionResult Filter(string yearFilter, string quarterFilter)
    {
      if (yearFilter == null)
        yearFilter = "";

      if (quarterFilter == null)
        quarterFilter = "";

      string student_id = Session["id"].ToString();

      PLStudent student = StudentClientService.GetStudentDetail(student_id);
      ViewBag.student = student;

      List<PLScheduledCourse> scheduleList = ScheduleClientService.GetScheduleList(Convert.ToInt32(yearFilter), quarterFilter);

      return Json(scheduleList);
    }*/

      //
      // AJAX: for /Schedule/Create
      public JsonResult GetSampleSchedule(int idx)
      {
          List<string> errors = new List<string>();
          List<PLScheduledCourse> list = ScheduleClientService.GetScheduleListComplete();
          /*System.Diagnostics.Debug.WriteLine("List Count:" + list.Count);
          System.Diagnostics.Debug.WriteLine("MajorID:" + list[idx].major_id);
          System.Diagnostics.Debug.WriteLine("MajorName:" + list[idx].major_name);
          System.Diagnostics.Debug.WriteLine("DeptID:" + list[idx].dept_id);*/
          for (int i = 0; i < list.Count; i++)
          {
              if (list[i].schedule_id == idx)
                  return this.Json(list[i], JsonRequestBehavior.AllowGet);
          }
          errors.Add("schedule id not found");
          return this.Json(errors);
      }

      public ActionResult Error()
      {
          return View("Error");
      }












    //
    // GET: /Schedule/
    public ActionResult Index(string yearFilter, string quarterFilter)
    {
        
      if (yearFilter == null)
        yearFilter = "1950";
        
      if (quarterFilter == null)
        quarterFilter = "";

      string student_id = Session["id"].ToString();

      PLStudent student = StudentClientService.GetStudentDetail(student_id);
      ViewBag.student = student;
      int tmpYear = Convert.ToInt32(yearFilter);

      List<PLScheduledCourse> scheduleList = ScheduleClientService.GetScheduleList(tmpYear, quarterFilter);

      int year = DateTime.Now.Year;
      int previousYear = year - 1;
      int nextYear = year + 1;

      // only display the current year, previous year, and next year as selections
      List<SelectListItem> YearList = new List<SelectListItem>();
      YearList.Add(new SelectListItem { Text = "All Years", Value = "" });
      YearList.Add(new SelectListItem { Text = previousYear.ToString(), Value = previousYear.ToString() });
      YearList.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString() });
      YearList.Add(new SelectListItem { Text = nextYear.ToString(), Value = nextYear.ToString() });

      // these usually comes from the database... 
      List<SelectListItem> QuarterList = new List<SelectListItem>();
      QuarterList.Add(new SelectListItem { Text = "All Quarters", Value = "" });
      QuarterList.Add(new SelectListItem { Text = "Fall", Value = "Fall" });
      QuarterList.Add(new SelectListItem { Text = "Winter", Value = "Winter" });
      QuarterList.Add(new SelectListItem { Text = "Spring", Value = "Spring" });
      QuarterList.Add(new SelectListItem { Text = "Summer 1", Value = "Summer 1" });
      QuarterList.Add(new SelectListItem { Text = "Summer 2", Value = "Summer 2" });

      ViewBag.YearList = YearList;
      ViewBag.QuarterList = QuarterList;

      return View("Index", scheduleList);
    }

    public ActionResult Filter(string yearFilter, string quarterFilter)
    {
      if (yearFilter == null)
        yearFilter = "";

      if (quarterFilter == null)
        quarterFilter = "";

      string student_id = Session["id"].ToString();

      PLStudent student = StudentClientService.GetStudentDetail(student_id);
      ViewBag.student = student;

      List<PLScheduledCourse> scheduleList = ScheduleClientService.GetScheduleList(Convert.ToInt32(yearFilter), quarterFilter);

      return Json(scheduleList);
    }

  }
}
