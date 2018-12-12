using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFlo.Services.ApiHandler
{
    public class Get_API_Url
    {
        public string CommonBaseApi(string BaseUsrl)
        {
            return BaseUsrl;
        }

        public string CreateMobileNumberApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for Login Users
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns>BaseUsrl</returns>
        public string GetCountryListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }

        public string SetCurrentPosition(string BaseUsrl)
        {
            return BaseUsrl;
        }
       
        /// <summary>
        /// for forgot Password
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string ForgotPasswordApi(string BaseUsrl)
        {
            return BaseUsrl;
        }

        /// <summary>
        /// for driver worksheet List
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string GetStatus(string BaseUsrl, string ScanCode)
        {
            return string.Format("{0}/{1}", BaseUsrl, ScanCode);
        }

        public string GetInvoice(string BaseUsrl, string cellphone)
        {
            return string.Format("{0}/{1}", BaseUsrl, cellphone);
        }

        public string GetInnerInvoice(string BaseUsrl, string cellphone,string date)
        {
            return string.Format("{0}/{1}/{2}", BaseUsrl, cellphone,date);
        }

        /// <summary>
        /// for driver dailyCheckList Get Request
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>?WorkOutId={WorkOutId}
        public string ExerciseDetailByWorkoutIDApi(string BaseUsrl,int WorkOutId)
        {
            return string.Format("{0}?WorkOutId={1}", BaseUsrl, WorkOutId);
        }
        /// <summary>
        /// Driver Signature
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string ScheduleDetailsApi(string BaseUsrl, int ScheduleId)
        {
            return string.Format("{0}?ScheduleId={1}", BaseUsrl, ScheduleId);
        }

        /// <summary>
        /// for submiting the daily CheckList data
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string ExerciseScheduleDetailsApi(string BaseUsrl, int ScheduleId)
        {
            return string.Format("{0}?ScheduleId={1}", BaseUsrl, ScheduleId);
        }
        /// <summary>
        /// for vehicle list
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string VehicleListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for worksheetdetails
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string WorksheetDetailsGetApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for geeting the load types
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string GetLoadTypesApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for getting the toll list
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string GetTollsListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// Load Add Api
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string AddNewLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string EditLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string UpdateLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        //
        //public string UpdateUserApi(string BaseUrl,int UserId)
        //{
        //    return string.Format("{0}{1}", BaseUrl, UserId);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string LoadOffC_SignatureApi(string BaseUrl)
        {
            return  BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string WorkSheetSignOffSignApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_MaintananceListApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_AddMaintananceApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
       public string Driver_HomeApi(string BaseUrl)
       {
            return BaseUrl;
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_TimeSheetApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_ChangePasswordApi(string BaseUrl)
        {
            return BaseUrl;
        }
    }
}
