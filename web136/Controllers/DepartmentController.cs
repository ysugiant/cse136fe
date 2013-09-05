using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Department;

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
        return RedirectToAction("Index");
      }
      catch (Exception e)
      {
        Console.Write(e.ToString());
        return View();
      }
    }

    //
    // GET: /Student/Delete/5

    public ActionResult Delete(string id)
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
