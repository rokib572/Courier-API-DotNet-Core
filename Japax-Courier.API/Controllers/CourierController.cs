using System;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier.API.ReturnResponseModel;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Microsoft.AspNetCore.Hosting;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.Clients;
using Japax_Courier.API.CommonModel;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/Request")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private RClient RequestClient = new RClient();
        private ASClient AssignmentClient = new ASClient();
        public CourierController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Send Request for Pickup
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /PickupRequest
        ///     {
        ///            "RequestInfo": {
        ///              "TrackingId" : "",
        ///              "SenderId": 6,
        ///              "RequestTypeId": 2,
        ///              "RequestDate": "2020-12-01T09:33:58.340Z",
        ///              "PickupBefore": "2020-12-01T09:33:58.340Z",
        ///              "DeliveryBefore": "2020-12-01T09:33:58.340Z",
        ///              "SenderMobileNo": "+8801915557626",
        ///              "SenderFirstName": "Rokib",
        ///              "SenderLastName": "Hassan",
        ///              "AtcPickupPoint" : 1,
        ///              "PickupAreaId" : 4,
        ///              "PickupAddress1": "The Gem",
        ///              "PickupAddress2": "1453 Zakir Hossain Road",
        ///              "PickupHouseOrRoad": "",
        ///              "PickupStreet": "",
        ///              "PickupPostalCode": "4000",
        ///              "PickupLandMark": "Opposite of MES College",
        ///              "SenderLat": 22.29845,
        ///              "SenderLang": 91.25478,
        ///              "AtcDeliveryPoint" : 1,
        ///              "PGeocodingStatus": 1,
        ///              "ReceiverMobileNo": "+8801676058183",
        ///              "ReceiverFirstName": "Milter",
        ///              "ReceiverLastName": "Boss",
        ///              "ReceiverAreaId": 6,
        ///              "ReceiverAddress1": "Lane 1, Road 1, Sonali R/A",
        ///              "ReceiverAddress2": "Halishahar K Block",
        ///              "ReceiverHouseOrRoad": "House 4",
        ///              "ReceiverStreet": "",
        ///              "ReceiverPostalCode": "4236",
        ///              "ReceiverLandMark": "",
        ///              "ReceiverLat": 22.89578,
        ///              "ReceiverLong": 91.65248,
        ///              "RGeocodingStatus": 1,
        ///              "PickupCharge" : 20,
        ///              "DeliveryCharge" : 50,
        ///              "DestinationId" : 2,
        ///              "DestinationCharge" : 50,
        ///              "ChargeAmountPayBy": 2,
        ///              "ChargeAmount": 150
        ///            },
        ///            "ProductDetails": [
        ///              {
        ///                "SlNo" : 1,
        ///                "ProductCode": "P001245",
        ///                "ProductDescription": "1 Box Milter",
        ///                "ProductImage": "/images/milter.jpeg",
        ///                "PackageChargeId": 1,
        ///                "PackageCharge" : 30,
        ///                "ProductTypeId": 1,
        ///                "HandlingCharge": 20,
        ///                "ExtraPackagingId" : 1,
        ///                "ExtraPackagingCharge": 20,
        ///                "GiftWrappingId": 1,
        ///                "WrappingCharge": 20,
        ///                "InsuranceId": 0,
        ///                "InsuranceCharge": 0,
        ///                "PackageWidth": 1,
        ///                "PackageHeight":1,
        ///                "PackageLength":1,
        ///                "PackageDimensionUM":"in",
        ///                "PackageWeight":5,
        ///                "PacakgeWeightUM":"kg"
        ///             }
        ///           ],
        ///           "AcknowledgeByIn": 0
        ///     }
        /// </remarks>
        [Route("PickupRequest")]
        [HttpPost]
        [ProducesResponseType(typeof(RequestPickupResponse), 200)]
        public async Task<PayLoadModel> AddRequest([FromBody] PayLoadModel _Request)
        {
            RClient RequestClient = new RClient();
            return await RequestClient.AddRequest(_Request);
        }

        /// <summary>
        /// Send Request for Pickup
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /UpdatePickupRequest
        ///     {
        ///            "RequestInfo": {
        ///              "RequestId": 6,
        ///              "TrackingId" : "",
        ///              "SenderId": 6,
        ///              "RequestTypeId": 2,
        ///              "RequestDate": "2020-12-01T09:33:58.340Z",
        ///              "PickupBefore": "2020-12-01T09:33:58.340Z",
        ///              "DeliveryBefore": "2020-12-01T09:33:58.340Z",
        ///              "SenderMobileNo": "+8801915557626",
        ///              "SenderFirstName": "Rokib",
        ///              "SenderLastName": "Hassan",
        ///              "AtcPickupPoint" : 1,
        ///              "PickupAreaId" : 4,
        ///              "PickupAddress1": "The Gem",
        ///              "PickupAddress2": "1453 Zakir Hossain Road",
        ///              "PickupHouseOrRoad": "",
        ///              "PickupStreet": "",
        ///              "PickupPostalCode": "4000",
        ///              "PickupLandMark": "Opposite of MES College",
        ///              "SenderLat": 22.29845,
        ///              "SenderLang": 91.25478,
        ///              "AtcDeliveryPoint" : 1,
        ///              "PGeocodingStatus": 1,
        ///              "ReceiverMobileNo": "+8801676058183",
        ///              "ReceiverFirstName": "Milter",
        ///              "ReceiverLastName": "Boss",
        ///              "ReceiverAreaId": 6,
        ///              "ReceiverAddress1": "Lane 1, Road 1, Sonali R/A",
        ///              "ReceiverAddress2": "Halishahar K Block",
        ///              "ReceiverHouseOrRoad": "House 4",
        ///              "ReceiverStreet": "",
        ///              "ReceiverPostalCode": "4236",
        ///              "ReceiverLandMark": "",
        ///              "ReceiverLat": 22.89578,
        ///              "ReceiverLong": 91.65248,
        ///              "RGeocodingStatus": 1,
        ///              "PickupCharge" : 20,
        ///              "DeliveryCharge" : 50,
        ///              "DestinationId" : 2,
        ///              "DestinationCharge" : 50,
        ///              "ChargeAmountPayBy": 2,
        ///              "ChargeAmount": 150
        ///            },
        ///            "ProductDetails": [
        ///              {
        ///                "SlNo" : 1,
        ///                "RequestId" : 6,
        ///                "ProductCode": "P001245",
        ///                "ProductDescription": "1 Box Milter",
        ///                "ProductImage": "/images/milter.jpeg",
        ///                "PackageChargeId": 1,
        ///                "PackageCharge" : 30,
        ///                "ProductTypeId": 1,
        ///                "HandlingCharge": 20,
        ///                "ExtraPackagingId" : 1,
        ///                "ExtraPackagingCharge": 20,
        ///                "GiftWrappingId": 1,
        ///                "WrappingCharge": 20,
        ///                "InsuranceId": 0,
        ///                "InsuranceCharge": 0,
        ///                "PackageWidth": 1,
        ///                "PackageHeight":1,
        ///                "PackageLength":1,
        ///                "PackageDimensionUM":"in",
        ///                "PackageWeight":5,
        ///                "PackageWeightUM":"kg"
        ///             }
        ///           ]
        ///     }
        /// </remarks>
        /// 
        [Route("UpdatePickupRequest")]
        [HttpPost]
        [ProducesResponseType(typeof(RequestPickupResponse), 200)]
        public async Task<PayLoadModel> UpdateRequest([FromForm]  UpdateReqeustPayloadModel _Request)
        {
            RClient RequestClient = new RClient();

            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/Products/";// Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            List<string> FileList = new List<string>();

            var ProductImages = _Request.ProductImage;

            if (ProductImages != null)
            {
                foreach (IFormFile ProductImage in ProductImages)
                {
                    if (ProductImage.Length > 0)
                    {
                        string FileName = ProductImage.FileName.Substring(0, ProductImage.FileName.Length - 4);
                        FileList.Add(FileName);

                        using (var fileStream = new FileStream(rootpath + FileName + ".jpg", FileMode.Create))
                        {
                            ProductImage.CopyTo(fileStream);
                        }
                    }
                }
            }
            return await RequestClient.UpdateRequest(_Request, FileList);
        }

        /// <summary>
        ///  ADD Product Image. [File Naming : {RequestId}_{ProductSL}_{ImageSL}]
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /AddProductImage
        ///     [
        ///         {
        ///           "RequestId": 3,
        ///           "ProductSL": 1,
        ///           "ProductImage": null,
        ///           "TrackingNumber":"TrackingNumber"
        ///         },
        ///         {
        ///           "RequestId": 3,
        ///           "ProductSL": 2,
        ///           "ProductImage": null,
        ///           "TrackingNumber":"TrackingNumber"
        ///         }
        ///      ]
        /// </remarks>
        /// 
        [Route("AddProductImage")]
        [HttpPost]
        [ProducesResponseType(typeof(CommonResponseModel), 200)]
        public async Task<PayLoadModel> AddProductImage([FromForm] AddProductImageModel Request)
        {
            RClient RequestClient = new RClient();

            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/Products/";// Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            List<string> FileList = new List<string>();

            var ProductImages = Request.ProductImage;

            if (ProductImages != null)
            {
                foreach (IFormFile ProductImage in ProductImages)
                {
                    if (ProductImage.Length > 0)
                    {
                        string FileName = ProductImage.FileName.Substring(0, ProductImage.FileName.Length - 4);
                        FileList.Add(FileName);

                        using (var fileStream = new FileStream(rootpath + FileName + ".jpg", FileMode.Create))
                        {
                            ProductImage.CopyTo(fileStream);
                        }
                    }
                }

                return await RequestClient.AddProductImage(Request, FileList);
            } else
            {
                PayLoadModel Response = new PayLoadModel
                {
                    SenderID = "1",
                    PayLoad = JsonConvert.SerializeObject(new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "535",
                            InnerException = "",
                            Message = "No Image found",
                            StackTrace = ""
                        }
                    })
                };

                return await Task.FromResult(Response);
            }            
        }

        /// <summary>
        /// Update User Profile
        /// </summary>
        /// <param name="_Request">
        ///     CancelledBy : [1 = Cancelled By User | 2 = Cancelled By Admin]
        /// </param>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /CancelRequest
        ///     {
        ///         "RequestIds": "1",
        ///         "CancelReason": "Cancel Reason",
        ///         "CancelledBy": 1,
        ///         "CancelledUserId": 1,
        ///     }
        /// </remarks>
        [Route("CancelRequest")]
        [HttpPost]
        public async Task<PayLoadModel> CancelRequest([FromBody] PayLoadModel _Request)
        {
            RClient RequestClient = new RClient();
            return await RequestClient.CancelRequest(_Request);
        }

        /// <summary>
        /// Calculate Shipping Rate
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /CalculateRate
        ///     {
        ///         "RequestTypeId": 1,
        ///         "PickupOutletId": 1,
        ///         "DropOutletId": 1,
        ///         "SenderAreaId": 4,
        ///         "ReceiverAreaId": 2,
        ///         "ProductDetails": [{
        ///             "PackageChargeId": 1,
        ///             "ProductTypeId": 1,
        ///             "PackageLength": 1.0,
        ///             "PackageHeight": 1.0,
        ///             "PackageWidth": 1.0,
        ///             "PackageDimensionUM": "in",
        ///             "PackageWeight": 5,
        ///             "PackageWeightUM": "kg",
        ///             "ExtraPackagingId": 0,
        ///             "GiftWrapId": 0,
        ///             "InsuranceId": 0,
        ///         }]        
        ///     }
        /// </remarks>
        [Route("CalculateRate")]
        [HttpPost]
        [ProducesResponseType(typeof(CalculateChargeResponseModel), 200)]
        public async Task<PayLoadModel> CalculateRate([FromBody] PayLoadModel _Request)
        {
            RClient RequestClient = new RClient();
            return await RequestClient.CalculateRate(_Request);
        }

        /// <summary>
        /// Calculate Shipping Rate
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /CalculateRate
        ///     {
        ///         "RequestTypeId": 1,
        ///         "PickupOutletId": 1,
        ///         "DropOutletId": 1,
        ///         "SenderAreaId": 4,
        ///         "ReceiverAreaId": 2,
        ///         "RequestBefore" : "09:33:58.340",
        ///         "ProductDetails": [{
        ///             "PackageChargeId": 1,
        ///             "ProductTypeId": 1,
        ///             "PackageLength": 1.0,
        ///             "PackageHeight": 1.0,
        ///             "PackageWidth": 1.0,
        ///             "PackageDimensionUM": "in",
        ///             "PackageWeight": 5,
        ///             "PackageWeightUM": "kg",
        ///             "ExtraPackagingId": 0,
        ///             "GiftWrapId": 0,
        ///             "InsuranceId": 0,
        ///         }]        
        ///     }
        /// </remarks>
        [Route("CalculateRateV2")]
        [HttpPost]
        [ProducesResponseType(typeof(CalculateChargeResponseModelV2), 200)]
        public async Task<PayLoadModel> CalculateRateV2([FromBody] PayLoadModel _Request)
        {
            RClient RequestClient = new RClient();
            return await RequestClient.CalculateRateV2(_Request);
        }

        /// <summary>
        /// Get Static Data Set
        /// </summary>
        [Route("GetStaticData")]
        [HttpGet]
        [ProducesResponseType(typeof(GetRomDBResponse), 200)]
        public async Task<PayLoadModel> GetStaticData(DateTime LatestDate, int ActiveStatus, string SenderId)
        {
            UClient UserInfoClient = new UClient();
            return await UserInfoClient.GetRomDB(LatestDate, ActiveStatus, SenderId);
        }

        /// <summary>
        /// Revoke All Assignment of a Request ID
        /// </summary>
        [Route("RevokeAssignment")]
        [HttpGet]
        public async Task<CommonResponseModel> RevokeAssignment(long RequestId)
        {            
            return await AssignmentClient.RevokeAssignment(RequestId);
        }

        /// <summary>
        /// Change Delivery Hero for a request
        /// </summary>
        [Route("OverrideAssignment")]
        [HttpPost]
        public async Task<CommonResponseModel> OverrideAssignment(AssignRequestModel OverrideRequest)
        {
            return await AssignmentClient.OverrideAssignment(OverrideRequest);
        }

        /// <summary>
        /// Change Delivery Hero for a request
        /// </summary>
        /// <param name="SenderId">
        ///     SenderId
        /// </param>
        /// <param name="Condition">
        ///     Condition:
        ///         1 = Show All <br></br>
        ///         2 = Show Deliered Data <br></br>
        ///         3 = Delivery Pending Data <br></br>
        ///         4 = Cancelled Data <br></br>
        ///         5 = Complained By Sender <br></br>
        ///         6 = Complained By Receiver <br></br>
        /// </param>
        /// <param name="PageNumber">
        ///     Current Page nubmer. Default = 1
        /// </param>
        [Route("GetUserRequests")]
        [HttpGet]
        public async Task<PayLoadModel> GetUserRequests(long SenderId, byte Condition, int PageNumber = 1)
        {
            RClient RequestClient = new RClient();

            return await RequestClient.GetUserRequests(SenderId, Condition, PageNumber);
        }

        /// <summary>
        /// Get Product details of Request
        /// </summary>
        [Route("GetProductDetails")]
        [HttpGet]
        public async Task<ProductDetailsResponseModel> GetProductDetails(long RequestId)
        {
            RClient RequestClient = new RClient();
            return await RequestClient.GetProductDetailsByRequestId(RequestId);
        }

        [Route("GetTrackingDetails")]
        [HttpGet]
        public async Task<TrackingDetailsResponseModel> GetTrackingDetails(string TrackingId)
        {
            return await RequestClient.GetTrackingDetails(TrackingId);
        }
    }
}
