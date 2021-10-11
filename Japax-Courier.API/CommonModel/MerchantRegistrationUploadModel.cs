using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japax_Courier.API.CommonModel
{
    public class MerchantRegistrationUploadModel
    {
        [Required(ErrorMessage = "Payload is required.")]
        public string PayLoad { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
