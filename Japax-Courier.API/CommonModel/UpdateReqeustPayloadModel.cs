using Japax_Courier_DB.DBModels.CommonModels.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.CommonModel
{
    public class UpdateReqeustPayloadModel : PayLoadModel
    {
        public IFormFileCollection ProductImage { get; set; }
    }
}
