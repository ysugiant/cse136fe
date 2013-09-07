using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web136.Models.Staff;
using web136.Models.Department;

namespace web136.Controllers
{
  public class StaffController : Controller
  {
    //
    // GET: /Staff/
    public ActionResult Index()
    {
        List<PLStaff> staffList = StaffClientService.GetStaffList();
        ViewBag.breadCrumbData = "Staff List";

        return View("List", staffList);
    }

    // GET: /Staff/Create
    public ActionResult Create()
    {
        if (HttpContext != null)
        {
            UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
            ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Staff") + "'>Staff List</a>";
            ViewBag.breadCrumbData += " > Create";
        }
        PLStaff staff = new PLStaff();

        /*if (departmentFilter == null)
            departmentFilter = "";*/

        /*int staff_id = Convert.ToInt32(Session["id"].ToString());

        PLStaff staffMember = StaffClientService.GetStaffDetail(staff_id);
        ViewBag.staffMember = staffMember;*/

        List<PLDepartment> departmentList = DepartmentClientService.GetDepartmentList();

        //Displaying all Department names
        List<SelectListItem> DepartmentList = new List<SelectListItem>();
        //List<int> DepartmentListOfIDs = new List<int>();
        foreach (PLDepartment dept in departmentList)
        {
            DepartmentList.Add(new SelectListItem { Text = dept.deptName.ToString() });//, Text = dept.ID.ToString() });
        }

        ViewBag.DepartmentList = DepartmentList;
        //ViewBag.DepartmentListOfIDs = 

        return View("Create", staff);
    }

    // POST: /Staff/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection, string departmentFilter)
    {
        if (departmentFilter == null)
        {
            departmentFilter = "Computer Science and Engineering";
        }

        try
        {
            PLStaff staffMember = new PLStaff();
            //staffMember.ID = Convert.ToInt32(collection["ID"]);
            staffMember.FirstName = collection["FirstName"];
            staffMember.LastName = collection["LastName"];
            staffMember.EmailAddress = collection["EmailAddress"];
            staffMember.Password = collection["Password"];
            //staffMember.Department = new PLDepartment();
            staffMember.Department = DepartmentClientService.GetDepartmentDetail(departmentFilter);//collection.Get(5).ToString());
            //staffMember.Department.deptName = collection.Get(6).ToString();//1;//new PLDepartment();//ViewBag.//DepartmentClientService.CreateDepartment((PLDepartment)(collection["Department"]));//Convert.ToInt32(collection["Department"]);
            staffMember.isInstructor = Convert.ToBoolean(collection["InstructorBit"]);
            StaffClientService.CreateStaff(staffMember);
            return RedirectToAction("Index");// this brings us to the staff List page
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return View();
        }
    }

    // GET: /Staff/Edit
    public ActionResult Edit(int id, FormCollection collection)
    {
        try
        {
            PLStaff staffMember = new PLStaff();
            staffMember.ID = id;
            staffMember.FirstName = collection["FirstName"];
            staffMember.LastName = collection["LastName"];
            staffMember.EmailAddress = collection["EmailAddress"];
            staffMember.Password = collection["Password"];
            staffMember.Department = DepartmentClientService.GetDepartmentDetail(collection["Department"]);
            staffMember.isInstructor = Convert.ToBoolean(collection["isInstructor"]);
            StaffClientService.UpdateStaff(staffMember);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: /Staff/Delete/5
    public ActionResult Delete(int id)
    {
        try
        {
            bool success = StaffClientService.DeleteStaff(id);

            if (success)
                return RedirectToAction("Index");

            return RedirectToAction("Error");
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Error()
    {
        return View("Error");
    }
  }
}
