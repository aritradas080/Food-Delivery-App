using Finalv1BLL.ModelDTOs;
using Finalv1BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Finalv1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoggController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(AllUserDTO allUserDTO)
        {
            try
            {
                var data = LogService.LogIn(allUserDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/logout/{token}")]
        public HttpResponseMessage Login(string token)
        {
            try
            {
                var data = LogService.LogOut(token);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
