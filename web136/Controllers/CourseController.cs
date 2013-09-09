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

        //Displaying all Department names
        List<SelectListItem> LevelList = new List<SelectListItem>();

        LevelList.Add(new SelectListItem { Text = "Lower Division", Value = "lower"});
        LevelList.Add(new SelectListItem { Text = "Upper Division", Value = "upper" });
        LevelList.Add(new SelectListItem { Text = "Graduate Division", Value = "grad" });
        LevelList.Add(new SelectListItem { Text = "Post-Graduate Divsion", Value = "phd" });

        ViewBag.LevelList = LevelList;

        return View("Create", Course);
    }

    //
    // POST: /Course/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection, string levelFilter)
    {
        try
        {
            PLCourse Course = new PLCourse();
           // we don't need course id Course.id = Convert.ToInt32( collection["id"]);
            Course.title = collection["title"];
            Course.description = collection["description"];
            Course.courseLevel = levelFilter;//collection["courseLevel"];
            Course.units = Convert.ToInt32(collection["units"]);
            //Course.prerequisiteList = new List<PLCourse>();

            //CourseClientService.GetCourseDetail(collection["title"]);
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
    // GET: /Course/Edit
    public ActionResult Edit(string title)
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Course") + "'>Course List</a>";
            ViewBag.breadCrumbData += " > Edit";
        }
        /*if (title == null)
        {
            return RedirectToAction("Index");
        }*/
        PLCourse Course = CourseClientService.GetCourseDetail(title);
        return View("Edit", Course);
    }

    //
    // POST: /Course/Edit/
    [HttpPost]
    public ActionResult Edit(FormCollection collection)
    {
        try
        {
            PLCourse Course = new PLCourse();
            Course.id = CourseClientService.GetCourseDetail(collection["title"]).id;//collection["id"];//title;//Convert.ToInt32(collection["id"]);
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

    // GET: /Course/Get/
    public ActionResult Get(string courseTitle)
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Get", "Course") + "'>Get Course</a>";
            ViewBag.breadCrumbData += " > Get";
        }
        PLCourse course = CourseClientService.GetCourseDetail(courseTitle);
        return View("Get", course);
    }

    [HttpPost]
    public ActionResult CreatePrerequisite( FormCollection collection)
    {
        try
        {
            int course_id = Convert.ToInt32(collection["course_id"]);
            int pre_id = Convert.ToInt32(collection["pre_id"]);
            CourseClientService.InsertPrerequisite(course_id,pre_id);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    [HttpPost]
    public ActionResult DeletePrerequisite(FormCollection collection)
    {
        try
        {
            int course_id = Convert.ToInt32(collection["course_id"]);
            int pre_id = Convert.ToInt32(collection["pre_id"]);
            CourseClientService.DeletePrerequisite(course_id, pre_id);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: /Course/Delete/
    public ActionResult Delete(string title)
    {
        try
        {
            PLCourse Course = new PLCourse();
            Course = CourseClientService.GetCourseDetail(title);
            if (Course.prerequisiteList.Count > 0)
            {
                for (int i = 0; i < Course.prerequisiteList.Count; i++)
                {
                    CourseClientService.DeletePrerequisite(Course.id, Course.prerequisiteList[i].id);
                }

            }
            
            bool success = CourseClientService.DeleteCourse(title);

            if (success)
                return RedirectToAction("Index");

            return RedirectToAction("Error");
        }
        catch
        {
            return RedirectToAction("Index");//View("Index");
        }
    }

    public ActionResult Error()
    {
        return View("Error");
    }

  }
}
