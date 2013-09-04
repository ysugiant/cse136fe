using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Course;

namespace web136.Models.Major
{
  public static class MajorClientService
  {
    public static List<PLMajor> GetMajorList(string deptName)
    {
      List<PLMajor> majorList = new List<PLMajor>();

      SLMajor.ISLMajor client = new SLMajor.SLMajorClient();

      string[] errors = new string[0];
      SLSchedule.GetScheduleListRequest request = new SLSchedule.GetScheduleListRequest(year, quarter, errors);
      SLSchedule.GetScheduleListResponse response = client.GetScheduleList(request);
      SLSchedule.Schedule[] schedulesLoaded = response.GetScheduleListResult;

      if (schedulesLoaded != null)
      {
        foreach (SLSchedule.Schedule s in schedulesLoaded)
        {
          PLSchedule schedule = DTO_to_PL(s);
          scheduleList.Add(schedule);
        }
      }
      return scheduleList;
    }

    private static PLSchedule DTO_to_PL(SLSchedule.Schedule s)
    {
      PLSchedule mySchedule = new PLSchedule();

      mySchedule.schedule_id = s.id;
      mySchedule.year = s.year;
      mySchedule.quarter = s.quarter;
      mySchedule.session = s.session;
      mySchedule.course_title = s.course.title;
      mySchedule.course_description = s.course.description;

      return mySchedule;
    }
  }
}