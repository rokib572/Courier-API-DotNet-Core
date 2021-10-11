using Japax_Courier_DB.DBModels.Courier.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.CommonModel
{
    public class DeliveryHeroInfoModel
    {
        public string PayLoad { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
