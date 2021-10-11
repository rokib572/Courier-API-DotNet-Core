using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Japax_Courier.API.CommonModel;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[Controller]")]
    [ApiController]
    public class DeliveryHeroController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DeliveryHeroController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        private DClient DeliveryHeroClient = new DClient();

        /// <summary>
        /// Add Delivery Hero Info
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /AddNewDH
        ///		{
        ///	  		"DhCode": "ATC-015",
        ///	  		"DhFirstName": "The",
        ///	  		"DhMiddleName": "Milter",
        ///	  		"DhLastName": "Boss",
        ///	  		"DhMobNo": "+8801234567891",
        ///	  		"DhPassword": "Password",
        ///	  		"DhType": 0,
        ///	  		"AssignTeam": 0,
        ///	  		"DefaultAssignRole": 0,
        ///	  		"TransportType": "Motor Cycle",
        ///	  		"TransportDescription": "ATC Vehicle 012",
        ///	  		"LicencePlate": "CM GHA - 0120",
        ///	  		"TransportColor": "Red",
        ///	  		"DhStatus": 0,
        ///	  		"DhNationality": "Bangladeshi",
        ///	  		"DhNid": "01234567891234567",
        ///	  		"DhEmailAddr": "the_milter_boss_420@gmail.com",
        ///	  		"PermenantAddress": "Permanent Address",
        ///	  		"HouseNoPmt": "Permenant House No",
        ///	  		"StreetPmt": "Permanent Street Address",
        ///	  		"PsUpazlaIdPmt": 2,
        ///	  		"AreaIdPmt": 4,
        ///	  		"PostalCodePmt": "4000",
        ///	  		"LocationPmt": "Permanent Location",
        ///	  		"PresentAddress": "Present Address",
        ///	  		"HouseNoPr": "Present House No",
        ///	  		"StreetPr": "Present Street Address",
        ///	  		"PsUpazlaIdPr": 1,
        ///	  		"AreaIdPr": 5,
        ///	  		"PostalCodePr": "4100",
        ///	 		"LocationPr": "Present Location",
        ///	  		"EmergencyMobNo": "+88019876543217",
        ///	  		"JoiningDate": "1900-01-01T00:00:00",
        ///	  		"UserId": 0
        ///		}
        /// </remarks>
        [Route("AddNewDH")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewDH([FromForm] DeliveryHeroInfoModel DhData)
        {
            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/DhImage/";
            string filename = "";
            DhInfoRequestModel DhInfo = null;

            try
            {
                DhInfo = JsonConvert.DeserializeObject<DhInfoRequestModel>(DhData.PayLoad);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "515",
                        InnerException = "",
                        Message = "Invalid Payload",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }

            var profileImage = DhData.ProfileImage;
            if (profileImage != null)
            {
                if (profileImage.Length > 0)
                {
                    filename = Guid.NewGuid().ToString() + ".jpg";
                    using (var fileStream = new FileStream(rootpath + filename, FileMode.Create))
                    {
                        profileImage.CopyTo(fileStream);
                    }
                }
            }

            if (filename != "")
            {
                DhInfo.DhImage = "/Images/DhImage/" + filename;
            }
            return await DeliveryHeroClient.AddNewDH(DhInfo);
        }

        /// <summary>
        /// Update Delivery Hero Info
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /UpdateDH
        ///		{
        ///		    "dhId": 2,
        ///	  		"dhCode": "ATC-020",
        ///	  		"dhFirstName": "The",
        ///	  		"dhMiddleName": "Milter",
        ///	  		"dhLastName": "Boss",
        ///	  		"dhMobNo": "+8801234567891",
        ///	  		"dhPassword": "Password",
        ///	  		"dhType": 0,
        ///	  		"assignTeam": 0,
        ///	  		"defaultAssignRole": 0,
        ///	  		"transportType": "Motor Cycle",
        ///	  		"transportDescription": "ATC Vehicle 012",
        ///	  		"licencePlate": "CM GHA - 0120",
        ///	  		"transportColor": "Red",
        ///	  		"dhStatus": 0,
        ///	  		"dhNationality": "Bangladeshi",
        ///	  		"dhNid": "01234567891234567",
        ///	  		"dhEmailAddr": "the_milter_boss_420@gmail.com",
        ///	  		"permenantAddress": "Permanent Address",
        ///	  		"houseNoPmt": "Permenant House No",
        ///	  		"streetPmt": "Permanent Street Address",
        ///	  		"psUpazlaIdPmt": 2,
        ///	  		"areaIdPmt": 4,
        ///	  		"postalCodePmt": "4000",
        ///	  		"locationPmt": "Permanent Location",
        ///	  		"presentAddress": "Present Address",
        ///	  		"houseNoPr": "Present House No",
        ///	  		"streetPr": "Present Street Address",
        ///	  		"psUpazlaIdPr": 1,
        ///	  		"areaIdPr": 5,
        ///	  		"postalCodePr": "4100",
        ///	 		"locationPr": "Present Location",
        ///	  		"emergencyMobNo": "+88019876543217",
        ///	  		"joiningDate": "0001-01-01T00:00:00",
        ///	  		"userId": 0
        ///		}
        /// </remarks>
        [Route("UpdateDH")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateDH([FromForm] DeliveryHeroInfoModel DhData)
        {
            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/DhImage/";
            string filename = "";

            DhInfoRequestModel DhInfo = null;

            try
            {
                DhInfo = JsonConvert.DeserializeObject<DhInfoRequestModel>(DhData.PayLoad);
            }
            catch
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "515",
                        InnerException = "",
                        Message = "Invalid Payload",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }

            var ProfileImage = DhData.ProfileImage;
            if (ProfileImage != null)
            {
                if (ProfileImage.Length > 0)
                {
                    filename = Guid.NewGuid().ToString() + ".jpg";
                    using (var fileStream = new FileStream(rootpath + filename, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }
                }
            }

            if (filename != "")
            {
                DhInfo.DhImage = "/Images/DhImage/" + filename;
            }
            return await DeliveryHeroClient.UpdateDH(DhInfo);
        }

        /// <summary>
        /// Deactivate Delivery Hero Account
        /// </summary>
        /// <param name="DhId">
        ///     Delivery Hero ID
        /// </param>
        /// <param name="UserId">
        ///     User ID
        /// </param>
        [Route("DeactivateDH")]
        [HttpGet]
        public async Task<CommonResponseModel> DeactivateDH(long DhId, int UserId)
        {
            return await DeliveryHeroClient.DeactivateDH(DhId, UserId);
        }

        /// <summary>
        /// Deactivate Delivery Hero Account
        /// </summary>
        /// <param name="OptId">
        ///     OptId => 1 = All | 2 = Active Only
        /// </param>
        /// <param name="PageNumber">
        ///     Page Number. Default = 1
        /// </param>
        [Route("GetDHList")]
        [HttpGet]
        public async Task<DeliveryHeroInfoResponseModel> GetDHList(int OptId, int PageNumber = 1)
        {
            return await DeliveryHeroClient.GetDHList(OptId, PageNumber);
        }

        /// <summary>
        /// Deactivate Delivery Hero Account
        /// </summary>
        /// <param name="DhId">
        ///     Delivery Hero Id
        /// </param>
        [Route("GetDhById")]
        [HttpGet]
        public async Task<DeliveryHeroInfoResponseModel> GetDhById(long DhId)
        {
            return await DeliveryHeroClient.GetDhById(DhId);
        }

        /// <summary>
        /// Activate Delivery Hero Account
        /// </summary>
        /// <param name="DhId">
        ///     Delivery Hero ID
        /// </param>
        /// <param name="UserId">
        ///     User ID
        /// </param>
        [Route("ActivateDH")]
        [HttpGet]
        public async Task<CommonResponseModel> ActivateDH(long DhId, int UserId)
        {
            return await DeliveryHeroClient.ActivateDH(DhId, UserId);
        }

        /// <summary>
        /// Change Delivery Hero Status
        /// </summary>
        /// <param name="Status">
        ///     Status : [0 = Idle | 1 = In-Transit | 2 = Offline | 3 = Blocked | 4 = Inactive]
        /// </param>
        /// <param name="DhId">
        ///     Delivery Hero ID
        /// </param>
        [Route("ChangeDhStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeDhStatus(long DhId, byte Status)
        {
            return await DeliveryHeroClient.ChangeDHStatus(DhId, Status);
        }

        /// <summary>
        /// Update Delivery location
        /// </summary>
        [Route("UpdateDhLocation")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateDhLocation(long DhId, decimal Latitude, decimal Longitude)
        {
            return await DeliveryHeroClient.UpdateDhLocation(DhId, Latitude,Longitude);
        }

        /// <summary>
        /// Delivery Hero Login
        /// </summary>
        [Route("LoginDh")]
        [HttpGet]
        public async Task<DhProfileResponseModel> LoginDh(string DhPhone, string DhPassword, string FcmToken, string DeviceId)
        {
            return await DeliveryHeroClient.LoginDh(DhPhone, DhPassword, FcmToken, DeviceId);
        }

        /// <summary>
        /// Change Delivery Hero Password
        /// </summary>
        [Route("ChangeDhPassword")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeDhPassword(string DhPhone, string DhPassword)
        {
            return await DeliveryHeroClient.ChangeDhPassword(DhPhone, DhPassword);
        }

        /// <summary>
        /// Get List of Assigned Request of Delivery Hero
        /// </summary>
        /// <param name="Condition">
        ///     Status : [1 = Show Pending Assignments | 2 = Show WIP Assignments | 3 = Show Completed Assignments]
        /// </param>
        /// <param name="DhId">
        ///     Delivery Hero Id
        /// </param>
        /// <param name="ByManifest">
        ///     0 = Assignment without Manifest <br></br>
        ///     1 = Assignment with Manifest
        /// </param>
        /// <param name="PageNumber">
        ///     Page Number (Optional)
        /// </param>
        [Route("GetDhAssignments")]
        [HttpGet]
        public async Task<DhAssignmentResponseModel> GetDhAssignments(long DhId, byte Condition, byte ByManifest, int PageNumber = 1)
        {
            return await DeliveryHeroClient.GetDhAssignmentDetails(DhId, Condition, ByManifest, PageNumber);
        }

        /// <summary>
        /// Get List of Assigned Request of Delivery Hero
        /// </summary>
        /// <param name="AssignIds">
        ///     Comma Separate for multiple Assignments
        /// </param>
        /// <param name="OperationId">
        ///     1=ACCEPT <br></br> 
        ///     2=ON THE WAY <br></br> 
        ///     3=PICKED UP <br></br> 
        ///     4=DELIVERY TO CUSTOMER BY DELIVERY HERO OR FROM ATC POINT AFTER ACKNOWLEDGE BY RECEIVER USING OTP VERIFICAION <br></br> 
        ///     5=DROP <br></br> 
        ///     6=ACKNOWLEDGE BY ATC POINT DURING IN
        /// </param>
        /// <param name="AcknowledgeByIn">
        ///     Acknowledge By only after drop at ATC Point. AcknowledgeBy ATC Point Id. <br></br>
        ///     Default Value = 0
        /// </param>
        /// <param name="AcknowledgeByOut">
        ///     Only when customer collect from ATC Point (Only from admin panel. No need to send from Delivery Hero App) <br></br>
        ///     Default Value = 0
        /// </param>
        /// <param name="AtcPointId">
        ///     Only when customer collect from ATC Point (Only from admin panel. No need to send from Delivery Hero App) <br></br>
        ///     Default Value = 1
        /// </param>
        /// <param name="RequestIds">
        ///     For multiple Request Id please comma separate. <br></br> Only when customer collect from ATC Point (Only from admin panel. No need to send from Delivery Hero App)
        ///     <br></br> Default Value = ""
        /// </param>
        /// <param name="ManifestId">
        ///     If Assignment uses Manifest Id (Optional)
        /// </param>
        [Route("UpdateAssignmentStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdateAssignmentStatus(string AssignIds, byte OperationId, string RequestIds="", int AtcPointId=1, int AcknowledgeByOut = 0, int AcknowledgeByIn = 0, long ManifestId = 1)
        {
            return await DeliveryHeroClient.UpdateAssignmentStatus(AssignIds, RequestIds, AtcPointId, AcknowledgeByOut, OperationId, AcknowledgeByIn, ManifestId);
        }
    }
}
