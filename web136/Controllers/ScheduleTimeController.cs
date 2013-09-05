using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.ScheduleTime;

namespace web136.Controllers
{
  public class ScheduleTimeController : Controller
  {
    public string GetNumScheduleTimeTotal()
    {
      List<string> list = ScheduleTimeClientService.GetScheduleTimeList();
      return list.Count.ToString();
    }

    public JsonResult GetSampleScheduleTime(int idx)
    {
      List<string> list = ScheduleTimeClientService.GetScheduleTimeList();

      return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }


    public ActionResult Index()
    {
      List<string> list = ScheduleTimeClientService.GetScheduleTimeList();
      ViewBag.breadCrumbData = "Schedule Time List";

      return View("List", list);
    }

    //
    // GET: /Student/Create
    public ActionResult Create()
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "ScheduleTime") + "'>Schedule Time List</a>";
        ViewBag.breadCrumbData += " > Create";
      }
      PLScheduleTime scheduleTime = new PLScheduleTime();
      return View("Create", scheduleTime);
    }

    //
    // POST: /Student/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        PLScheduleTime scheduleTime = new PLScheduleTime();
        scheduleTime.scheduleTime = collection["scheduleTime"];
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
        bool success = ScheduleTimeClientService.DeleteScheduleTime(id);

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
