using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Enrollment;

namespace web136.Controllers
{
  public class EnrollmentController : Controller
  {
    /*public string GetNumEnrollmentsTotal()
    {
      List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();
      return list.Count.ToString();
    }

    public JsonResult GetSampleEnrollment(int idx)
    {
      List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();

      return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }
*/

    public ActionResult Index()
    {
        List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList();
        ViewBag.breadCrumbData = "Enrollment List";
        return View("List", list);
    }

    public ActionResult Transcript(string stID)
    {
        if (Session["role"] != null && Session["role"].Equals("student"))
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
            List<PLEnrollment> list = EnrollmentClientService.GetStudentEnrollmentList(stID);
            ViewBag.breadCrumbData = "Schedule List";

            return View("StudentSchedule", list);
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
    // GET: /Enrollment/Create
    public ActionResult Create()
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Enrollment") + "'>Enrollment List</a>";
        ViewBag.breadCrumbData += " > Create";
      }
      PLEnrollment enrollment = new PLEnrollment();
      return View("Create", enrollment);
    }

    //
    // POST: /Enrollment/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        //get student id from cache
        EnrollmentClientService.CreateEnrollment(collection["studentID"], Convert.ToInt32(collection["scheduleID"]));
        return RedirectToAction("Index");
      }
      catch (Exception e)
      {
        Console.Write(e.ToString());
        return View();
      }
    }

    //
    // GET: /Enrollment/Create
    /*public ActionResult Edit(string student_id, string schedule_id, string grade)
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Enrollment") + "'>Enrollment List</a>";
        ViewBag.breadCrumbData += " > Edit";
      }

      PLEnrollment enrollment = EnrollmentClientService.GetEnrollmentDetail(student_id, schedule_id, grade);
      return View("Edit", enrollment);
    }*/

    //
    // POST: /Enrollment/Edit/
    [HttpPost]
    public ActionResult Edit(string student_id, string schedule_id, string grade, FormCollection collection)
    {
      try
      {
        EnrollmentClientService.UpdateEnrollment(student_id, Convert.ToInt32(schedule_id), grade);
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Enrollment/Delete/5

    public ActionResult Delete(string student_id, string schedule_id)
    {
      try
      {
        bool success = EnrollmentClientService.DeleteEnrollment(student_id, Convert.ToInt32(schedule_id));

        if (success)
          return RedirectToAction("Index");

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

  }
}
