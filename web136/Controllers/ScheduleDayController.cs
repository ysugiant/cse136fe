using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.ScheduleDay;

namespace web136.Controllers
{
  public class ScheduleDayController : Controller
  {
    public string GetNumScheduleDayTotal()
    {
      List<PLScheduleDay> list = ScheduleDayClientService.GetScheduleDayList();
      return list.Count.ToString();
    }

    public JsonResult GetSampleScheduleDay(int idx)
    {
      List<PLScheduleDay> list = ScheduleDayClientService.GetScheduleDayList();

      return this.Json(list[idx], JsonRequestBehavior.AllowGet);
    }


    public ActionResult Index()
    {
      List<PLScheduleDay> list = ScheduleDayClientService.GetScheduleDayList();
      ViewBag.breadCrumbData = "Schedule Day List";

      return View("List", list);
    }

    //
    // GET: /Student/Create
    public ActionResult Create()
    {
      if (HttpContext != null)
      {
        UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
        ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "ScheduleDay") + "'>Schedule Day List</a>";
        ViewBag.breadCrumbData += " > Create";
      }
      PLScheduleDay scheduleDay = new PLScheduleDay();
      return View("Create", scheduleDay);
    }

    //
    // POST: /Student/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        PLScheduleDay scheduleDay = new PLScheduleDay();
        scheduleDay.scheduleDay = collection["scheduleDay"];
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
        bool success = ScheduleDayClientService.DeleteScheduleDay(id);

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
