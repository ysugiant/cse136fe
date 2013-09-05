using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using web136.Models.Course;

namespace web136.Controllers
{
  public class CourseController : Controller
  {
    //
    // GET: /Course/
    public ActionResult GetCourseList()
    {
      List<PLCourse> courseList = CourseClientService.GetCourseList();
      JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
      string courseListJson = jsonSerialiser.Serialize(courseList);

      // return the JSON string
      return Content(courseListJson);
    }
    public string GetNumCoursesTotal()
    {
        List<PLCourse> list = CourseClientService.GetCourseList();
        return list.Count.ToString();
    }

    public JsonResult GetSampleCourse(int idx)
    {
        List<PLCourse> list = CourseClientService.GetCourseList();

        return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }


    public ActionResult Index()
    {
        List<PLCourse> list = CourseClientService.GetCourseList();
        ViewBag.breadCrumbData = "Course List";

        return View("List", list);
    }

    //
    // GET: /Course/Create
    public ActionResult Create()
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Course") + "'>Course List</a>";
            ViewBag.breadCrumbData += " > Create";
        }
        PLCourse Course = new PLCourse();
        return View("Create", Course);
    }

    //
    // POST: /Course/Create
    [HttpPost]
    public ActionResult CreateCourse(FormCollection collection)
    {
        try
        {
            PLCourse Course = new PLCourse();
            Course.id = Convert.ToInt32( collection["id"]);
            Course.title = collection["title"];
            Course.description = collection["description"];
            Course.courseLevel = collection["courseLevel"];
            Course.units = Convert.ToInt32(collection["units"]);
            CourseClientService.CreateCourse(Course);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return View();
        }
    }

    //
    // GET: /Course/Create
    public ActionResult Edit(string id)
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Course") + "'>Course List</a>";
            ViewBag.breadCrumbData += " > Edit";
        }

        PLCourse Course = CourseClientService.GetCourseDetail(id);
        return View("Edit", Course);
    }

    //
    // POST: /Course/Edit/
    [HttpPost]
    public ActionResult Edit(string id, FormCollection collection)
    {
        try
        {
            PLCourse Course = new PLCourse();
            Course.id = Convert.ToInt32(collection["id"]);
            Course.title = collection["title"];
            Course.description = collection["description"];
            Course.courseLevel = collection["courseLevel"];
            Course.units = Convert.ToInt32(collection["units"]);
            CourseClientService.UpdateCourse(Course);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    //
    // GET: /Course/Delete/5

    public ActionResult Delete(string id)
    {
        try
        {
            bool success = CourseClientService.DeleteCourse(id);

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
