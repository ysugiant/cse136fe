using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.Enrollment
{
  public static class EnrollmentClientService
  {
    public static List<PLEnrollment> GetEnrollmentList()
    {
      List<PLEnrollment> enrollmentList = new List<PLEnrollment>();

      SLEnrollment.ISLEnrollment client = new SLEnrollment.SLEnrollmentClient();

      string[] errors = new string[0];
      SLEnrollment.GetEnrollmentListRequest request = new SLEnrollment.GetEnrollmentListRequest(errors);
      SLEnrollment.GetEnrollmentListResponse response = client.GetEnrollmentList(request);
      SLEnrollment.Enrollment[] enrollmentsLoaded = response.GetEnrollmentListResult;
      if (enrollmentsLoaded != null)
      {
          foreach (SLEnrollment.Enrollment s in enrollmentsLoaded)
          {
              PLEnrollment enrollment = DTO_to_PL(s);
              enrollmentList.Add(enrollment);
          }
      }

      return enrollmentList;
    }

    public static List<PLEnrollment> GetStudentEnrollmentList(string stID)
    {
        List<PLEnrollment> enrollmentList = GetEnrollmentList();

        List<PLEnrollment> res = new List<PLEnrollment>();

        foreach (PLEnrollment tmp in enrollmentList)
        {
            if (tmp.studentID.Equals(stID))
                res.Add(tmp);
        }

        return res;
    }

    public static List<PLEnrollment> GetInstructorEnrollmentList(string instID)
    {
        List<PLEnrollment> enrollmentList = GetEnrollmentList();

        List<PLEnrollment> res = new List<PLEnrollment>();

        foreach (PLEnrollment tmp in enrollmentList)
        {
            if (tmp.scheduledCourse.instructorID.Equals(instID))
                res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// create a new enrollment
    /// </summary>
    /// <param name="s"></param>
    public static void CreateEnrollment(string student_id, int schedule_id)
    {
      SLEnrollment.ISLEnrollment SLEnrollment = new SLEnrollment.SLEnrollmentClient();
      string[] errors = new string[0];
      SLEnrollment.InsertEnrollmentRequest request = new SLEnrollment.InsertEnrollmentRequest(student_id, schedule_id, errors);
      SLEnrollment.InsertEnrollment(request);
    }

    /// <summary>
    /// update existing enrollment info
    /// </summary>
    /// <param name="s"></param>
    public static void UpdateEnrollment(string student_id, int schedule_id, string grade)
    {
      SLEnrollment.ISLEnrollment SLEnrollment = new SLEnrollment.SLEnrollmentClient();
      string[] errors = new string[0];
      SLEnrollment.UpdateEnrollmentRequest request = new SLEnrollment.UpdateEnrollmentRequest(student_id, schedule_id, grade, errors);
      SLEnrollment.UpdateEnrollment(request);
    }


    /// <summary>
    /// call service layer's delete enrollment method
    /// </summary>
    /// <param name="id"></param>
    public static bool DeleteEnrollment(string student_id, int schedule_id)
    {
      SLEnrollment.ISLEnrollment SLEnrollment = new SLEnrollment.SLEnrollmentClient();
      string[] errors = new string[0];
      SLEnrollment.DeleteEnrollmentRequest request = new SLEnrollment.DeleteEnrollmentRequest(student_id, schedule_id, errors);
      SLEnrollment.DeleteEnrollmentResponse response = SLEnrollment.DeleteEnrollment(request);
      if (response.errors.Length > 0)
        return false;

      return true;
    }

    /// <summary>
    /// This is the data transfer object for enrollment.
    /// Converting business layer enrollment object to presentation layer enrollment object
    /// </summary>
    /// <param name="enrollment"></param>
    /// <returns></returns>
    private static PLEnrollment DTO_to_PL(SLEnrollment.Enrollment enrollment)
    {
      PLEnrollment PLEnrollment = new PLEnrollment();
      PLEnrollment.scheduledCourse = DTO_to_PL(enrollment.ScheduledCourse);
      PLEnrollment.grade = enrollment.grade;
      PLEnrollment.studentID = enrollment.student_id;
        
      return PLEnrollment;
    }

/*
    private static PLScheduledCourse DTO_to_PL(SLEnrollment.ScheduledCourse s)
    {
        PLScheduledCourse mySchedule = new PLScheduledCourse();

      mySchedule.schedule_id = s.id;
      mySchedule.year = s.year;
      mySchedule.quarter = s.quarter;
      mySchedule.session = s.session;

      mySchedule.course = new Course.PLCourse();
      mySchedule.course.title = s.course.title;
      mySchedule.course.description = s.course.description;
      mySchedule.course.units = s.course.units;

      return mySchedule;
    }*/

    private static PLScheduledCourse DTO_to_PL(SLEnrollment.ScheduledCourse s)
    {
        PLScheduledCourse mySchedule = new PLScheduledCourse();

        mySchedule.schedule_id = s.id;
        mySchedule.year = s.year;
        mySchedule.quarter = s.quarter;
        mySchedule.session = s.session;

        Course.PLCourse myCourse = new Course.PLCourse();
        myCourse.id = s.course.id;

        myCourse.description = s.course.description;
        myCourse.courseLevel = s.course.level.ToString();
        myCourse.title = s.course.title;
        myCourse.units = s.course.units;

        mySchedule.dayID = s.dayID;
        mySchedule.day = s.day;
        mySchedule.timeID = s.timeID;
        mySchedule.time = s.time;
        mySchedule.instructorID = s.instr_id;
        mySchedule.firstName = s.instructor_fName;
        mySchedule.lastName = s.instructor_lName;
        mySchedule.course = myCourse;

        return mySchedule;
    }
  }
}