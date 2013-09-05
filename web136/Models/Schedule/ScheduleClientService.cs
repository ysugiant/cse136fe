using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web136.Models.Schedule
{
  public static class ScheduleClientService
  {
    public static List<PLScheduledCourse> GetScheduleList(int year, string quarter)
    {
      List<PLScheduledCourse> scheduleList = new List<PLScheduledCourse>();

      SLSchedule.ISLCourseSchedule client = new SLSchedule.SLCourseScheduleClient();

      string[] errors = new string[0];
      SLSchedule.GetScheduleListRequest request = new SLSchedule.GetScheduleListRequest(year, quarter, errors);
      SLSchedule.GetScheduleListResponse response = client.GetScheduleList(request);
      SLSchedule.ScheduledCourse[] schedulesLoaded = response.GetScheduleListResult;

      if (schedulesLoaded != null)
      {
          foreach (SLSchedule.ScheduledCourse s in schedulesLoaded)
        {
          PLScheduledCourse schedule = DTO_to_PL(s);
          scheduleList.Add(schedule);
        }
      }
      return scheduleList;
    }

    private static PLScheduledCourse DTO_to_PL(SLSchedule.ScheduledCourse s)
    {
      PLScheduledCourse mySchedule = new PLScheduledCourse();

      mySchedule.schedule_id = s.id;
      mySchedule.year = s.year;
      mySchedule.quarter = s.quarter;
      mySchedule.session = s.session;
      mySchedule.course.title = s.course.title;
      mySchedule.course.description = s.course.description;

      return mySchedule;
    }
  }
}