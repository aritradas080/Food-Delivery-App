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
    [EnableCors("*","*","*")]
    
    public class UserController : ApiController
    {
       
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage AllUsers()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage GetOneUser(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/users/create")]
        public HttpResponseMessage CreateUser(UserDTO userdto)
        {
            try
            {
                var data = UserService.Create(userdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
   
        [HttpPost]
        [Route("api/users/update")]
        public HttpResponseMessage UpdateUser(UserDTO userdto)
        {
            try
            {
                var data = UserService.Update(userdto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                var data = UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/users/username/{username}")]
        public HttpResponseMessage GetByUserName(String username)
        {
            try
            {
                var data = UserService.SearchByUserName(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/users/adress/{adress}")]
        public HttpResponseMessage GetByAdresse(String adress)
        {
            try
            {
                var data = UserService.SearchByAdress(adress);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/users/token/{token}")]
        public HttpResponseMessage GetByToken(String token)
        {
            try
            {
                var data = UserService.SearchByToken(token);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/users/orders/{token}")]
        public HttpResponseMessage GetByTokengetorder(String token)
        {
            try
            {
                var data = UserService.SearchByTokengetorder(token);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
