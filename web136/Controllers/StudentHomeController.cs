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
                {
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

                    string studentLevel = "";
                    switch (Convert.ToInt32(student.StudentLevel))
                    {
                        case 0:
                            studentLevel = "freshman";
                            break;
                        case 1:
                            studentLevel = "sophomore";
                            break;
                        case 2:
                            studentLevel = "junior";
                            break;
                        case 3:
                            studentLevel = "senior";
                            break;                        
                        case 4:
                            studentLevel = "grad";
                            break;
                        case 5:
                            studentLevel = "phd";
                            break;
                    }

                    string studentStatus = "";
                    switch (Convert.ToInt32(student.Status))
                    {
                        case 0:
                            studentStatus = "Good Standing";
                            break;
                        case 1:
                            studentStatus = "Probation";
                            break;
                        case 2:
                            studentStatus = "Subject for Disqualification";
                            break;
                        case 3:
                            studentStatus = "Disqualification";
                            break;
                    }

                    ViewData["studentName"] = studentName;
                    ViewData["studentSSN"] = student.SSN;
                    ViewData["studentEmail"] = student.EmailAddress;
                    ViewData["studentShoeSize"] = student.ShoeSize;
                    ViewData["studentWeight"] = student.Weight;
                    ViewData["studentLevel"] = studentLevel;
                    ViewData["studentStatus"] = studentStatus;
                    ViewData["majorName"] = majorName;
                    ViewData["departmentName"] = departmentName;

                    return View();
                }
            }

            return View("Error");
        }

        //View

        //PLStudent.Update (password only)
        public ActionResult ChangePassword()
        {
            return RedirectToAction("ChangePassword", "Student", new { stID = Session["id"] });
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
