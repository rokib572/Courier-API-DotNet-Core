using Japax_Courier.API.CommonModel;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.RequestPayloadModel
{
    public class PickupPayLoadModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PickupRequestModel PickupRequestModel { get; set; }
    }
}
