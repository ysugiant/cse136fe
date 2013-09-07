using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Student;

namespace web136.Controllers
{
  public class StudentController : Controller
  {
    public string GetNumStudentsTotal()
    {
      List<PLStudent> list = StudentClientService.GetStudentList();
      return list.Count.ToString();
    }

    public JsonResult GetSampleStudent(int idx)
    {
      List<PLStudent> list = StudentClientService.GetStudentList();

      return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }


    public ActionResult Index()
    {
      List<PLStudent> list = StudentClientService.GetStudentList();
      ViewBag.breadCrumbData = "Student List";

      return View("List", list);
    }

    //
    // GET: /Student/Create
    public ActionResult Create()
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Student") + "'>Student List</a>";
        ViewBag.breadCrumbData += " > Create";
      }
      PLStudent student = new PLStudent();

      return View("Create", student);
    }

    //
    // POST: /Student/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
        /*int year = DateTime.Now.Year;
        int previousYear = year - 1;
        int nextYear = year + 1;

        // only display the current year, previous year, and next year as selections
        List<SelectListItem> MajorList = new List<SelectListItem>();
        MajorList.Add(new SelectListItem { Text = "All Years", Value = "" });
        MajorList.Add(new SelectListItem { Text = previousYear.ToString(), Value = previousYear.ToString() });
        MajorList.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString() });
        MajorList.Add(new SelectListItem { Text = nextYear.ToString(), Value = nextYear.ToString() });

        ViewBag.MajorList = MajorList;*/
      try
      {
        PLStudent student = new PLStudent();
        student.ID = collection["ID"];
        student.FirstName = collection["FirstName"];
        student.LastName = collection["LastName"];
        student.SSN = collection["SSN"];
        student.EmailAddress = collection["EmailAddress"];
        student.Password = collection["Password"];
        student.ShoeSize = float.Parse(collection["ShoeSize"]);
        student.Weight = Convert.ToInt32(collection["Weight"]);
        student.StudentLevel = collection["StudentLevel"];
        student.Major = Convert.ToInt32(collection["Major"]);
        student.Status = Convert.ToInt32(collection["Status"]);
        StudentClientService.CreateStudent(student);
        return RedirectToAction("Index");// this brings us to the student List page
      }
      catch (Exception e)
      {
        Console.Write(e.ToString());
        return View();
      }
    }

    //
    // GET: /Student/Edit
    public ActionResult Edit(string id)
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Student") + "'>Student List</a>";
        ViewBag.breadCrumbData += " > Edit";
      }

      PLStudent student = StudentClientService.GetStudentDetail(id);
      return View("Edit", student);
    }

    //
    // POST: /Student/Edit/
    [HttpPost]
    public ActionResult Edit(string id, FormCollection collection)
    {
      try
      {
        PLStudent student = new PLStudent();
        student.ID = id;//collection["ID"];
        student.FirstName = collection["FirstName"];
        student.LastName = collection["LastName"];
        student.SSN = collection["SSN"];
        student.EmailAddress = collection["EmailAddress"];
        student.Password = collection["Password"];
        student.ShoeSize = float.Parse(collection["ShoeSize"]);
        student.Weight = Convert.ToInt32(collection["Weight"]);
        student.StudentLevel = collection["StudentLevel"];
        student.Major = Convert.ToInt32(collection["Major"]);
        student.Status = Convert.ToInt32(collection["Status"]);
        StudentClientService.UpdateStudent(student);
        return RedirectToAction("Index");
      }
      catch
      {
        return View("Error");
      }
    }

    //
    // GET: /Student/Delete/5

    public ActionResult Delete(string id)
    {
      try
      {
        bool success = StudentClientService.DeleteStudent(id);

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
