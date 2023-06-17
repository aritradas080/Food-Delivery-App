using Finalv1.Auth;
using Finalv1BLL.ModelDTOs;
using Finalv1BLL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Finalv1.Controllers
{
    [EnableCors("*", "*", "*")]

    public class DeliverymanController : ApiController
    {
        
        [HttpGet]
        [Route("api/deliveryman")] 
        public HttpResponseMessage Deliveryman() 
        { 
            try 
            { 
                var data = DeliverymanService.Get(); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } catch (Exception ex) 
            { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }); 
            } 
        }
        [Logged]
        [RoleDeliveryman]
        [HttpGet]
        [Route("api/deliveryman/{id}")] 
        public HttpResponseMessage Deliveryman(int id) 
        { 
            try 
            { 
                var data = DeliverymanService.Get(id); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } 
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }); 
            } 
        }

        [HttpPost]
        [Route("api/deliveryman/create")] 
        public HttpResponseMessage CreateDeliveryman(DeliverymanDTO deliverymanDTO) 
        { 
            try 
            { 
                var data = DeliverymanService.Create(deliverymanDTO); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            } 
        }
        [Logged]
        [RoleDeliveryman]

        [HttpPost]
        [Route("api/deliveryman/update")] 
        public HttpResponseMessage UpdateDeliveryman(DeliverymanDTO deliverymanDTO) { 
            try 
            { 
                var data = DeliverymanService.Update(deliverymanDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
        [Logged]
        [RoleDeliveryman]

        [HttpGet]
        [Route("api/deliveryman/delete/{id}")] 
        public HttpResponseMessage DeleteDeliveryman(int id) 
        { 
            try { var data = DeliverymanService.Delete(id); 
                return Request.CreateResponse(HttpStatusCode.OK, data);
            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            } 
        }
        //search by address get order

        [Logged]
        [RoleDeliveryman]
        [HttpGet]
        [Route("api/deliveryman/order/{lat}/{lan}")]
        public HttpResponseMessage OrderGetbyAddress(float lat, float lan)
        {
            try
            {
                var data = OrderService.SearchByAdress(lat,lan);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Delivery Log
        /// </summary>


        [HttpGet] 
        [Route("api/deliverylog")] 
        public HttpResponseMessage DeliveryLog() 
        { 
            try { 
                var data = DeliveryLogService.Get(); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }); 
            }
        }
        //Delivery log create
        [Logged]
        [RoleDeliveryman]
        [HttpGet]
        [Route("api/delivery/{DID}/{OID}")] 
        public HttpResponseMessage DeliveryLogCreate(int DID, int OID) {
            try {
                var data = DeliveryLogService.IDAcceptlog(DID, OID); 
                return Request.CreateResponse(HttpStatusCode.OK, data); }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            } 
        }
        [Logged]
        [RoleDeliveryman]

        [HttpGet]
        [Route("api/order/delivery/{LID}")] 
        public HttpResponseMessage DeliveredStatus(int LID) 
        { 
            try { 
                var data = DeliveryLogService.DeliveredStatus(LID); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            } catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }); 
            } 
        }


        /// <summary>
        /// Delivery Man Type
        /// </summary>

        [Logged]
        [RoleDeliveryman]

        [HttpGet]
        [Route("api/deliveryman/type")]
        public HttpResponseMessage DeliverymanType()
        {
            try
            {
                var data = DeliverymanTypeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [Logged]
        [RoleDeliveryman]

        [HttpGet]
        [Route("api/deliveryman/type/{id}")]
        public HttpResponseMessage DeliverymanType(int id)
        {
            try
            {
                var data = DeliverymanTypeService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/deliveryman/type/create")]
        public HttpResponseMessage CreateDeliverymanType(DeliverymanTypeDTO deliverymanTypeDTO)
        {
            try
            {
                var data = DeliverymanTypeService.Create(deliverymanTypeDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Logged]
        [RoleDeliveryman]
        [HttpPost]
        [Route("api/deliveryman/type/update")]
        public HttpResponseMessage UpdateDeliverymanType(DeliverymanTypeDTO deliverymanTypeDTO)
        {
            try
            {
                var data = DeliverymanTypeService.Update(deliverymanTypeDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Logged]
        [RoleDeliveryman]

        [HttpGet]
        [Route("api/deliveryman/type/delete/{id}")]
        public HttpResponseMessage DeleteDeliverymanType(int id)
        {
            try
            {
                var data = DeliverymanTypeService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }







    }
}
