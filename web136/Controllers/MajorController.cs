using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Major;
using web136.Models.Department;

namespace web136.Controllers
{
  public class MajorController : Controller
  {
     
    //
    // CREATE: /Major/Create/
    public ActionResult Create()
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Create", "Major") + "'>Create Major</a>";
            ViewBag.breadCrumbData += " > Create";
        }
        PLMajor major = new PLMajor();
        return View("Create", major);
    }

    //
    // POST: /Major/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
        try
        {
            PLMajor major = new PLMajor();
            major.major_id = Convert.ToInt32(collection["major_id"]);
            major.major_name = collection["major_name"];
            major.dept_id = Convert.ToInt32(collection["dept_id"]);
            MajorClientService.InsertMajor(major);
            return RedirectToAction("Create");
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return View();
        }
    }
    
    //
    // GET: /Major/Edit/
    public ActionResult Edit()
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Edit", "Major") + "'>Edit Major</a>";
            ViewBag.breadCrumbData += " > Edit";
        }
        PLMajor major = new PLMajor();
        return View("Edit", major);
    }

    //
    // POST: /Major/Edit/
    [HttpPost]
    public ActionResult Edit(FormCollection collection)
    {
        try
        {
            PLMajor major = new PLMajor();
            major.major_id = Convert.ToInt32(collection["major_id"]);
            major.major_name = collection["major_name"];
            major.dept_id = Convert.ToInt32(collection["dept_id"]);
            MajorClientService.UpdateMajor(major);
            return RedirectToAction("Edit");
        }
        catch
        {
            return View();
        }
    }
     
     //
     // GET: /Major/Get/
     public ActionResult Get()
     {
         if (HttpContext != null)
         {
             UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
             ViewBag.breadCrumbData = "<a href='" + url.Action("Get", "Major") + "'>Get Major</a>";
             ViewBag.breadCrumbData += " > Get";
         }
         PLMajor major = new PLMajor();
         return View("Get", major);
     }
     
    /* //
     // LIST: /Major/List/
     public ActionResult List(int placeHolder)
     {
         List<PLMajor> list = MajorClientService.GetMajorList();
         ViewBag.breadCrumbData = "Major List";

         return View("List", list);
     }*/

     //
     // GET: /Major/Delete/
     public ActionResult Delete()
     {
         if (HttpContext != null)
         {
             UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
             ViewBag.breadCrumbData = "<a href='" + url.Action("Delete", "Major") + "'>Delete Major</a>";
             ViewBag.breadCrumbData += " > Delete";
         }
         PLMajor major = new PLMajor();
         return View("Delete", major);
     }
     
    //
    // POST: /Major/Delete/
    [HttpPost]
    public ActionResult Delete(FormCollection collection)
    {
         try
         {
           int major_id = Convert.ToInt32(collection["major_id"]);
           bool success = MajorClientService.DeleteMajor(major_id);

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
    // AJAX: for /Major/Create
    public JsonResult GetSampleMajor(int idx)
    {
            List<string> errors = new List<string>();
            List<PLMajor> list = MajorClientService.GetMajorList();
            /*System.Diagnostics.Debug.WriteLine("List Count:" + list.Count);
            System.Diagnostics.Debug.WriteLine("MajorID:" + list[idx].major_id);
            System.Diagnostics.Debug.WriteLine("MajorName:" + list[idx].major_name);
            System.Diagnostics.Debug.WriteLine("DeptID:" + list[idx].dept_id);*/
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].major_id == idx)
                    return this.Json(list[i], JsonRequestBehavior.AllowGet);
            }        
            errors.Add("major id not found");
            return this.Json(errors);
    }

    //
    // AJAX: Department dropdown list for /Major/Create
    public JsonResult GetDepartmentListForDropdown(int idx)
    {
        List<PLDepartment> list = DepartmentClientService.GetDepartmentList();

        /*
        System.Diagnostics.Debug.WriteLine("MajorID:" + list[idx].major_id);
        System.Diagnostics.Debug.WriteLine("MajorName:" + list[idx].major_name);
        System.Diagnostics.Debug.WriteLine("DeptID:" + list[idx].dept_id);*/
        foreach (PLDepartment d in list)
            System.Diagnostics.Debug.WriteLine("deptID: " + d.ID + ", deptName: " + d.deptName + ", deptChair: " + d.chair_id);

        return this.Json(list, JsonRequestBehavior.AllowGet);
    }

    public ActionResult Error()
    {
        return View("Error");
    }

  }
}
