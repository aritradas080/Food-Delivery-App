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
    public class FeedBackController : ApiController
    {
        [HttpGet]
        [Route("api/feedbacks")]
        public HttpResponseMessage AllFeedback()
        {
            try
            {
                var data = FeedBackService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/feedbacks/{id}")]
        public HttpResponseMessage GetOneFeedback(int id)
        {
            try
            {
                var data = FeedBackService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/feedback/create")]
        public HttpResponseMessage CreateFeedback(FeedBackDTO feedBackDTO)
        {
            try
            {
                var data = FeedBackService.Create(feedBackDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/feedbacks/update")]
        public HttpResponseMessage UpdateFeedbacks(FeedBackDTO feedBackDTO)
        {
            try
            {
                var data = FeedBackService.Update(feedBackDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/feedbacks/delete/{id}")]
        public HttpResponseMessage Deletefeedback(int id)
        {
            try
            {
                var data = FeedBackService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/feedbacks/getbysubject/{subject}")]
        public HttpResponseMessage GetFeedbackBySubject(string subject)
        {
            try
            {
                var data = FeedBackService.GetBySubject(subject);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/feedbacks/getbybody/{body}")]
        public HttpResponseMessage GetFeedbackByBody(string body)
        {
            try
            {
                var data = FeedBackService.GetByBody(body);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
