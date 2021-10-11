using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier.API.CommonModel;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.Auth.Models;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class GetUserProfileResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UserProfileModel UserProfile { get; set; }
    }
}
