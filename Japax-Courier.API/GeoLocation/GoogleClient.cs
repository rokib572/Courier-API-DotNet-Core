using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Japax_Courier.API.GeoLocation.ResponseModel;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.Repositories.Courier;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.FcmMessaging;

namespace Japax_Courier.API.GeoLocation
{
    public class GoogleClient
    {
        private string GOOGLE_API_KEY;
        private string GOOGLE_GEOCODE_URL = "https://maps.googleapis.com/maps/api/geocode/json?address=";

        public GoogleClient(string googleApiKey)
        {
            GOOGLE_API_KEY = googleApiKey;
        }
        public async Task<GeocodingModel> GetGeocode(string Address)
        {
            try
            {
                string googleURL = GOOGLE_GEOCODE_URL + WebUtility.UrlEncode(Address) + "&key=" + GOOGLE_API_KEY + "&sensor=true_or_false";
                WebRequest httpWebRequest = WebRequest.Create(googleURL);

                httpWebRequest.Method = "GET";

                WebResponse httpResponse = await httpWebRequest.GetResponseAsync();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    return await Task.FromResult(JsonConvert.DeserializeObject<GeocodingModel>(result));
                }
            }
            catch (Exception ex)
            {
                GeocodingModel _GeocodingModel = new GeocodingModel
                {
                    status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "513",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetActiveCountries",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_GeocodingModel);
            }
        }        
    }
}
