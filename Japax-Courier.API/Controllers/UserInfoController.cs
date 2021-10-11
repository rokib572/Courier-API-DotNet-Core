using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier_DB;
using Japax_Courier_DB.DBModels.Auth.Models;
using Japax_Courier.API.CommonModel;
using Japax_Courier.API.ReturnResponseModel;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Japax_Courier_DB.Clients;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserInfoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// Check if User is Registered
        /// </summary>
        [Route("IsUserRegistered")]
        [HttpPost]
        public async Task<UserVerificationResponseModel> IsUserRegistered([FromBody] UserVerifyModel _UserVerifyModel)
        {
            UClient UserInfoClient = new UClient();
            return await UserInfoClient.VerifyUser(_UserVerifyModel);
        }
        /// <summary>
        /// Register a user
        /// </summary>
        [Route("RegisterUser")]
        [HttpPost]
        public async Task<UserRegistrationResponseModel> RegisterUser([FromBody] UserInfoModel _UserInfo)
        {
            UClient UserInfoClient = new UClient();
            return await UserInfoClient.RegisterUser(_UserInfo);
        }
        /// <summary>
        /// Get User Profile.
        /// </summary>
        /// <remarks>
        ///     Payload will return encrypted UserProfile Model
        /// </remarks>
        [Route("GetProfile")]
        [HttpGet]
        [ProducesResponseType(typeof(GetUserProfileResponse), 200)]
        public async Task<PayLoadModel> GetUserProfile(long SenderId)
        {
            //string reqHeader = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UClient UserInfoClient = new UClient();
            return await UserInfoClient.GetUserProfile(SenderId);
        }

        /// <summary>
        /// Update User Profile
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /UpdateProfile
        ///     {
        ///         "userMobileNo": null,
        ///         "userFirstName": null,
        ///         "userLastName": null,
        ///         "userEmail": null,
        ///         "profilePicture": null
        ///     }
        /// </remarks>
        [Route("UpdateProfile")]
        [HttpPost]
        [ProducesResponseType(typeof(UserVerificationResponseModel), 200)]
        public async Task<PayLoadModel> UpdateUserProfile([FromForm] UpdateUserPayloadModel _Payload)
        {
            UClient UserInfoClient = new UClient();

            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/ProfileImage/";// Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            string filename = "";

            var ProfileImage = _Payload.ProfileImage;
            if (ProfileImage != null)
            {
                if (ProfileImage.Length > 0)
                {
                    filename = _Payload.SenderID + ".jpg";
                    using (var fileStream = new FileStream(rootpath + filename, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }
                }
            }

            UserUpdatePaylod _UserUpdatePayload = new UserUpdatePaylod
            {
                PayLoad = _Payload.PayLoad,
                ProfilePicture = filename,
                SenderID = _Payload.SenderID
            };

            return await UserInfoClient.UpdateUserProfile(_UserUpdatePayload);
        }
    }
}
