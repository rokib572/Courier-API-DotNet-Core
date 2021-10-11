using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.CommonModel
{
 
    public class UpdateUserPayloadModel : PayLoadModel
    {
        public IFormFile ProfileImage { get; set; }
    }
}
