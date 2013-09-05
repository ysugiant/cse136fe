using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.ScheduleTime
{
  public static class ScheduleDayClientService
  {
    public static List<string> GetScheduleDayList()
    {
      List<string> scheduleDayList = new List<string>();

      SLScheduleDay.ISLScheduleDay client = new SLScheduleDay.SLScheduleDayClient();

      string[] errors = new string[0];
      SLScheduleDay.GetScheduleDayListRequest request = new SLScheduleDay.GetScheduleDayListRequest(errors);
      SLScheduleDay.GetScheduleDayListResponse response = client.GetScheduleDayList(request);
      string[] scheduleDaysLoaded = response.GetScheduleDayListResult;

      foreach (string s in scheduleDaysLoaded)
      {
        scheduleDayList.Add(s);
      }

      return scheduleDayList;
    }

    /// <summary>
    /// create a new student
    /// </summary>
    /// <param name="s"></param>
    public static void CreateScheduleDay(string s)
    {
      SLScheduleDay.ISLScheduleDay SLScheduleDay = new SLScheduleDay.SLScheduleDayClient();
      string[] errors = new string[0];
      SLScheduleDay.InsertScheduleDayRequest request = new SLScheduleDay.InsertScheduleDayRequest(s, errors);
      SLScheduleDay.InsertScheduleDay(request);
    }

    /// <summary>
    /// call service layer's delete student method
    /// </summary>
    /// <param name="id"></param>
    public static bool DeleteScheduleDay(string day)
    {
      SLScheduleDay.ISLScheduleDay SLScheduleDay = new SLScheduleDay.SLScheduleDayClient();
      string[] errors = new string[0];
      SLScheduleDay.DeleteScheduleDayRequest request = new SLScheduleDay.DeleteScheduleDayRequest(day, errors);
      SLScheduleDay.DeleteScheduleDayResponse response = SLScheduleDay.DeleteScheduleDay(request);
      if (response.errors.Length > 0)
        return false;

      return true;
    }
  }
}