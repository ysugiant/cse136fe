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
        /*
         * 
         *       SLStudent.ISLStudent client = new SLStudent.SLStudentClient();

      string[] errors = new string[0];
      SLStudent.GetStudentListRequest request = new SLStudent.GetStudentListRequest(errors);
      SLStudent.GetStudentListResponse response = client.GetStudentList(request);
      SLStudent.Student[] studentsLoaded = response.GetStudentListResult;

         */

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
      
  }
}