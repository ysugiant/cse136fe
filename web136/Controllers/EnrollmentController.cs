using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Enrollment;
using web136.Models.Student;
using web136.Models.Schedule;

namespace web136.Controllers
{
  public class EnrollmentController : Controller
  {
    //Show the whole enrollment table
    public ActionResult Index()
    {
        List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();
        ViewBag.breadCrumbData = "Enrollment List";
        return View("List", list);
    }

    //Student can access this function
    public ActionResult Transcript(string stID)
    {
        if (Session["role"] != null && (Session["role"].Equals("student") || Session["role"].Equals("advisor")))
        {
            List<PLEnrollment> list = EnrollmentClientService.GetStudentEnrollmentList(stID);
            ViewBag.breadCrumbData = "Transcript List";
            ViewBag.GPA = GetTotalGPA(list);
            return View("Transcript", list);
        }
        else
            return View("Error");
    }

    public ActionResult StudentSchedule(string stID)
    {
        if (Session["role"] != null && Session["role"].Equals("student"))
        {
            List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();
            List<PLEnrollment> res = new List<PLEnrollment>();
            foreach (PLEnrollment tmp in list)
            {
                if (tmp.studentID.Equals(stID))
                    res.Add(tmp);
            }
            ViewBag.breadCrumbData = "Schedule List";

            return View("StudentSchedule", res);
        }
        else
            return View("Error");
    }

    public ActionResult InstructorSchedule(string instID)
    {
        if (Session["role"] != null && Session["role"].Equals("instructor"))
        {
            List<PLEnrollment> list = EnrollmentClientService.GetInstructorEnrollmentList(instID);
            ViewBag.breadCrumbData = "Schedule List";

            return View("InstructorSchedule", list);
        }
        else
            return View("Error");
    }


      public double GetTotalGPA( List<PLEnrollment> list)
      {
          double totalGrade = 0;
          int totalUnit = 0;

          foreach (PLEnrollment enroll in list)
          {
              totalUnit += enroll.scheduledCourse.course.units;
              switch (enroll.grade)
              {
                  case "APLUS":
                      totalGrade += 4.0;
                      break;
                  case "A":
                      totalGrade += 4.0;
                      break;
                  case "AMINUS":
                      totalGrade += 3.7;
                      break;
                  case "BPLUS":
                      totalGrade += 3.3;
                      break;
                  case "B":
                      totalGrade += 3.0;
                      break;
                  case "BMINUS":
                      totalGrade += 2.7;
                      break;
                  case "CPLUS":
                      totalGrade += 2.3;
                      break;
                  case "C":
                      totalGrade += 2.0;
                      break;
                  case "CMINUS":
                      totalGrade += 1.7;
                      break;
                  case "D":
                      totalGrade += 1.0;
                      break;
              }
          }
          return totalGrade / totalUnit;
      }

    //
    public ActionResult Create(string student_id, string schedule_id)
    {
      try
      {
        //get student id from cache
        EnrollmentClientService.CreateEnrollment(student_id, Convert.ToInt32(schedule_id));
        return RedirectToAction("Index");
      }
      catch (Exception e)
      {
        Console.Write(e.ToString());
        return View();
      }
    }

    //Change grade for instructor
    // GET: /Enrollment/Create
    public ActionResult EditGrades(string schedule_id)
    {
        List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();

        List<PLEnrollment> res = new List<PLEnrollment>();
        foreach (PLEnrollment tmp in list)
        {
            if (tmp.scheduledCourse.schedule_id == Convert.ToInt32(schedule_id))
                res.Add(tmp);
        }

        ViewBag.breadCrumbData = "Change Grade";
        return View("ChangesGrade", res);
    }

    public ActionResult EditGrade(string schID, string stID, string grade)
    {
        List<SelectListItem> list = new List<SelectListItem>();
        list.Add(new SelectListItem{Value ="INPROGRESS", Text = "IN PROGRESS"});
        list.Add(new SelectListItem{Value ="APLUS", Text = "A+"});
        list.Add(new SelectListItem{Value ="A", Text = "A"});
        list.Add(new SelectListItem{Value ="AMINUS", Text = "A-"});
        list.Add(new SelectListItem{Value ="BPLUS", Text = "B+"});
        list.Add(new SelectListItem{Value ="B", Text = "B"});
        list.Add(new SelectListItem{Value ="BMINUS", Text = "B-"});
        list.Add(new SelectListItem{Value ="CPLUS", Text = "C+"});
        list.Add(new SelectListItem{Value ="C", Text = "C"});
        list.Add(new SelectListItem{Value ="CMINUS", Text = "C-"});
        list.Add(new SelectListItem{Value ="D", Text = "D"});
        list.Add(new SelectListItem{Value = "F", Text = "F" });

        ViewBag.stID = stID;
        ViewBag.schID = schID;
        ViewBag.grade = grade;
        ViewBag.list = list;

        ViewBag.breadCrumbData = "Change Grade";
        return View("ChangeGrade");
    }

    //
    // POST: /Enrollment/Edit/
    [HttpPost]
    public ActionResult EditGrade(FormCollection collection)
    {
      try
      {
        EnrollmentClientService.UpdateEnrollment(collection["student_id"], Convert.ToInt32(collection["schedule_id"]), collection["grade"]);
        return RedirectToAction("EditGrades");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Enrollment/Delete/5

    public ActionResult Delete(string stID, string schID)
    {
      try
      {
        bool success = EnrollmentClientService.DeleteEnrollment(stID, Convert.ToInt32(schID));

        if (success)
            return RedirectToAction("StudentSchedule", new { stID = stID });

        return RedirectToAction("Error");
      }
      catch
      {
        return View();
      }
    }

    public ActionResult Error()
    {
      return View("Error");
    }


       // GET: /Schedule/
    public ActionResult Register(string yearFilter, string quarterFilter)
    {
        
      if (yearFilter == null)
        yearFilter = "1950";
        
      if (quarterFilter == null)
        quarterFilter = "";

      if (Session["id"] == null)
          return RedirectToAction("Index", "Login");
      string student_id = Session["id"].ToString();

      ViewBag.student_id = student_id;
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

      return View("Register", scheduleList);
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
