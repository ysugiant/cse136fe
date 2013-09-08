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
        public static PLScheduledCourse GetScheduleDetail(int id)
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
        /// Get Schedule List Complete
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns>List</Scheduled></returns>
        public static List<PLScheduledCourse> GetScheduleListComplete()
        {
            List<PLScheduledCourse> scheduleList = new List<PLScheduledCourse>();

            SLSchedule.ISLCourseSchedule client = new SLSchedule.SLCourseScheduleClient();

            string[] errors = new string[0];
            SLSchedule.GetScheduleListCompleteRequest request = new SLSchedule.GetScheduleListCompleteRequest(errors);
            SLSchedule.GetScheduleListCompleteResponse response = client.GetScheduleListComplete(request);
            SLSchedule.ScheduledCourse[] schedulesLoaded = response.GetScheduleListCompleteResult;

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

            PLCourse myCourse = new PLCourse();
            myCourse.id = s.course.id;

            List<PLCourse> temp = new List<PLCourse>();
            //check it it is null or not first.
            if (s.course.prerequisite_list != null)
            {
                foreach (SLSchedule.Course course in s.course.prerequisite_list)
                {
                    PLCourse tmp = new PLCourse();
                    tmp.id = course.id;
                    tmp.courseLevel = course.level.ToString();
                    tmp.description = course.description;
                    tmp.title = course.title;
                    tmp.units = course.units;
                    temp.Add(tmp);
                }
                myCourse.prerequisiteList = temp;
            }

          
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

            SLCourse.Course myCourse = new SLCourse.Course();
            myCourse.id = s.course.id;

            List<SLCourse.Course> temp = new List<SLCourse.Course>();
            foreach (PLCourse course in s.course.prerequisiteList)
            {
                SLCourse.Course tmp = new SLCourse.Course();
                tmp.id = course.id;
                tmp.level = course.courseLevel;
                tmp.description = course.description;
                tmp.title = course.title;
                tmp.units = course.units;
                temp.Add(tmp);
            }

            myCourse.prerequisite_list = temp.ToArray();
            myCourse.description = s.course.description;
            myCourse.level = s.course.courseLevel;
            myCourse.title = s.course.title;
            myCourse.units = s.course.units;

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

        /*
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

            List<SLCourse.Course> temp = new List<SLCourse.Course>();
            foreach (PLCourse course in s.prerequisiteList)
            {
                SLCourse.Course tmp = new SLCourse.Course();
                tmp.id = course.id;
                tmp.level = course.courseLevel;
                tmp.description = course.description;
                tmp.title = course.title;
                tmp.units = course.units;
                temp.Add(tmp);
            }

            myCourse.prerequisite_list = temp.ToArray();
            myCourse.description = s.description;
            myCourse.level = s.courseLevel;
            myCourse.title = s.title;
            myCourse.units = s.units;

            return myCourse;
        }*/
    }
}