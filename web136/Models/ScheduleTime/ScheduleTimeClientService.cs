using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.ScheduleTime
{
  public static class ScheduleTimeClientService
  {
    public static List<string> GetScheduleTimeList()
    {
      List<string> scheduleTimeList = new List<string>();

      SLScheduleTime.ISLScheduleTime client = new SLScheduleTime.SLScheduleTimeClient();

      string[] errors = new string[0];
      SLScheduleTime.GetScheduleTimeListRequest request = new SLScheduleTime.GetScheduleTimeListRequest(errors);
      SLScheduleTime.GetScheduleTimeListResponse response = client.GetScheduleTimeList(request);
      string[] scheduleTimesLoaded = response.GetScheduleTimeListResult;

      foreach (string s in scheduleTimesLoaded)
      {
        scheduleTimeList.Add(s);
      }

      return scheduleTimeList;
    }

    /// <summary>
    /// create a new student
    /// </summary>
    /// <param name="s"></param>
    public static void CreateScheduleTime(string s)
    {
      SLScheduleTime.ISLScheduleTime SLScheduleTime = new SLScheduleTime.SLScheduleTimeClient();
      string[] errors = new string[0];
      SLScheduleTime.InsertScheduleTimeRequest request = new SLScheduleTime.InsertScheduleTimeRequest(s, errors);
      SLScheduleTime.InsertScheduleTime(request);
    }

    /// <summary>
    /// call service layer's delete student method
    /// </summary>
    /// <param name="id"></param>
    public static bool DeleteScheduleTime(string Time)
    {
      SLScheduleTime.ISLScheduleTime SLScheduleTime = new SLScheduleTime.SLScheduleTimeClient();
      string[] errors = new string[0];
      SLScheduleTime.DeleteScheduleTimeRequest request = new SLScheduleTime.DeleteScheduleTimeRequest(Time, errors);
      SLScheduleTime.DeleteScheduleTimeResponse response = SLScheduleTime.DeleteScheduleTime(request);
      if (response.errors.Length > 0)
        return false;

      return true;
    }
  }
}