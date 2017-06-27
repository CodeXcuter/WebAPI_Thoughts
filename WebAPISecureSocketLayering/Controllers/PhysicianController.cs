﻿//|---------------------------------------------------------------|
//|                WEB API SECURE SOCKET LAYERING                 |
//|---------------------------------------------------------------|
//|                       Developed by Wonde Tadesse              |
//|                             Copyright ©2014 - Present         |
//|---------------------------------------------------------------|
//|                WEB API SECURE SOCKET LAYERING                 |
//|---------------------------------------------------------------|

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebAPISecureSocketLayering.Common;

using WebAPICommonLibrary;
using POCOLibrary;

namespace WebAPISecureSocketLayering.Controllers
{
    [HttpsValidator] // Enforce HTTPS request to the controller
    public class PhysicianController : PhysicianBaseController
    {
        #region Public APIs 

        [ActionName("GetPhysicians")]
        public new  HttpResponseMessage GetPhysicians()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, base.GetPhysicians(), new MediaTypeHeaderValue("application/json"));
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpGet]
        public new  HttpResponseMessage GetPhysician(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, base.GetPhysician(id), new MediaTypeHeaderValue("application/json"));
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpGet]
        public new HttpResponseMessage ActivePhysicians()
        {
            return Request.CreateResponse(HttpStatusCode.OK, base.ActivePhysicians(), new MediaTypeHeaderValue("application/json"));
        }

        [HttpGet]
        public override HttpResponseMessage RemovePhysician(int id)
        {
            return base.RemovePhysician(id);
        }

        [Route("AddPhysician")]
        [HttpPost]
        public HttpResponseMessage AddPhysician(HttpRequestMessage physicianRequest)
        {
            PhysicianBase physician = physicianRequest.Content.ReadAsAsync<PhysicianBase>().Result;
            return base.AddPhysician(physician);
        }

        #endregion
    }
}
