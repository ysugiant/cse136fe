using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Schedule;
using web136.Models.Course;

namespace web136.Models.Student
{
    public static class StudentClientService
    {
        public static List<PLStudent> GetStudentList()
        {
            List<PLStudent> studentList = new List<PLStudent>();

            SLStudent.ISLStudent client = new SLStudent.SLStudentClient();

            string[] errors = new string[0];
            SLStudent.GetStudentListRequest request = new SLStudent.GetStudentListRequest(errors);
            SLStudent.GetStudentListResponse response = client.GetStudentList(request);
            SLStudent.Student[] studentsLoaded = response.GetStudentListResult;

            foreach (SLStudent.Student s in studentsLoaded)
            {
                PLStudent student = DTO_to_PL(s);
                studentList.Add(student);
            }

            return studentList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateStudent(PLStudent s)
        {
            SLStudent.Student newStudent = DTO_to_SL(s);

            SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();
            string[] errors = new string[0];
            SLStudent.InsertStudentRequest request = new SLStudent.InsertStudentRequest(newStudent, errors);
            SLStudent.InsertStudent(request);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateStudent(PLStudent s)
        {
            SLStudent.Student newStudent = DTO_to_SL(s);

            SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();
            string[] errors = new string[0];
            SLStudent.UpdateStudentRequest request = new SLStudent.UpdateStudentRequest(newStudent, errors);
            SLStudent.UpdateStudent(request);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLStudent GetStudentDetail(string id)
        {
            SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();

            string[] errors = new string[0];
            SLStudent.GetStudentRequest request = new SLStudent.GetStudentRequest(id, errors);
            SLStudent.GetStudentResponse response = SLStudent.GetStudent(request);
            SLStudent.Student newStudent = response.GetStudentResult;
            // this is the data transfer object code...
            return DTO_to_PL(newStudent);
        }

        /// <summary>
        /// call service layer's delete student method
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteStudent(string id)
        {
            SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();
            string[] errors = new string[0];
            SLStudent.DeleteStudentRequest request = new SLStudent.DeleteStudentRequest(id, errors);
            SLStudent.DeleteStudentResponse response = SLStudent.DeleteStudent(request);
            if (response.errors.Length > 0)
                return false;

            return true;
        }

        /*
      /// <summary>
      /// call service layer's delete student method
      /// </summary>
      /// <param name="id"></param>

      public static void Enroll(string student_id, int schedule_id)
      {
        SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();
        string[] errors = new string[0];
        SLStudent.EnrollScheduleRequest request = new SLStudent.EnrollScheduleRequest(student_id, schedule_id, errors);
        SLStudent.EnrollSchedule(request);
      }

      /// <summary>
      /// call service layer's drop student method
      /// </summary>
      /// <param name="id"></param>
      public static void Drop(string student_id, int schedule_id)
      {
        SLStudent.ISLStudent SLStudent = new SLStudent.SLStudentClient();
        string[] errors = new string[0];
        SLStudent.DropEnrolledScheduleRequest request = new SLStudent.DropEnrolledScheduleRequest(student_id, schedule_id, errors);
        SLStudent.DropEnrolledSchedule(request);
      }*/

        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static PLStudent DTO_to_PL(SLStudent.Student student)
        {
            PLStudent PLStudent = new PLStudent();
            PLStudent.ID = student.id;
            PLStudent.FirstName = student.first_name;
            PLStudent.LastName = student.last_name;
            PLStudent.SSN = student.ssn;
            PLStudent.EmailAddress = student.email;
            PLStudent.Password = student.password;
            PLStudent.ShoeSize = student.shoe_size;
            PLStudent.Weight = student.weight;
            PLStudent.StudentLevel = student.level;
            PLStudent.Status = student.status;
            PLStudent.Major = student.major;
            if (student.enrolled != null)
            {
              PLStudent.Enrollments = new List<PLScheduledCourse>();
              foreach (SLStudent.ScheduledCourse course in student.enrolled)
              {
                PLScheduledCourse s = DTO_to_PL(course); // method overloading
                PLStudent.Enrollments.Add(s);
              }
            }
            return PLStudent;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static SLStudent.Student DTO_to_SL(PLStudent student)
        {
            SLStudent.Student SLStudent = new SLStudent.Student();
            SLStudent.id = student.ID;
            SLStudent.ssn = student.SSN;
            SLStudent.first_name = student.FirstName;
            SLStudent.last_name = student.LastName;
            SLStudent.email = student.EmailAddress;
            SLStudent.password = student.Password;
            SLStudent.shoe_size = student.ShoeSize;
            SLStudent.weight = student.Weight;
            SLStudent.level = student.StudentLevel;
            SLStudent.status = student.Status;
            SLStudent.major = student.Major;
            SLStudent.enrolled = null;

            /*if (student.enrolled != null)
            {
                PLStudent.Enrollments = new List<PLScheduledCourse>();
                foreach (SLStudent.ScheduledCourse course in student.enrolled)
                {
                    PLScheduledCourse s = DTO_to_PL(course); // method overloading
                    PLStudent.Enrollments.Add(s);
                }
            }*/
            
            if (student.Enrollments != null)
            {
                SLStudent.enrolled = new List<SLSchedule.ScheduledCourse>();
                string sCourse= null;
                for (int i = 0; i < student.Enrollments.Count(); i++)
                {
                    sCourse = student.Enrollments[i];
                    SLStudent.enrolled[i] = student.Enrollments[i];
                }
            }

            return SLStudent;
        }

        private static PLScheduledCourse DTO_to_PL(SLStudent.ScheduledCourse s)
        {
          PLScheduledCourse mySchedule = new PLScheduledCourse();

          mySchedule.schedule_id = s.id;
          mySchedule.year = s.year;
          mySchedule.quarter = s.quarter;
          mySchedule.session = s.session;
          mySchedule.course = DTO_to_PL(s.course);
          return mySchedule;
        }

        private static PLCourse DTO_to_PL(SLStudent.Course s)
        {
            PLCourse myCourse = new PLCourse();

            myCourse.id = s.id;
            myCourse.title = s.title;
            myCourse.description = s.description;

            return myCourse;
        }
    }
}