using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier.API.CommonModel;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[Controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private MClient MerchantClient = new MClient();
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MerchantController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Register Merchant
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /RegisterMerchant
        ///     {
        ///         "RepresentativeMobileNo": "+88012345678915",
        ///         "RepresentativeFirstName": "Rokib",
        ///         "RepresentativeLastName": "Hassan",
        ///         "RepresentativeEmail": "rokib123@gmail.com",
        ///         "CompanyName": "ATC",
        ///         "WebsiteAddress": "atc.co.bd",
        ///         "CompanyLogo": "",
        ///         "FacebookPageLink": "facebook.com/atc",
        ///         "TwitterLink": "twitter.com/atc",
        ///         "OtherLink": "",
        ///         "TradeLicenseNo": 3214123,
        ///         "BinNo": 121323213,
        ///         "NationalIdNo": 1534246243,
        ///         "DrivingLicenseNo": "DR-1236522",
        ///         "Remarks": "Test",
        ///         "DeviceId": "1234567891234567",
        ///         "DeviceType": 0,
        ///         "FcmToken": "sfasdf16sdafsd51f5sd1f6asd",
        ///         "SecretKey": "1234567891234567",
        ///         "SenderType": 2,
        ///         "CourierApp": 1,
        ///         "RideshareApp": 0
        ///     }
        /// </remarks>
        [Route("RegisterMerchant")]
        [HttpPost]
        public async Task<CommonResponseModel> AddMerchant([FromForm] MerchantRegistrationUploadModel Request)
        {
            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/ProfileImage/";
            var ProfileImage = Request.ProfileImage;

            MerchantRegistrationRequestModel requestModel = JsonConvert.DeserializeObject<MerchantRegistrationRequestModel>(Request.PayLoad);

            if (ProfileImage != null)
            {
                if (ProfileImage.Length > 0)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    string FileName = requestModel.CompanyName.Replace(" ", "-") + "-"
                                        + unixTimestamp + ".jpg";

                    requestModel.CompanyLogo = FileName;

                    using (var fileStream = new FileStream(rootpath + FileName, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }
                }
            }

            return await MerchantClient.AddMerchant(requestModel);
        }

        /// <summary>
        /// Update Merchant
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /UpdateMerchant
        ///     {
        ///         "SenderId": 6,
        ///         "RepresentativeFirstName": "Rokib",
        ///         "RepresentativeLastName": "Hassan",
        ///         "RepresentativeEmail": "rokib123@gmail.com",
        ///         "CompanyName": "ATC",
        ///         "CompanyLogo": "",
        ///         "FacebookPageLink": "facebook.com/atc",
        ///         "TwitterLink": "twitter.com/atc",
        ///         "OtherLink": "",
        ///         "CreditLimit": 0,
        ///         "CreditLimitDays": 0,
        ///         "DefaultPaymentMethod": "",
        ///         "Remarks": ""
        ///     }
        /// </remarks>
        [Route("UpdateMerchant")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateMerchant([FromForm] MerchantUpdateModel Request)
        {
            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/ProfileImage/";
            var ProfileImage = Request.ProfileImage;

            MerchantUpdateRequestModel requestModel = JsonConvert.DeserializeObject<MerchantUpdateRequestModel>(Request.PayLoad);

            if (ProfileImage != null)
            {
                if (ProfileImage.Length > 0)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    string FileName = requestModel.CompanyName.Replace(" ", "-") + "-"
                                        + unixTimestamp + ".jpg";

                    requestModel.CompanyLogo = FileName;

                    using (var fileStream = new FileStream(rootpath + FileName, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }
                }
            }

            return await MerchantClient.UpdateMerchant(requestModel);
        }
    }
}
