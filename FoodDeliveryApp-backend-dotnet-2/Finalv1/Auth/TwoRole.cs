using Finalv1BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Finalv1.Auth
{
    public class TwoRole: AuthorizationFilterAttribute
    {
        private readonly string frole;
        private readonly string lrole;
        public TwoRole(string frole,string lrole)
        {
            
            this.frole = frole;
            this.lrole = lrole;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            var isUser = LogService.checkUser2(token.ToString(), frole,lrole);
            if (!isUser)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "You Are not "+frole+" or"+ lrole});
            }
            base.OnAuthorization(actionContext);
        }
    }
}