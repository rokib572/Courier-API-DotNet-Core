using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier.API.CommonModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[Controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ADClient AdminClient = new ADClient();
        private ASClient AssignmentClient = new ASClient();
        private SMSClient SmsClient = new SMSClient();

        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Get Active Country List.
        /// </summary>
        [Route("GetActiveCountries")]
        [HttpGet]
        public async Task<CountryInfoModel> GetActiveCountries()
        {
            return await AdminClient.GetActiveCountries();
        }

        /// <summary>
        /// Get Country Details for Admin.
        /// </summary>
        [Route("GetCountryDetails")]
        [HttpGet]
        public async Task<CountryInfoModel> GetCountryDetails()
        {
            return await AdminClient.GetCountryDetails();
        }
        /// <summary>
        /// Get Sates By Country ID.
        /// </summary>
        [Route("GetStateByCountry")]
        [HttpGet]
        public async Task<ProvinceModel> GetStateByCountry(int CountryId)
        {
            return await AdminClient.GetStateByCountry(CountryId);
        }

        /// <summary>
        /// Get Sates Details for Admin.
        /// </summary>
        [Route("GetStateDetails")]
        [HttpGet]
        public async Task<ProvinceModel> GetStateDetails()
        {
            return await AdminClient.GetStateDetails();
        }
        /// <summary>
        /// Get City District By State ID.
        /// </summary>
        [Route("GetCityDistrictByState")]
        [HttpGet]
        public async Task<CityDistrictModel> GetCityDistrictByState(int StateId)
        {
            return await AdminClient.GetCityDistrictByState(StateId);
        }

        /// <summary>
        /// Get City/District Details for Admin.
        /// </summary>
        [Route("GetCityDistrictDetails")]
        [HttpGet]
        public async Task<CityDistrictModel> GetCityDistrictDetails()
        {
            return await AdminClient.GetCityDistrictDetails();
        }

        /// <summary>
        /// Get PS Upazila By District.
        /// </summary>
        [Route("GetPsUpazilaByDistrict")]
        [HttpGet]
        public async Task<UpazillaModel> GetPsUpazilaByDistrict(int CityDistrictId)
        {
            return await AdminClient.GetPsUpazilaByDistrict(CityDistrictId);
        }

        /// <summary>
        /// Get Area By Area ID.
        /// </summary>
        [Route("GetAreaById")]
        [HttpGet]
        public async Task<PickupAndDeliveryAreaModel> GetAreaById(int AreaId)
        {
            return await AdminClient.GetAreaById(AreaId);
        }

        /// <summary>
        /// Get Area By PS or Upazila ID.
        /// </summary>
        [Route("GetAreaByPsUpazilaId")]
        [HttpGet]
        public async Task<PickupAndDeliveryAreaModel> GetAreaByPsUpazilaId(int PsUpazilaId)
        {
            return await AdminClient.GetAreaByPsUpazila(PsUpazilaId);
        }

        /// <summary>
        /// Get Area By PS or Upazila Details for Admin.
        /// </summary>
        [Route("GetPsUpazillaDetails")]
        [HttpGet]
        public async Task<UpazillaModel> GetPsUpazillaDetails()
        {
            return await AdminClient.GetUpazillaDetails();
        }

        /// <summary>
        /// Get Area By City or District ID.
        /// </summary>
        [Route("GetAreaByCityDistrictId")]
        [HttpGet]

        public async Task<PickupAndDeliveryAreaModel> GetAreaByCityDistrictId (int CityDistrictId)
        {
            return await AdminClient.GetAreaByCityDistrictId(CityDistrictId);
        }
        /// <summary>
        /// Get Extra Packaging Types.
        /// </summary>
        [Route("GetExtraPackagingType")]
        [HttpGet]
        public async Task<ExtraPackagingTypeModel> GetExtraPackagingType()
        {
            return await AdminClient.GetExtraPackagingTypes();
        }

        /// <summary>
        /// Get Area Details for Admin.
        /// </summary>
        [Route("GetAreaDetails")]
        [HttpGet]
        public async Task<PickupAndDeliveryAreaModel> GetAreaDetails()
        {
            return await AdminClient.GetAreaDetails();
        }

        /// <summary>
        /// Get Questinaire for Feedback.
        /// </summary>
        [Route("GetFeedbackQuestionaire")]
        [HttpGet]
        public async Task<FeedbackQuestionaireInfoModel> GetFeedbackQuestionaire()
        {
            return await AdminClient.GetFeedbackQuestionaire();
        }

        /// <summary>
        /// Get Active Package Types.
        /// </summary>
        [Route("GetActivePackageTypes")]
        [HttpGet]
        public async Task<PackageWithChargeResponseModel> GetActivePackageTypes()
        {
            return await AdminClient.GetActivePacakgeTypes();
        }

        /// <summary>
        /// Get All Package Types.
        /// </summary>
        [Route("GetAllPackageTypes")]
        [HttpGet]
        public async Task<PackageWithChargeResponseModel> GetAllPackageTypes()
        {
            return await AdminClient.GetAllPackages();
        }

        /// <summary>
        /// Get Package Type By Id.
        /// </summary>
        [Route("GetPackageTypeById")]
        [HttpGet]
        public async Task<PackageWithChargeResponseModel> GetPackageTypeById(int PackageTypeId)
        {
            return await AdminClient.GetPackageTypeById(PackageTypeId);
        }

        /// <summary>
        /// Add New Package
        /// </summary>
        [Route("AddPackageType")]
        [HttpPost]
        public async Task<CommonResponseModel> AddPackageType(PackageWithChargeInfo PackageType)
        {
            return await AdminClient.AddPackageType(PackageType);
        }

        /// <summary>
        /// Update Package
        /// </summary>
        [Route("UpdatePackageType")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdatePackageType(PackageWithChargeInfo PackageType)
        {
            return await AdminClient.UpdatePackageType(PackageType);
        }

        /// <summary>
        /// Change PackageType Status
        /// </summary>
        [Route("ChangePackageTypeStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangePackageTypeStatus(int PackageTypeId, byte Status)
        {
            return await AdminClient.ChangePackageTypeStatus(PackageTypeId, Status);
        }

        /// <summary>
        /// Get Product Types.
        /// </summary>
        [Route("GetActiveProductTypes")]
        [HttpGet]
        public async Task<ProductTypeModel> GetActiveProductTypes()
        {
            return await AdminClient.GetActiveProductTypes();
        }

        /// <summary>
        /// Get All Product Types.
        /// </summary>
        [Route("GetAllProductType")]
        [HttpGet]
        public async Task<ProductTypeModel> GetAllProductType()
        {
            return await AdminClient.GetAllProductType();
        }

        /// <summary>
        /// Get All Product Types.
        /// </summary>
        [Route("GetProductTypeById")]
        [HttpGet]
        public async Task<ProductTypeModel> GetProductTypeById(int ProductTypeId)
        {
            return await AdminClient.GetProductTypeById(ProductTypeId);
        }

        /// <summary>
        /// Add New Product Types.
        /// </summary>
        [Route("AddProductType")]
        [HttpPost]
        public async Task<CommonResponseModel> AddProductType(ProductTypeInfo ProductType)
        {
            return await AdminClient.AddProductType(ProductType);
        }

        ///<summary>
        /// Update Product Type.
        /// </summary>
        [Route("UpdateProductType")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateProductType(ProductTypeInfo ProductType)
        {
            return await AdminClient.UpdateProductType(ProductType);
        }

        ///<summary>
        /// Update Product Type.
        /// </summary>
        [Route("ChangeProductTypeStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeProductTypeStatus(int ProductTypeId, byte Status)
        {
            return await AdminClient.ChangeProductTypeStatus(ProductTypeId, Status);
        }

        /// <summary>
        /// Get Request Types.
        /// </summary>
        [Route("GetRequestTypes")]
        [HttpGet]
        public async Task<RequestTypeModel> GetRequestTypes()
        {
            return await AdminClient.GetRequestTypes();
        }

        /// <summary>
        /// Get ATC Outlet.
        /// </summary>
        [Route("GetAtcOutletByArea")]
        [HttpGet]
        public async Task<AtcPointModel> GetAtcOutletByArea(int AreaId)
        {
            return await AdminClient.GetAtcPointByArea(AreaId);
        }

        /// <summary>
        /// Get ATC Outlet by Id.
        /// </summary>
        [Route("GetAtcOutletById")]
        [HttpGet]
        public async Task<AtcPointModel> GetAtcOutletById(int PointId)
        {
            return await AdminClient.GetAtcPointById(PointId);
        }

        /// <summary>
        /// Get Active Atc Outlet.
        /// </summary>
        [Route("GetActiveAtcOutlet")]
        [HttpGet]
        public async Task<AtcPointModel> GetActiveAtcOutlet()
        {
            return await AdminClient.GetActiveAtcPoint();
        }

        /// <summary>
        /// Get Active Atc Outlet.
        /// </summary>
        [Route("GetllAtcOutlet")]
        [HttpGet]
        public async Task<AtcPointModel> GetllAtcOutlet()
        {
            return await AdminClient.GetAllAtcPoint();
        }

        /// <summary>
        /// Add ATC Outlet.
        /// </summary>
        /// <param name="Request">
        ///     PointId = <strong>No need</strong> <br></br>
        ///     PointName = "Point Name" <br></br>
        ///     PointType = 1 => ATC Outlet | 2 => ATC Warehouse <br></br>
        ///     AreaId = Area ID <br></br>
        ///     Address = Address Line 1 <br></br>
        ///     HouseOrRoadNo = House or Road No <br></br>
        ///     StreetAddress = Street Address <br></br>
        ///     PostalCode = Postal Code <br></br>
        ///     Landmark = Landmark <br></br>
        ///     Latitudes = Latitudes <br></br>
        ///     Longitudes = Longitudes <br></br>
        ///     ContactNo = Phone / Mobile Nubmer <br></br>
        ///     UserId = Admin User Id <br></br>
        /// </param>
        [Route("AddAtcPoint")]
        [HttpPost]
        public async Task<CommonResponseModel> AddOutlet(AtcPointRequestModel Request)
        {
            return await AdminClient.AddOutlet(Request);
        }

        /// <summary>
        /// Add ATC Outlet.
        /// </summary>
        /// <param name="Request">
        ///     PointId = ATC Point Id <br></br>
        ///     PointName = "Point Name" <br></br>
        ///     PointType = 1 => ATC Outlet | 2 => ATC Warehouse <br></br>
        ///     AreaId = Area ID <br></br>
        ///     Address = Address Line 1 <br></br>
        ///     HouseOrRoadNo = House or Road No <br></br>
        ///     StreetAddress = Street Address <br></br>
        ///     PostalCode = Postal Code <br></br>
        ///     Landmark = Landmark <br></br>
        ///     Latitudes = Latitudes <br></br>
        ///     Longitudes = Longitudes <br></br>
        ///     ContactNo = Phone / Mobile Nubmer <br></br>
        ///     UserId = Admin User Id <br></br>
        /// </param>
       
        [Route("UpdateAtcPoint")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateOutlet(AtcPointRequestModel Request)
        {
            return await AdminClient.UpdateOutlet(Request);
        }

        [Route("ChangeOutletStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeAtcPointStatus(int PointId, byte Status, int UserId)
        {
            return await AdminClient.ChangeOutletStatus(PointId, Status, UserId);
        }

        /// <summary>
        /// Add New City
        /// </summary>
        [Route("AddNewCity")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewCity(CityDistrictRequestModel RequestModel)
        {
            return await AdminClient.AddNewCity(RequestModel);
        }

        /// <summary>
        /// Upate City
        /// </summary>
        [Route("UpdateCity")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateCity(CityDistrictRequestModel RequestModel)
        {
            return await AdminClient.UpdateCity(RequestModel);
        }

        /// <summary>
        /// Change City Status
        /// </summary>
        /// <param name="CityDistrictId">
        ///     City or District ID
        /// </param>
        /// <param name="Status">
        ///     1 = Active |
        ///     0 = Inactive
        /// </param>
        /// <param name="UserId">User ID</param>
        [Route("UpdateCityStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdateCityStatus(int CityDistrictId, byte Status, int UserId)
        {
            return await AdminClient.ChangeCityStatus(CityDistrictId, Status, UserId);
        }

        /// <summary>
        /// Add New State
        /// </summary>
        [Route("AddNewState")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewState(ProvinceRequestModel RequestModel)
        {
            return await AdminClient.AddNewProvince(RequestModel);
        }

        /// <summary>
        /// Update State
        /// </summary>
        [Route("UpdateState")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateState(ProvinceRequestModel RequestModel)
        {
            return await AdminClient.UpdateProvince(RequestModel);
        }

        /// <summary>
        /// Change State Status
        /// </summary>
        /// <param name="StateId">
        ///     State or Province ID
        /// </param>
        /// <param name="Status">
        ///     1 = Active |
        ///     0 = Inactive
        /// </param>
        [Route("UpdateStateStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdateStateStatus(byte StateId, byte Status)
        {
            return await AdminClient.ChangeProvinceStatus(StateId, Status);
        }

        /// <summary>
        /// Add New Country
        /// </summary>
        [Route("AddNewCountry")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewCountry(CountryRequestModel RequestModel)
        {
            return await AdminClient.AddNewCountry(RequestModel);
        }

        /// <summary>
        /// Update State
        /// </summary>
        [Route("UpdateCountry")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateCountry(CountryRequestModel RequestModel)
        {
            return await AdminClient.UpdateCountry(RequestModel);
        }

        /// <summary>
        /// Change Country Status
        /// </summary>
        /// <param name="CountryId">
        ///     Country ID
        /// </param>
        /// <param name="Status">
        ///     1 = Active |
        ///     0 = Inactive
        /// </param>
        /// <param name="UserId">User ID</param>
        [Route("UpdateCountryStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdateCountryStatus(int CountryId, byte Status, int UserId)
        {
            return await AdminClient.UpdateCountryStatus(CountryId, Status, UserId);
        }

        /// <summary>
        /// Add New Area
        /// </summary>
        [Route("AddNewArea")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewArea(AreaRequestModel RequestModel)
        {
            return await AdminClient.AddNewArea(RequestModel);
        }

        /// <summary>
        /// Change Country Status
        /// </summary>
        [Route("UpdateArea")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateArea (AreaRequestModel RequestModels)
        {
            return await AdminClient.UpdateAreaStatus(RequestModels);
        }

        /// <summary>
        /// Add New PS/Upazila
        /// </summary>
        [Route("AddNewPsUpazila")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewPsUpazila(PsUpazilaRequestModel RequestModel)
        {
            return await AdminClient.AddNewPsUpazila(RequestModel);
        }

        /// <summary>
        /// Update PS/Upazila
        /// </summary>
        [Route("UpdatePsUpazila")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdatePsUpazila(PsUpazilaRequestModel RequestModel)
        {
            return await AdminClient.UpdatePsUpazilla(RequestModel);
        }

        /// <summary>
        /// Change PS/Upazila Status
        /// </summary>
        /// <param name="PsUpazilaId">
        ///     PS/Upazila ID
        /// </param>
        /// <param name="Status">
        ///     1 = Active |
        ///     0 = Inactive
        /// </param>
        [Route("UpdatePsUpazilaStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdatePsUpazilaStatus(int PsUpazilaId, byte Status)
        {
            return await AdminClient.UpdateUpazilaStatus(PsUpazilaId, Status);
        }

        /// <summary>
        /// Assign Request to Delivery Hero
        /// </summary>
        [Route("AssignRequest")]
        [HttpPost]
        public async Task<CommonResponseModel> AssignRequestToDh([FromBody] AssignRequestModel RequestModel)
        {
            return await AssignmentClient.AssignRequestToDh(RequestModel);
        }

        /// <summary>
        /// Get Request List For Assignment
        /// </summary>
        /// <param name="AtcPointId">
        ///     ATC Point ID. 1 = No Point
        /// </param>
        /// <param name="Operation">
        ///     N = New Request <br></br>
        ///     D = Delivery Only Request <br></br>
        ///     P = Inventory at Pickup point
        /// </param>
        /// <param name="PageNumber">
        ///     Page Number. Default = 1
        /// </param>
        [Route("GetRequestForAssignment")]
        [HttpGet]
        public async Task<RequestListForAssignmentResponse> GetRequestForAssignment(int AtcPointId, int PageNumber, string Operation)
        {
            return await AssignmentClient.GetRequestForAssignment(AtcPointId, PageNumber, Operation);
        }

        /// <summary>
        /// Get Request List For Assignment
        /// </summary>
        [Route("CancelRequest")]
        [HttpPost]
        public async Task<CommonResponseModel> CancelRequest(CancelRequestModel CancelModel)
        {
            return await AdminClient.CancelRequest(CancelModel);
        }

        /// <summary>
        /// Get Request List For Assignment
        /// </summary>
        /// <param name="DhId">Delivery Hero Id</param>
        /// <param name="NotId">
        ///     Notification ID => 0 = Unassigned | 1 = Assigned for Pickup and Drop | 2 = Assigned for Pickup and Delivery | 3 = Accepted by Delivery Hero | 4 = On The Way To Pickup | 5 = Outbound from ATC Point | 6 = Outbound from Warehouse | 7 = Picked Up | 8 = On The Way To Drop | 9 = On The Way To Delivery | 10 = At Pickup Point | 11 = At Warehouse | 12 = Acknowledge by ATC Point | 13 = Acknowledge by Warehouse | 14 = Delivered | 15 = Acknowledge by Receiver | 16 = Cancelled By Sender | 17 = Cancelled By Admin | 18 = Cacnelled By System due to encryption error
        /// </param>
        /// <param name="PageNumber">Page Number [Default = 1]</param>
        [Route("GetAssignmentByLatestStatus")]
        [HttpGet]
        public async Task<DhAssignmentResponseModel> GetAssignmentByLatestStatus(long DhId, byte NotId, int PageNumber=1)
        {
            return await AdminClient.GetAssignmentByLatestStatus(DhId, NotId, PageNumber);
        }

        [Route("AddNewExtraPackage")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNewExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            return await AdminClient.AddNewExtraPackage(RequestModel);
        }

        [Route("UpdateExtraPackage")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            return await AdminClient.UpdateExtraPackage(RequestModel);
        }

        [Route("ChangeExtraPackageStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeExtraPackageStatus(byte ExtraPackageId, byte Status)
        {
            return await AdminClient.ChangeExtraPackageStatus(ExtraPackageId, Status);
        }

        [Route("GetExtraPackagingTypes")]
        [HttpGet]
        public async Task<ExtraPackagingTypeModel> GetExtraPackagingTypes()
        {
            return await AdminClient.GetExtraPackagingTypes();
        }

        [Route("GetActiveExtraPackagingTypes")]
        [HttpGet]
        public async Task<ExtraPackagingTypeModel> GetActiveExtraPackagingTypes()
        {
            return await AdminClient.GetActiveExtraPackagingTypes();
        }

        [Route("GetExtraPackageById")]
        [HttpGet]
        public async Task<ExtraPackagingTypeModel> GetExtraPackageById(byte ExtraPackageId)
        {
            return await AdminClient.GetExtraPackageById(ExtraPackageId);
        }

        [Route("GetActiveDeliveryTimeSlot")]
        [HttpGet]
        public async Task<DeliveryTimeSlotsResponseModel> GetActiveDeliveryTimeSlot()
        {
            return await AdminClient.GetActiveDeliveryTimeSlot();
        }

        //GetAllDeliveryTimeSlot
        [Route("GetAllDeliveryTimeSlot")]
        [HttpGet]
        public async Task<DeliveryTimeSlotsResponseModel> GetAllDeliveryTimeSlot()
        {
            return await AdminClient.GetAllDeliveryTimeSlot();
        }

        [Route("GetDeliveryTimeSlotById")]
        [HttpGet]
        public async Task<DeliveryTimeSlotsResponseModel> GetDeliveryTimeSlotById(int DeliveryTimeSlotId)
        {
            return await AdminClient.GetDeliveryTimeSlotById(DeliveryTimeSlotId);
        }

        [Route("AddDeliveryTimeSlot")]
        [HttpPost]
        public async Task<CommonResponseModel> AddDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            return await AdminClient.AddDeliveryTimeSlot(DeliveryTimeSlot);
        }

        [Route("UpdateDeliveryTimeSlot")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            return await AdminClient.UpdateDeliveryTimeSlot(DeliveryTimeSlot);
        }

        [Route("ChangeDeliveryTimeSlotStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeDeliveryTimeSlotStatus(int DeliveryTimeSlotId, int DestinationId, byte Status, int UserId)
        {
            return await AdminClient.ChangeDeliveryTimeSlotStatus(DeliveryTimeSlotId, DestinationId, Status, UserId);
        }

        [Route("GetAllPickupAndDeliveryCharge")]
        [HttpGet]
        public async Task<PickupAndDeliveryChargeResponseModel> GetAllPickupAndDeliveryCharge()
        {
            return await AdminClient.GetAllPickupAndDeliveryCharge();
        }

        [Route("GetActivePickupAndDeliveryCharge")]
        [HttpGet]
        public async Task<PickupAndDeliveryChargeResponseModel> GetActivePickupAndDeliveryCharge()
        {
            return await AdminClient.GetActivePickupAndDeliveryCharge();
        }

        /// <summary>
        ///     Add Pickup And Delivery Charge
        /// </summary>
        /// <param name="ChargeModel">
        ///     ChargeId = No Need <br></br>
        ///     CityDistrictId = ID of City or District <br></br>
        ///     PickupPoint = 1 => Drop At ATC Outlet |  2 => Pickup From Inside City |  3 => Pickup From Outside City <br></br>
        ///     DeliveryPoint = 1 => Collection From ATC Outlet | 2 = Delivery To Inside City | 3 = Delivery To Outside City <br></br>
        ///     PickupCharge = Charge for pickup parcel <br></br>
        ///     DeliveryCharge = Charge for delivery parcel <br></br>
        ///     ActiveStatus = No need <br></br>
        ///     UserId = Id of user adding
        /// </param>
        [Route("AddPickupAndDeliveryCharge")]
        [HttpPost]
        public async Task<CommonResponseModel> AddPickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
           return await AdminClient.AddPickupAndDeliveryCharge(ChargeModel);
        }

        /// <summary>
        ///     Update Pickup And Delivery Charge
        /// </summary>
        /// <param name="ChargeModel">
        ///     ChargeId = Charge Id <br></br>
        ///     CityDistrictId = ID of City or District <br></br>
        ///     PickupPoint = 1 => Drop At ATC Outlet |  2 => Pickup From Inside City |  3 => Pickup From Outside City <br></br>
        ///     DeliveryPoint = 1 => Collection From ATC Outlet | 2 = Delivery To Inside City | 3 = Delivery To Outside City <br></br>
        ///     PickupCharge = Charge for pickup parcel <br></br>
        ///     DeliveryCharge = Charge for delivery parcel <br></br>
        ///     ActiveStatus = No need <br></br>
        ///     UserId = Id of user adding
        /// </param>
        [Route("UpdatePickupAndDeliveryCharge")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
            return await AdminClient.UpdatePickupAndDeliveryCharge(ChargeModel);
        }

        /// <summary>
        ///     Change Pickup And Delivery Charge Status
        /// </summary>
        /// <param name="ChargeId">
        ///     Charge Id
        /// </param>
        /// <param name="Status">
        ///     1 = Active <br></br>
        ///     0 = Inactive <br></br>
        /// </param>
        /// <param name="UserId">
        ///     Id of user making change
        /// </param>
        [Route("UpdatePickupAndDeliveryChargeStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryChargeStatus(int ChargeId, byte Status, int UserId)
        {
            return await AdminClient.UpdatePickupAndDeliveryChargeStatus(ChargeId, Status, UserId);
        }

        [Route("GetPickupAndDeliveryChargeById")]
        [HttpGet]
        public async Task<PickupAndDeliveryChargeResponseModel> GetPickupAndDeliveryChargeById(int ChargeId)
        {
            return await AdminClient.GetPickupAndDeliveryChargeById(ChargeId);
        }

        [Route("AddNotificationMessage")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNotificationMessage(NotificationMesasge Request)
        {
            return await AdminClient.AddNotificationMessage(Request);
        }

        [Route("UpdateNotificationMessage")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateNotificationMessage(NotificationMesasge Request)
        {
            return await AdminClient.UpdateNotificationMessage(Request);
        }

        [Route("ChangeNotificationMessageStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeNotificationMessageStatus(byte NotificationId, byte Status)
        {
            return await AdminClient.ChangeNotificationMessageStatus(NotificationId, Status);
        }

        [Route("GetAllNotificationMessage")]
        [HttpGet]
        public async Task<NotificationMsgModel> GetAllNotificationMessage()
        {
            return await AdminClient.GetAllNotificationMessage();
        }

        [Route("GetActiveNotificationMessage")]
        [HttpGet]
        public async Task<NotificationMsgModel> GetActiveNotificationMessage()
        {
            return await AdminClient.GetActiveNotificationMessage();
        }

        [Route("GetNotificationMessageById")]
        [HttpGet]
        public async Task<NotificationMsgModel> GetNotificationMessageById(byte NotificationId)
        {
            return await AdminClient.GetNotificationMessageById(NotificationId);
        }

        /// <summary>
        ///     Add Notification SMS Master
        /// </summary>
        /// <param name="Request">
        ///     <p><strong>MasterId </strong>= No need</p>
        ///     <p><strong>NotificationId</strong> = Notfication Id of Notification Message</p>
        ///     <p><strong>SendNotification</strong> = <br></br> 0 => No <br></br> 1 => Yes</p>
        ///     <p><strong>SendNotificationTo (Comma Separate for multiple)</strong> = <br></br> 0 => None <br></br> 1 => SENDER <br></br> 2 => RECEIVER <br></br> 3 => DELIVERY HERO <br></br> 4 => ADMIN</p>
        ///     <p><strong>NotificationTitle</strong> = "Notification Title"</p>
        ///     <p><strong>NotificationMessage</strong> = "Notification Message"</p>
        ///     <p><Strong>SendSms</Strong> = <br></br> 0 => No <br></br> 1 => Yes</p>
        ///     <p><strong>SendSmsTo (Comma Separate for multiple)</strong> = <br></br> 0 => None <br></br> 1 => SENDER <br></br> 2 => RECEIVER <br></br> 3 => DELIVERY HERO <br></br> 4 => ADMIN</p>
        ///     <p><strong>SmsMessage</strong> = "SMS MEssage"</p>
        ///     <p><strong>ActiveStatus</strong> = No need</p>
        ///     <p><strong>UserId</strong> = Admin User Id</p>
        /// </param>
        [Route("AddNotificationSmsMaster")]
        [HttpPost]
        public async Task<CommonResponseModel> AddNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            return await AdminClient.AddNotificationSmsMaster(Request);
        }

        /// <summary>
        ///     Update Notification SMS Master
        /// </summary>
        /// <param name="Request">
        ///     <p><strong>MasterId </strong>= Master Id</p>
        ///     <p><strong>NotificationId</strong> = Notfication Id of Notification Message</p>
        ///     <p><strong>SendNotification</strong> = <br></br> 0 => No <br></br> 1 => Yes</p>
        ///     <p><strong>SendNotificationTo (Comma Separate for multiple)</strong> = <br></br> 0 => None <br></br> 1 => SENDER <br></br> 2 => RECEIVER <br></br> 3 => DELIVERY HERO <br></br> 4 => ADMIN</p>
        ///     <p><strong>NotificationTitle</strong> = "Notification Title"</p>
        ///     <p><strong>NotificationMessage</strong> = "Notification Message"</p>
        ///     <p><Strong>SendSms</Strong> = <br></br> 0 => No <br></br> 1 => Yes</p>
        ///     <p><strong>SendSmsTo (Comma Separate for multiple)</strong> = <br></br> 0 => None <br></br> 1 => SENDER <br></br> 2 => RECEIVER <br></br> 3 => DELIVERY HERO <br></br> 4 => ADMIN</p>
        ///     <p><strong>SmsMessage</strong> = "SMS MEssage"</p>
        ///     <p><strong>ActiveStatus</strong> = No need</p>
        ///     <p><strong>UserId</strong> = Admin User Id</p>
        /// </param>
        [Route("UpdateNotificationSmsMaster")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            return await AdminClient.UpdateNotificationSmsMaster(Request);
        }

        [Route("UpdateNotificationSmsStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeNotificationSmsMasterStatus(int MasterId, byte Status, int UserId)
        {
            return await AdminClient.ChangeNotificationSmsMasterStatus(MasterId, Status, UserId);
        }

        [Route("GetAllNotificationSmsMaster")]
        [HttpGet]
        public async Task<NotificationSmsResponseModel> GetAllNotificationSmsMaster()
        {
            return await AdminClient.GetAllNotificationSmsMaster();
        }

        [Route("GetActiveNotificationSmsMaster")]
        [HttpGet]
        public async Task<NotificationSmsResponseModel> GetActiveNotificationSmsMaster()
        {
            return await AdminClient.GetActiveNotificationSmsMaster();
        }

        [Route("GetNotificationSmsMasterById")]
        [HttpGet]
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterById(int MasterId)
        {
            return await AdminClient.GetNotificationSmsMasterById(MasterId);
        }

        [Route("GetNotificationSmsMasterByNotificationId")]
        [HttpGet]
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterByNotificationId(byte NotificationId)
        {
            return await AdminClient.GetNotificationSmsMasterByNotificationId(NotificationId);
        }

        [Route("CreateManifest")]
        [HttpPost]
        public async Task<CommonResponseModel> CreateManifest(ManifestInfoRequestModel Request)
        {
            return await AdminClient.CreateManifest(Request);
        }

        [Route("UpdateManifest")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateManifest(ManifestInfoRequestModel Request)
        {
            return await AdminClient.UpdateManifest(Request);
        }

        [Route("GetManifestById")]
        [HttpGet]
        public async Task<ManifestInfoResponseModel> GetManifestById(long ManifestId)
        {
            return await AdminClient.GetManifestById(ManifestId);
        }

        [Route("GetAllManifest")]
        [HttpGet]
        public async Task<ManifestInfoResponseModel> GetAllManifest()
        {
            return await AdminClient.GetAllManifest();
        }

        [Route("GetActiveManifest")]
        [HttpGet]
        public async Task<ManifestInfoResponseModel> GetActiveManifest()
        {
            return await AdminClient.GetActiveManifest();
        }

        [Route("AddTimePeriods")]
        [HttpPost]
        public async Task<CommonResponseModel> AddTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            return await AdminClient.AddTimePeriods(Request);
        }

        [Route("UpdateTimePeriods")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            return await AdminClient.UpdateTimePeriods(Request);
        }

        [Route("ChangeTimePeriodStatus")]
        [HttpGet]
        public async Task<CommonResponseModel> ChangeTimePeriodStatus(int TimePeriodId, int status)
        {
            return await AdminClient.ChangeTimePeriodStatus(TimePeriodId, status);
        }

        [Route("GetTimePeriodById")]
        [HttpGet]
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetTimePeriodById(int TimePeriodId)
        {
            return await AdminClient.GetTimePeriodById(TimePeriodId);
        }

        [Route("GetActiveTimePeriod")]
        [HttpGet]
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetActiveTimePeriod()
        {
            return await AdminClient.GetActiveTimePeriod();
        }

        [Route("GetAllTimePeriod")]
        [HttpGet]
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetAllTimePeriod()
        {
            return await AdminClient.GetAllTimePeriod();
        }

        /// <summary>
        /// Add Banner
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /AddBanner
        ///     {
        ///            "BannerInfoModel": {
        ///              "BannerType": "Popup",
        ///              "ShowInPage": "Home",
        ///              "TemplateName" : "TemplateName",
        ///              "DateFrom": "2020-12-01T09:33:58.340Z",
        ///              "DateTo": "2020-12-01T09:33:58.340Z",
        ///              "UserId": 0
        ///            },
        ///            "BannerDetailsModel": [
        ///              {
        ///                "SlNo" : 1,
        ///                "BannerImageLocation" : "Blank OK"
        ///             }
        ///           ]
        ///     }
        /// </remarks>
        /// 
        [Route("AddBanner")]
        [HttpPost]
        public async Task<CommonResponseModel> AddBanner([FromForm] BannerAddModel BannerRequestModel)
        {
            string rootpath = _hostingEnvironment.ContentRootPath.ToString() + "/Images/" + "/Banners/";

            List<string> FileList = new List<string>();

            CourierBannerRequestModel RequestModel = JsonConvert.DeserializeObject<CourierBannerRequestModel>(BannerRequestModel.PayLoad);

            //var BannerImages = BannerRequestModel.BannerImage;
            var BannerImages = BannerRequestModel.BannerImage;
            int curImage = 0;

            if (BannerImages != null)
            {
                if(BannerImages.Count == RequestModel.BannerDetailsModel.Count)
                {
                    foreach (IFormFile BannerImage in BannerImages)
                    {
                        if (BannerImage.Length > 0)
                        {
                            //string FileName = BannerImage.FileName.Substring(0, BannerImage.FileName.Length - 4);
                            FileList.Add(BannerImage.FileName);

                            using (var fileStream = new FileStream(rootpath + BannerImage.FileName, FileMode.Create))
                            {
                                BannerImage.CopyTo(fileStream);
                            }

                            RequestModel.BannerDetailsModel[curImage].BannerImageLocation = "/Images//Banners/" + BannerImage.FileName;
                            RequestModel.BannerDetailsModel[curImage].SlNo = Convert.ToByte(curImage + 1);
                            curImage += 1;
                        }
                    }

                    return await AdminClient.AddBanner(RequestModel);
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "540",
                            InnerException = "",
                            Message = "Number of banner details and number of banner image must be equal",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(Response);
                }
                
            } else
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "540",
                        InnerException = "",
                        Message = "Banner imgae is mandatory",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }

        [Route("UpdateBanner")]
        [HttpPost]
        public async Task<CommonResponseModel> UpdateBanner(CourierBannerUpdateModel BannerUpdateModel)
        {
            return await AdminClient.UpdateBanner(BannerUpdateModel);
        }

        [Route("GetBannerDetails")]
        [HttpGet]
        public async Task<CourierBannerResponseModel> GetBannerDetails(byte BannerFor)
        {
            return await AdminClient.GetBannerDetails(BannerFor);
        }

        /// <summary>
        /// Get User List By Type
        /// </summary>
        /// <param name="SenderType">
        ///     1 = General User | <br></br>
        ///     2 = Merchant User | <br></br>
        ///     3 = Star User | <br></br>
        /// </param>
        /// <param name="ActiveStatus">
        ///     0 = Inactive | 1 = Active
        /// </param>
        [Route("GetUserByType")]
        [HttpGet]
        public async Task<SenderDetailsRespModel> GetUserByType(byte SenderType, byte ActiveStatus)
        {
            return await AdminClient.GetUserByType(SenderType, ActiveStatus);
        }

        [Route("GetUserById")]
        [HttpGet]
        public async Task<SenderDetailsRespModel> GetUserById(long SenderId)
        {
            return await AdminClient.GetUserById(SenderId);
        }
    }
}
