using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class CalculateChargeResponseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CalculateChargeResponse Charge { get; set; }
    }

    public class CalculateChargeResponseModelV2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CalculateChargeResponseV2 Charge { get; set; }
    }
}
