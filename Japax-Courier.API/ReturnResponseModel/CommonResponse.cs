using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class CommonResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CommonResponseModel ResponseModel { get; set; }
    }
}
