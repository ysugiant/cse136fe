using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Course;

namespace web136.Models.Schedule
{
    public static class ScheduleClientService
    {
        /// <summary>
        /// Insert a new course to the schedule
        /// </summary>
        /// <param name="s"></param>
        public static void InsertScheduledCourse(PLScheduledCourse s)
        {
            SLSchedule.ScheduledCourse newCourseSchedule = DTO_to_SL(s);

            SLSchedule.ISLCourseSchedule SLSchedule = new SLSchedule.SLCourseScheduleClient();
            string[] errors = new string[0];
            SLSchedule.InsertCourseScheduleRequest request = new SLSchedule.InsertCourseScheduleRequest(newCourseSchedule, errors);
            SLSchedule.InsertCourseSchedule(request);
        }

        /// <summary>
        /// update existing schedule for a course
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateScheduledCourse(PLScheduledCourse s)
        {
            SLSchedule.ScheduledCourse updateCourseSchedule = DTO_to_SL(s);

            SLSchedule.ISLCourseSchedule SLSchedule = new SLSchedule.SLCourseScheduleClient();
            string[] errors = new string[0];
            SLSchedule.UpdateCourseScheduleRequest request = new SLSchedule.UpdateCourseScheduleRequest(updateCourseSchedule, errors);
            SLSchedule.UpdateCourseSchedule(request);
        }

        /// <summary>
        /// call service layer's delete scheduled course method
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteScheduledCourse(int id)
        {
            SLSchedule.ISLCourseSchedule SLSchedule = new SLSchedule.SLCourseScheduleClient();
            string[] errors = new string[0];
            SLSchedule.DeleteCourseScheduleRequest request = new SLSchedule.DeleteCourseScheduleRequest(id, errors);
            SLSchedule.DeleteCourseScheduleResponse response = SLSchedule.DeleteCourseSchedule(request);
            if (response.errors.Length > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Get course schedule detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PLScheduleCourse</returns>
        public static PLScheduledCourse GetStudentDetail(int id)
        {
            SLSchedule.ISLCourseSchedule SLSchedule = new SLSchedule.SLCourseScheduleClient();

            string[] errors = new string[0];
            SLSchedule.GetCourseScheduleDetailRequest request = new SLSchedule.GetCourseScheduleDetailRequest(id, errors);
            SLSchedule.GetCourseScheduleDetailResponse response = SLSchedule.GetCourseScheduleDetail(request);
            SLSchedule.ScheduledCourse newSchedule = response.GetCourseScheduleDetailResult;
            //System.Diagnostics.Debug.WriteLine("newStudent value: " + newStudent.ToString());
            System.Diagnostics.Debug.WriteLine("response: " + response.GetCourseScheduleDetailResult);
            // this is the data transfer object code...
            return DTO_to_PL(newSchedule);
        }

        /// <summary>
        /// Get Schedule List
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns>List</Scheduled></returns>
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

        /// <summary>
        /// this is data transfer object for ScheduledCourse.
        /// Converting from presentation layer ScheduledCourse object to business layer ScheduledCourse object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static PLScheduledCourse DTO_to_PL(SLSchedule.ScheduledCourse s)
        {
            PLScheduledCourse mySchedule = new PLScheduledCourse();

            mySchedule.schedule_id = s.id;
            mySchedule.year = s.year;
            mySchedule.quarter = s.quarter;
            mySchedule.session = s.session;

            //mySchedule.course = PLCourse.DTO_to_PL(s.course);
            /*
            mySchedule.course.id = s.course.id;
            mySchedule.course.prerequisiteList = s.course.prerequisite_list;
            mySchedule.course.description = s.course.description;
            mySchedule.course.courseLevel = s.course.level;
            mySchedule.course.title = s.course.title;
            mySchedule.course.units = s.course.units;
            */

            mySchedule.dayID = s.dayID;
            mySchedule.day = s.day;
            mySchedule.timeID = s.timeID;
            mySchedule.time = s.time;
            mySchedule.instructorID = s.instr_id;
            mySchedule.firstName = s.instructor_fName;
            mySchedule.lastName = s.instructor_lName;


            return mySchedule;
        }

        /// <summary>
        /// this is data transfer object for ScheduledCourse.
        /// Converting from presentation layer ScheduledCourse object to business layer ScheduledCourse object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static SLSchedule.ScheduledCourse DTO_to_SL(PLScheduledCourse s)
        {
            SLSchedule.ScheduledCourse SLSchedule = new SLSchedule.ScheduledCourse();
            SLSchedule.id = s.schedule_id;
            //SLSchedule.course = DTO_to_SL(s.course);
            SLSchedule.year = s.year;
            SLSchedule.quarter = s.quarter;
            SLSchedule.session = s.session;
            SLSchedule.dayID = s.dayID;
            SLSchedule.day = s.day;
            SLSchedule.timeID = s.timeID;
            SLSchedule.time = s.time;
            SLSchedule.instr_id = s.instructorID;
            SLSchedule.instructor_fName = s.firstName;
            SLSchedule.instructor_lName = s.lastName;

            return SLSchedule;
        }

        /// <summary>
        /// this is data transfer object for Course.
        /// Converting from presentation layer Course object to business layer Course object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static SLCourse.Course DTO_to_SL(PLCourse s)
        {
            SLCourse.Course myCourse = new SLCourse.Course();

            myCourse.id = s.id;
            //myCourse.prerequisiteList = s.prerequisite_list;
            myCourse.description = s.description;
            //myCourse.courseLevel = s.level;
            myCourse.title = s.title;
            myCourse.units = s.units;

            return myCourse;
        }
    }
}