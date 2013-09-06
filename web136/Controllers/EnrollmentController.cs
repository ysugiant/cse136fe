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
        string id = "A00000001";
        /*if (Session["id"] != null)
            id = Session["id"].ToString();
        else
            return View("Error");*/
        List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList(id);
        ViewBag.breadCrumbData = "Enrollment List";

        return View("List", list);
    }


      public double GetTotalGPA(string student_id)
      {
          List<PLEnrollment> list = EnrollmentClientService.GetEnrollmentList(student_id);

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
