using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier_DB;
using Japax_Courier.API.ReturnResponseModel;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.Clients;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[Controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// Get User Profile.
        /// </summary>
        /// <remarks>
        ///     Payload will return encrypted Sender Address
        /// </remarks>
        [Route("GetSenderAddressesById")]
        [HttpGet]
        [ProducesResponseType(typeof(SenderAddressResponse), 200)]
        public async Task<PayLoadModel> GetSenderAddressesById([FromQuery] string SenderId)
        {
            //string reqHeader = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            AClient AddressClient = new AClient();
            return await AddressClient.GetSenderAddressById(SenderId);
        }

        /// <summary>
        /// Adds a sender Address
        /// </summary>
        /// <param name="_payloadModel"></param>
        /// <returns></returns>
        ///<remarks>
        ///Sample Request:
        ///     
        ///     POST /AddSenderAddress
        ///     {
        ///         "SenderId": 10,
        ///         "AddressType": "office",
        ///         "AddressLine1": "123 , CDA Avenue",
        ///         "AddressLine2": "Chittagong",
        ///         "HouseOrRoadNo": "1 no street",
        ///         "street": "CDA",
        ///         "AreaId": 1,
        ///         "PostalCode": "a",
        ///         "Landmark": "a",
        ///         "LatitudesData": 22.012145,
        ///         "LongitudesData": 91.625478,
        ///         "EntryDate": "2020-11-04 09:11:09.807",
        ///         "EnteredBy": "a",
        ///     }
        /// </remarks>

        [Route("AddSenderAddress")]
        [HttpPost]
        [ProducesResponseType(typeof(SenderAddressResponse), 200)]
        public async Task<PayLoadModel> AddSenderAddress([FromBody] PayLoadModel _payloadModel)
        {
            AClient AddressClient = new AClient();
            return await AddressClient.AddSenderAddress(_payloadModel);
        }

        /// <summary>
        ///  Updates a sender Address
        /// </summary>
        /// <param name="_payloadModel"></param>
        /// <returns></returns>
        ///<remarks>
        ///Sample Request:
        ///     
        ///     POST /UpdateSenderAddress
        ///     {
        ///         "Id":4,
        ///         "SenderId": 10,
        ///         "AddressType": "office",
        ///         "AddressLine1": "123 , CDA Avenue",
        ///         "AddressLine2": "Chittagong",
        ///         "HouseOrRoadNo": "1 no street",
        ///         "Street": "CDA",
        ///         "AreaId": 1,
        ///         "PostalCode": "a",
        ///         "Landmark": "a",
        ///         "LatitudesData": 22.012145,
        ///         "LongitudesData": 91.625478,
        ///         "ActiveStatus":1
        ///         "EntryDate": "2020-11-04 09:11:09.807",
        ///         "EnteredBy": "a"
        ///     }
        /// </remarks>

        [Route("UpdateSenderAddress")]
        [HttpPost]
        [ProducesResponseType(typeof(SenderAddressResponse), 200)]
        public async Task<PayLoadModel> UpdateSenderAddress([FromBody] PayLoadModel _payloadModel)
        {
            AClient AddressClient = new AClient();
            return await AddressClient.UpdateSenderAddress(_payloadModel);
        }

        /// <summary>
        ///  Delete a sender Address
        /// </summary>
        /// <param name="AddressId"></param>
        /// <param name="SenderID"></param>
        /// <returns></returns>
        [Route("DeactivateAddress")]
        [HttpGet]
        [ProducesResponseType(typeof(CommonResponse), 200)]
        public async Task<PayLoadModel> DeleteSenderAddress(long AddressId, string SenderID)
        {
            AClient AddressClient = new AClient();
            return await AddressClient.DeactivateAddress(AddressId, SenderID);
        }

        /// <summary>
        ///  Get Address From Latitude and Longitude
        /// </summary>
        /// <param name="SenderId">
        ///     Sender ID
        /// </param>
        /// <param name="Latitude">
        ///     Latitude of Location
        /// </param>
        /// <param name="Longitude">
        ///     Longitude of Location 
        /// </param>
        /// <returns></returns>
        [Route("GetAddressFromGeocode")]
        [HttpGet]
        [ProducesResponseType(typeof(SenderAddressResponse), 200)]
        public async Task<PayLoadModel> GetAddressFromGeocode(long SenderId, float Latitude, float Longitude)
        {
            AClient AddressClient = new AClient();
            return await AddressClient.GetAddressFromGeoCode(SenderId, Latitude, Longitude);
        }
    }
}
