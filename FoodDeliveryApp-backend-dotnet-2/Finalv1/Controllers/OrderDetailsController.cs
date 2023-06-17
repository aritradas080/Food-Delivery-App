using Finalv1BLL.ModelDTOs;
using Finalv1BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Finalv1.Controllers
{
    public class OrderDetailsController : ApiController
    {
        [HttpGet]
        [Route("api/allorderdetails")]
        public HttpResponseMessage Allorderdetails()
        {
            try
            {
                var data = OrderDetailsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/allorderdetails/{id}")]
        public HttpResponseMessage GetOneorderdetails(int id)
        {
            try
            {
                var data = OrderDetailsService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/allorderdetails/create")]
        public HttpResponseMessage Createorderdetails(OrderDetailsDTO orderdetailsdto)
        {
            try
            {
                var data = OrderDetailsService.Create(orderdetailsdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/allorderdetails/update")]
        public HttpResponseMessage Updateorderdetails(OrderDetailsDTO orderdetailsdto)
        {
            try
            {
                var data = OrderDetailsService.Update(orderdetailsdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/allorderdetails/delete/{id}")]
        public HttpResponseMessage Deleteorderdetails(int id)
        {
            try
            {
                var data = OrderDetailsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
