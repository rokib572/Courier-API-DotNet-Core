using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.ReturnResponseModel
{
    public class GetRomDBResponse
    {
        public PayLoadModel PayLoad { get; set; }
        public RomDbResponse Response { get; set; }
    }
}
