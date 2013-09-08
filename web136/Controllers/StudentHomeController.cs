using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Schedule;
using web136.Models.Student;
using web136.Models.Major;
using web136.Models.Department;

namespace web136.Controllers
{
    public class StudentHomeController : Controller
    {
        //
        // GET: /StudentHome/

        public ActionResult Index()
        {
            if (Session["role"] != null)
            {
                if (Session["role"].Equals("student"))
                    return View();
            }

            PLStudent student = StudentClientService.GetStudentDetail(Session["id"].ToString());
            PLMajor major = MajorClientService.GetMajorDetail(student.Major);
            PLDepartment department = new PLDepartment();
            List<PLDepartment> departmentList = DepartmentClientService.GetDepartmentList();
            foreach (PLDepartment dept in departmentList)
            {
                if (dept.ID == major.dept_id)
                {
                    department = dept;
                    break;
                }
            }

            string studentName = student.LastName + ", " + student.FirstName;
            string majorName = major.major_name;
            string departmentName = department.deptName;

            ViewBag.studentName = "TestName";
            ViewBag.majorName = "TestMajor";
            ViewBag.departmentName = "TestDepartment";

            return View("Error");
        }

        //View

        //PLStudent.Update (password only)
        public ActionResult EditStudentRecord()
        {
            return RedirectToAction("Edit", "Student");
        }

        //PLStudent.Get Info
        public ActionResult ViewStudentRecord()
        {
            return RedirectToAction("Get", "Student");
        }

        //PLEnrollment. (Add and Drop Class)
        public ActionResult RegisterForClass()
        {
            return RedirectToAction("Register", "Enrollment");
        }

        //PLEnrollment. (Transcript)
        public ActionResult ViewTranscript()
        {
            return RedirectToAction("Transcript", "Enrollment", new { stID = Session["id"] });
        }

        //PLEnrollment. (Enrolled Schedule)
        public ActionResult ViewCurrentCourseSChedule()
        {
            return RedirectToAction("StudentSchedule", "Enrollment", new { stID = Session["id"] });
        }

        /*
        //PLDepartment.Get List
        public ActionResult Department()
        {
            return RedirectToAction("", "Department");
        }*/

        //PLCourse.Get Info
        public ActionResult ViewCourse()
        {
            return RedirectToAction("Get", "Course");
        }

        //PLCourse.Get List
        public ActionResult ViewCourses()
        {
            return RedirectToAction("List", "Course");
        }
    }
}
