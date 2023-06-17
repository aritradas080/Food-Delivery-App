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
    public class CuisineController : ApiController
    {
        [HttpGet]
        [Route("api/cuisine")]
        public HttpResponseMessage AllCuisine()
        {
            try
            {
                var data = CuisineService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/cuisine/{id}")]
        public HttpResponseMessage GetOneCuisine(int id)
        {
            try
            {
                var data = CuisineService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/cuisine/create")]
        public HttpResponseMessage CreateCuisine(CuisineDTO cuisineDTO)
        {
            try
            {
                var data = CuisineService.Create(cuisineDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        [Route("api/cuisine/update")]
        public HttpResponseMessage UpdateCuisine(CuisineDTO cuisineDTO)
        {
            try
            {
                var data = CuisineService.Update(cuisineDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/cuisine/delete/{id}")]
        public HttpResponseMessage DeleteCuisine(int id)
        {
            try
            {
                var data = CuisineService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/cuisine/spice/{spice}")]
        public HttpResponseMessage SpiceLevel(string spice)
        {
            try
            {
                var data = CuisineService.SearchBySpiceLevel(spice);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
