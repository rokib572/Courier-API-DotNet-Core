using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class RequestPickupResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PickupRequestModel RequestResposne { get; set; }
    }
}
