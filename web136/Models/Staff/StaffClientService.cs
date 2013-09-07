using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Department;

namespace web136.Models.Staff
{
    public static class StaffClientService
    {
        public static List<PLStaff> GetStaffList()
        {
            List<PLStaff> staffList = new List<PLStaff>();

            SLStaff.ISLStaff client = new SLStaff.SLStaffClient();

            string[] errors = new string[0];
            SLStaff.GetStaffListRequest request = new SLStaff.GetStaffListRequest(errors);
            SLStaff.GetStaffListResponse response = client.GetStaffList(request);
            SLStaff.Staff[] staffMembersLoaded = response.GetStaffListResult;

            foreach (SLStaff.Staff s in staffMembersLoaded)
            {
                PLStaff staffMember = DTO_to_PL(s);
                staffList.Add(staffMember);
            }

            return staffList;
        }

        /// <summary>
        /// create a new staff member
        /// </summary>
        /// <param name="s"></param>
        public static void CreateStaff(PLStaff s)
        {
            SLStaff.Staff newStaff = DTO_to_SL(s);

            SLStaff.ISLStaff slStaff = new SLStaff.SLStaffClient();
            string[] errors = new string[0];
            SLStaff.InsertStaffRequest request = new SLStaff.InsertStaffRequest(newStaff, errors);
            slStaff.InsertStaff(request);
        }

        /// <summary>
        /// update existing Staff info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateStaff(PLStaff s)
        {
            SLStaff.Staff newStaff = DTO_to_SL(s);

            SLStaff.ISLStaff SLStaff = new SLStaff.SLStaffClient();
            string[] errors = new string[0];
            SLStaff.UpdateStaffRequest request = new SLStaff.UpdateStaffRequest(newStaff, errors);
            SLStaff.UpdateStaff(request);
        }

        /// <summary>
        /// Get Staff detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLStaff GetStaffDetail(int id)
        {
            SLStaff.ISLStaff slStaff = new SLStaff.SLStaffClient();

            string[] errors = new string[0];
            SLStaff.GetStaffRequest request = new SLStaff.GetStaffRequest(id, errors);
            SLStaff.GetStaffResponse response = slStaff.GetStaff(request);
            SLStaff.Staff newStaff = response.GetStaffResult;
            // this is the data transfer object code...
            return DTO_to_PL(newStaff);
        }

        /// <summary>
        /// call service layer's delete Staff method
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteStaff(int id)
        {
            SLStaff.ISLStaff slStaff = new SLStaff.SLStaffClient();
            string[] errors = new string[0];
            SLStaff.DeleteStaffRequest request = new SLStaff.DeleteStaffRequest(id, errors);
            SLStaff.DeleteStaffResponse response = slStaff.DeleteStaff(request);
            if (response.errors.Length > 0)
                return false;

            return true;
        }

        /// <summary>
        /// This is the data transfer object for Staff.
        /// Converting business layer Staff object to presentation layer Staff object
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns> a presentation layer Staff object</returns>
        private static PLStaff DTO_to_PL(SLStaff.Staff staffMember)
        {
            PLStaff PLStaff = new PLStaff();
            PLStaff.ID = staffMember.id;
            PLStaff.FirstName = staffMember.first_name;
            PLStaff.LastName = staffMember.last_name;
            PLStaff.EmailAddress = staffMember.email;
            PLStaff.Password = staffMember.password;
            PLStaff.Department = DTO_to_PL(staffMember.dept);
            PLStaff.isInstructor = staffMember.isInstructor;

            return PLStaff;
        }

        /// <summary>
        /// This is the data transfer object for Department.
        /// Converting business layer Department object to presentation layer Department object
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns> a presentation layer Department object</returns>
        private static PLDepartment DTO_to_PL(SLStaff.Department dept)
        {
            PLDepartment plDept = new PLDepartment();
            plDept.ID = dept.id;
            plDept.deptName = dept.deptName;
            plDept.chair_id = dept.chairID;

            return plDept;
        }

        /// <summary>
        /// this is data transfer object for Staff.
        /// Converting from presentation layer Staff object to business layer Staff object
        /// </summary>
        /// <param name="staffMember"></param>
        /// <returns>instance of SLStaff</returns>
        private static SLStaff.Staff DTO_to_SL(PLStaff staffMember)
        {
            SLStaff.Staff slStaff = new SLStaff.Staff();
            slStaff.id = staffMember.ID;
            slStaff.first_name = staffMember.FirstName;
            slStaff.last_name = staffMember.LastName;
            slStaff.email = staffMember.EmailAddress;
            slStaff.password = staffMember.Password;
            slStaff.dept = DTO_to_SL(staffMember.Department);
            slStaff.isInstructor = staffMember.isInstructor;

            return slStaff;
        }

        /// <summary>
        /// this is data transfer object for Department.
        /// Converting from presentation layer Department object to business layer Department object
        /// </summary>
        /// <param name="staffMember"></param>
        /// <returns>instance of SLDepartment</returns>
        private static SLStaff.Department DTO_to_SL(PLDepartment dept)
        {
            SLStaff.Department slDept = new SLStaff.Department();
            slDept.id = dept.ID;
            slDept.deptName = dept.deptName;
            slDept.chairID = dept.chair_id;

            return slDept;
        }
    }
}