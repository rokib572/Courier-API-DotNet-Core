using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Newtonsoft.Json;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class SenderAddressResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayLoadModel PayLoad { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SenderAddressModel AddressResposne { get; set; }
    }
}
