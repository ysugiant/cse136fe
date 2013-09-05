using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web136.Models.Course
{
  public class CourseClientService
  {
    public static List<PLCourse> GetCourseList()
    {
      List<PLCourse> courseList = new List<PLCourse>();


      SLCourse.ISLCourse client = new SLCourse.SLCourseClient();

      string[] errors = new string[0];
      SLCourse.GetCourseListRequest request = new SLCourse.GetCourseListRequest(errors);
      SLCourse.GetCourseListResponse response = client.GetCourseList(request);
      SLCourse.Course[] coursesLoaded = response.GetCourseListResult;

      if (coursesLoaded != null)
      {
        foreach (SLCourse.Course s in coursesLoaded)
        {
          PLCourse Course = DTO_to_PL(s);
          courseList.Add(Course);
        }
      }
      return courseList;
    }

    private static PLCourse DTO_to_PL(SLCourse.Course s)
    {
      PLCourse myCourse = new PLCourse();

      myCourse.id = s.id;
      myCourse.title = s.title;
      myCourse.description = s.description;
      myCourse.courseLevel = s.level;
      
      myCourse.units = s.units;
      if (s.prerequisite_list != null)
      {
          myCourse.prerequisiteList = new List<PLCourse>();
          foreach (SLCourse.Course course in s.prerequisite_list)
          {
              PLCourse tmp = DTO_to_PL(course);
              myCourse.prerequisiteList.Add(tmp);
          }
      }
     

      return myCourse;
    }
    private static SLCourse.Course DTO_to_SL(PLCourse coursePL)
    {
        SLCourse.Course Course = new SLCourse.Course();
        Course.id = coursePL.id;
        Course.title = coursePL.title;
        Course.level = coursePL.courseLevel;
        Course.units = coursePL.units;
        // we don't insert to the database


        return Course;
    }


    public static PLCourse GetCourseDetail(string courseTitle)
    {
        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();

        string[] errors = new string[0];
        SLCourse.GetCourseRequest request = new SLCourse.GetCourseRequest(courseTitle, errors);
        SLCourse.GetCourseResponse response = SLCourse.GetCourse(request);
        SLCourse.Course newCourse = response.GetCourseResult;
        // this is the data transfer object code...
        return DTO_to_PL(newCourse);
    }

    public static void CreateCourse(PLCourse c)
    {
        SLCourse.Course newCourse = DTO_to_SL(c);

        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();
        string[] errors = new string[0];
        SLCourse.InsertCourseRequest request = new SLCourse.InsertCourseRequest(newCourse, errors);
        SLCourse.InsertCourse(request);
    }

    public static void UpdateCourse(PLCourse s)
    {
        SLCourse.Course newCourse = DTO_to_SL(s);

        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();
        string[] errors = new string[0];
        SLCourse.UpdateCourseRequest request = new SLCourse.UpdateCourseRequest(newCourse, errors);
        SLCourse.UpdateCourse(request);
    }

    public static bool DeleteCourse(string courseTitle)
    {
        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();
        string[] errors = new string[0];
        SLCourse.DeleteCourseRequest request = new SLCourse.DeleteCourseRequest(courseTitle, errors);
        SLCourse.DeleteCourseResponse response = SLCourse.DeleteCourse(request);
        if (response.errors.Length > 0)
            return false;

        return true;
    }

    public static void InsertPrerequisite(int course_id,int pre_id )
    {

        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();
        string[] errors = new string[0];
        SLCourse.InsertPrerequisiteRequest request = new SLCourse.InsertPrerequisiteRequest(course_id, pre_id, errors);
        SLCourse.InsertPrerequisite(request);    
    }
    public static bool DeletePrerequisite(int course_id, int pre_id)
    {

        SLCourse.ISLCourse SLCourse = new SLCourse.SLCourseClient();
        string[] errors = new string[0];
        SLCourse.DeletePrerequisiteRequest request = new SLCourse.DeletePrerequisiteRequest(course_id, pre_id, errors);
        SLCourse.DeletePrerequisiteResponse response = SLCourse.DeletePrerequisite(request);
        if (response.errors.Length > 0)
            return false;

        return true;
    }

  }
}