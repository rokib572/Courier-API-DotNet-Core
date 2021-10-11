using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier_DB;
using Japax_Courier_DB.GeoLocation;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.FcmMessaging;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.Controllers
{
    [ApiVersion("2020-09-28")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class GoogleGeoLocation : ControllerBase
    {
        //[Route("GetGeoCode")]
        //[HttpGet]
        //public async Task<GeocodingModel> GetGeoCode(string Address)
        //{
        //    //GoogleClient _GoogleClient = new GoogleClient("AIzaSyB9aiE-enfBpVjFI5vpOllWfr0EojNYOio");
        //    // return await _GoogleClient.GetGeocode(Address);
        //}

        [Route("IsWithinPoly")]
        [HttpPost]
        public async Task<bool> IsWithinPolygon(string polygon, float pointX, float pointY)
        {
            GClient GoogleClient = new GClient();
            List<CoordinatePoint> _Polygon = new List<CoordinatePoint>();

            List<string> _PolygonNew = polygon.Split(";").ToList();

            foreach(string str in _PolygonNew)
            {
                List<string> coordinate = str.Split(",").ToList();

                if(coordinate.Count == 2)
                {
                    _Polygon.Add(new CoordinatePoint
                    {
                        pointX = Convert.ToSingle(Convert.ToSingle(coordinate[0]).ToString("0.#####")),
                        pointY = Convert.ToSingle(Convert.ToSingle(coordinate[1]).ToString("0.#####"))
                    });
                }
            }
            return await GoogleClient.isWithinPolygon(_Polygon, pointX, pointY);
        }

        [Route("SendNotification")]
        [HttpGet]
        public async Task<string> SendNotification(string FcmToken, string Title, string Body)
        {
            FcmClient fcmClient = new FcmClient();
            CommonResponseModel Response = new CommonResponseModel
            {
                Status = "Success"
            };
            List<string> TokenList = new List<string>();
            TokenList.Add(FcmToken);
            await fcmClient.SendNotification(TokenList, Title, Body);
            return await Task.FromResult("Success");
        }
    }
}
