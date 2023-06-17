using Finalv1.Auth;
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
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage AllOrders()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("api/orders/{id}")]
        public HttpResponseMessage GetOneorder(int id)
        {
            try
            {
                var data = OrderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/orders/create")]
        public HttpResponseMessage CreateOrder(OrderDTO orderdto)
        {
            try
            {
                var data = OrderService.Create(orderdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/orders/update")]
        public HttpResponseMessage UpdateOrder(OrderDTO orderdto)
        {
            try
            {
                var data = OrderService.Update(orderdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/orders/delete/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                var data = OrderService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/orders/status/{OrderStatus}")] 
        public HttpResponseMessage OrderStatusCheck(string OrderStatus) 
        { try 
            { 
                var data = OrderService.SearchbyOrderStatus(OrderStatus); return Request.CreateResponse(HttpStatusCode.OK, data);
            } 
            catch (Exception ex) 
            { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }

        [HttpGet]
        [Route("api/orders/amount/{Amount}")] 
        public HttpResponseMessage OrderG500(int Amount) 
        { try 
            { 
                var data = OrderService.SearchbyAmountG500(Amount); return Request.CreateResponse(HttpStatusCode.OK, data); 
            } 
            catch (Exception ex) 
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex); 
            } 
        }


    }
}
