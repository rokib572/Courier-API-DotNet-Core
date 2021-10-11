using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.CommonModel
{
    public class MerchantUpdateModel
    {
        [Required(ErrorMessage = "Payload is required.")]
        public string PayLoad { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
