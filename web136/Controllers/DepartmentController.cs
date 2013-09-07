using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Department;
using web136.Models.Staff;

namespace web136.Controllers
{
  public class DepartmentController : Controller
  {
    public string GetNumDepartmentTotal()
    {
      List<PLDepartment> list = DepartmentClientService.GetDepartmentList();
      return list.Count.ToString();
    }

    public JsonResult GetSampleDepartment(int idx)
    {
      List<PLDepartment> list = DepartmentClientService.GetDepartmentList();

      return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }


    public ActionResult Index()
    {
      List<PLDepartment> list = DepartmentClientService.GetDepartmentList();
      ViewBag.breadCrumbData = "Department List";

      return View("List", list);
    }

    //
    // GET: /Student/Create
    public ActionResult Create()
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Department") + "'>Department List</a>";
        ViewBag.breadCrumbData += " > Create";
      }
      PLDepartment department = new PLDepartment();
      return View("Create", department);
    }

    //
    // POST: /Student/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        PLDepartment department = new PLDepartment();
        department.chair_id = Convert.ToInt32(collection["chairID"]);
        department.deptName = collection["deptName"];
        DepartmentClientService.CreateDepartment(department);
        return RedirectToAction("Index");
      }
      catch (Exception e)
      {
        Console.Write(e.ToString());
        return View();
      }
    }

    //
    // GET: /Student/Create
    public ActionResult Edit(string id)
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Department") + "'>Department List</a>";
            ViewBag.breadCrumbData += " > Edit";
        }

        PLDepartment department = DepartmentClientService.GetDepartmentDetail(id);
        
        List<PLStaff> st = StaffClientService.GetStaffList();
        List<string> res = new List<string>();
        List<string> idlist = new List<string>();
        /*foreach(PLStaff tmp in st)
        {
            if (tmp.Department.ID == Convert.ToInt32(id))
            {
                res.Add(tmp.FirstName + " "  + tmp.LastName);
                idlist.Add(tmp.ID.ToString());
            }
        }*/
        ViewBag.listStaff = res.ToArray();
        ViewBag.chairID = idlist.ToArray();
        
        return View("Edit", department);
    }

    //
    // POST: /Department/Edit/
    [HttpPost]
    public ActionResult Edit(FormCollection collection)
    {
        try
        {
            PLDepartment department = new PLDepartment();
            department.ID = Convert.ToInt32(collection["ID"]);
            department.deptName = collection["deptName"];
            department.chair_id = Convert.ToInt32(collection["chair_id"]);
            DepartmentClientService.UpdateDepartment(department);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    //
    // GET: /Student/Delete/5

    public ActionResult Delete(int id)
    {
      try
      {
        bool success = DepartmentClientService.DeleteDepartment(id);

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
