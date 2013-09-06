using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.ScheduleDay
{
  public static class ScheduleDayClientService
  {
    public static List<PLScheduleDay> GetScheduleDayList()
    {
      List<PLScheduleDay> scheduleDayList = new List<PLScheduleDay>();

      SLScheduleDay.ISLScheduleDay client = new SLScheduleDay.SLScheduleDayClient();

      string[] errors = new string[0];
      SLScheduleDay.GetScheduleDayListRequest request = new SLScheduleDay.GetScheduleDayListRequest(errors);
      SLScheduleDay.GetScheduleDayListResponse response = client.GetScheduleDayList(request);
      Dictionary<string, string> scheduleDaysLoaded = response.GetScheduleDayListResult;

      foreach (KeyValuePair<string, string> s in scheduleDaysLoaded)
      {
          PLScheduleDay st = new PLScheduleDay();
          st.ID = s.Key;
          st.scheduleDay = s.Value;
          scheduleDayList.Add(st);
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
    public static bool DeleteScheduleDay(string id)
    {
      SLScheduleDay.ISLScheduleDay SLScheduleDay = new SLScheduleDay.SLScheduleDayClient();
      string[] errors = new string[0];
      SLScheduleDay.DeleteScheduleDayRequest request = new SLScheduleDay.DeleteScheduleDayRequest(Convert.ToInt32(id), errors);
      SLScheduleDay.DeleteScheduleDayResponse response = SLScheduleDay.DeleteScheduleDay(request);
      if (response.errors.Length > 0)
        return false;

      return true;
    }
  }
}