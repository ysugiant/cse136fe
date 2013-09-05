using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Course;

namespace web136.Models.Major
{
  public static class MajorClientService
  {
    public static List<PLMajor> GetMajorList(string deptName)
    {
      List<PLMajor> majorList = new List<PLMajor>();

      SLMajor.ISLMajor client = new SLMajor.SLMajorClient();

      string[] errors = new string[0];
      SLMajor.GetMajorListRequest request = new SLMajor.GetMajorListRequest(errors);
      SLMajor.GetMajorListResponse response = client.GetMajorList(request);
      SLMajor.Major[] majorsLoaded = response.GetMajorListResult;

      if (majorsLoaded != null)
      {
        foreach (SLMajor.Major s in majorsLoaded)
        {
          PLMajor major = DTO_to_PL(s);
          majorList.Add(major);
        }
      }
      return majorList;
    }

    private static PLMajor DTO_to_PL(SLMajor.Major m)
    {
        PLMajor myMajor = new PLMajor();

        myMajor.major_id = m.id;
        myMajor.major_name = m.majorName;
        myMajor.dept_id = m.deptId;

      return myMajor;
    }
  }
}