using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web136.Models.Course;

namespace web136.Models.Major
{
    public static class MajorClientService
    {

        /// <summary>
        /// Insert a new Major
        /// </summary>
        /// <param name="m"></param>
        public static void InsertMajor(PLMajor m)
        {
            SLMajor.Major newMajor = DTO_to_SL(m);

            SLMajor.ISLMajor SLMajor = new SLMajor.SLMajorClient();
            string[] errors = new string[0];
            SLMajor.InsertMajorRequest request = new SLMajor.InsertMajorRequest(newMajor, errors);
            SLMajor.InsertMajor(request);
        }

        /// <summary>
        /// update existing Major
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateMajor(PLMajor m)
        {
            SLMajor.Major updateMajor = DTO_to_SL(m);

            SLMajor.ISLMajor SLMajor = new SLMajor.SLMajorClient();
            string[] errors = new string[0];
            SLMajor.UpdateMajorRequest request = new SLMajor.UpdateMajorRequest(updateMajor, errors);
            SLMajor.UpdateMajor(request);
        }

        /// <summary>
        /// call service layer's delete Major method
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteMajor(int id)
        {
            SLMajor.ISLMajor SLMajor = new SLMajor.SLMajorClient();
            string[] errors = new string[0];
            SLMajor.DeleteMajorRequest request = new SLMajor.DeleteMajorRequest(id, errors);
            SLMajor.DeleteMajorResponse response = SLMajor.DeleteMajor(request);
            if (response.errors.Length > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Get Major detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PLMajor</returns>
        public static PLMajor GetMajorDetail(int id)
        {
            SLMajor.ISLMajor SLMajor = new SLMajor.SLMajorClient();

            string[] errors = new string[0];
            SLMajor.GetMajorDetailRequest request = new SLMajor.GetMajorDetailRequest(id, errors);
            SLMajor.GetMajorDetailResponse response = SLMajor.GetMajorDetail(request);
            SLMajor.Major newMajor = response.GetMajorDetailResult;
            //System.Diagnostics.Debug.WriteLine("newStudent value: " + newStudent.ToString());
            System.Diagnostics.Debug.WriteLine("response: " + response.GetMajorDetailResult);
            // this is the data transfer object code...
            return DTO_to_PL(newMajor);
        }

        /// <summary>
        /// Get Major List
        /// </summary>
        /// <param name="deptName"></param>
        /// <returns>List</Scheduled></returns>
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

        /// <summary>
        /// this is data transfer object for Major.
        /// Converting from presentation layer Major object to business layer Major object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static PLMajor DTO_to_PL(SLMajor.Major m)
        {
            PLMajor myMajor = new PLMajor();

            myMajor.major_id = m.id;
            myMajor.major_name = m.majorName;
            myMajor.dept_id = m.deptId;

            return myMajor;
        }

        /// <summary>
        /// this is data transfer object for Major.
        /// Converting from presentation layer Major object to business layer Major object
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Major</returns>
        private static SLMajor.Major DTO_to_SL(PLMajor m)
        {
            SLMajor.Major SLMajor = new SLMajor.Major();
            SLMajor.id = m.major_id;
            SLMajor.majorName = m.major_name;
            SLMajor.deptId = m.dept_id;

            return SLMajor;
        }
    }
}