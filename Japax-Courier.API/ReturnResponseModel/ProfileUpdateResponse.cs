using Japax_Courier.API.CommonModel;
using Japax_Courier_DB.DBModels.Auth.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class ProfileUpdateResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UpdateUserPayloadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UserProfileModel RequestResposne { get; set; }
    }
}
