using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.CommonModel
{
    public class AddProductImageModel : PayLoadModel
    {
        public IFormFileCollection ProductImage { get; set; }
    }
}
