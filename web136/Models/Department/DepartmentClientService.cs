using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web136.Models.Department
{
  public static class DepartmentClientService
  {
    public static List<PLDepartment> GetDepartmentList()
    {
      List<PLDepartment> departmentList = new List<PLDepartment>();

      SLDepartment.ISLDepartment client = new SLDepartment.SLDepartmentClient();

      string[] errors = new string[0];
      SLDepartment.GetDepartmentListRequest request = new SLDepartment.GetDepartmentListRequest(errors);
      SLDepartment.GetDepartmentListResponse response = client.GetDepartmentList(request);
      SLDepartment.Department[] departmentsLoaded = response.GetDepartmentListResult;

      foreach (SLDepartment.Department s in departmentsLoaded)
      {
        PLDepartment department = DTO_to_PL(s);
        departmentList.Add(department);
      }

      return departmentList;
    }

    /// <summary>
    /// create a new department
    /// </summary>
    /// <param name="s"></param>
    public static void CreateDepartment(PLDepartment s)
    {
      SLDepartment.Department newDepartment = DTO_to_SL(s);

      SLDepartment.ISLDepartment SLDepartment = new SLDepartment.SLDepartmentClient();
      string[] errors = new string[0];
      SLDepartment.InsertDepartmentRequest request = new SLDepartment.InsertDepartmentRequest(newDepartment, errors);
      SLDepartment.InsertDepartment(request);
    }

    /// <summary>
    /// update existing department info
    /// </summary>
    /// <param name="s"></param>
    public static void UpdateDepartment(PLDepartment s)
    {
      SLDepartment.Department newDepartment = DTO_to_SL(s);

      SLDepartment.ISLDepartment SLDepartment = new SLDepartment.SLDepartmentClient();
      string[] errors = new string[0];
      SLDepartment.UpdateDepartmentRequest request = new SLDepartment.UpdateDepartmentRequest(newDepartment, errors);
      SLDepartment.UpdateDepartment(request);
    }

    /// <summary>
    /// Get department detail
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static PLDepartment GetDepartmentDetail(string id)
    {
      SLDepartment.ISLDepartment SLDepartment = new SLDepartment.SLDepartmentClient();

      string[] errors = new string[0];
      SLDepartment.GetDepartmentDetailRequest request = new SLDepartment.GetDepartmentDetailRequest(id, errors);
      SLDepartment.GetDepartmentDetailResponse response = SLDepartment.GetDepartmentDetail(request);
      SLDepartment.Department newDepartment = response.GetDepartmentDetailResult;
      //System.Diagnostics.Debug.WriteLine("newDepartment value: " + newDepartment.ToString());
      System.Diagnostics.Debug.WriteLine("response: " + response.GetDepartmentDetailResult);
      // this is the data transfer object code...
      return DTO_to_PL(newDepartment);
    }

    /// <summary>
    /// call service layer's delete department method
    /// </summary>
    /// <param name="id"></param>
    public static bool Delete(string id)
    {
      SLDepartment.ISLDepartment SLDepartment = new SLDepartment.SLDepartmentClient();
      string[] errors = new string[0];
      SLDepartment.DeleteDepartmentRequest request = new SLDepartment.DeleteDepartmentRequest(id, errors);
      SLDepartment.DeleteDepartmentResponse response = SLDepartment.DeleteDepartment(request);
      if (response.errors.Length > 0)
        return false;

      return true;
    }

    
    /// <summary>
    /// This is the data transfer object for department.
    /// Converting business layer department object to presentation layer department object
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    private static PLDepartment DTO_to_PL(SLDepartment.Department department)
    {
      PLDepartment PLDepartment = new PLDepartment();
      PLDepartment.ID = department.id;
      PLDepartment.deptName = department.deptName;
      PLDepartment.chair_id= department.chairID;
      return PLDepartment;
    }

    /// <summary>
    /// this is data transfer object for department.
    /// Converting from presentation layer department object to business layer department object
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    private static SLDepartment.Department DTO_to_SL(PLDepartment department)
    {
      SLDepartment.Department SLDepartment = new SLDepartment.Department();
      SLDepartment.id = department.ID;
      SLDepartment.deptName = department.deptName;
      SLDepartment.chairID = department.chair_id;

      return SLDepartment;
    }

  }
}