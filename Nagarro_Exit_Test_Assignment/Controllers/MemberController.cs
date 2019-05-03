using System.Collections.Generic;
using BL;
using Shared.DTO;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Linq;
using Shared.Enum;

namespace Nagarro_Exit_Test_Assignment.Controllers
    {
    public class MemberController : ApiController
        {


        [HttpGet]
        public HttpResponseMessage Get(string email)
            {
            MemberBL memberBL = new MemberBL();
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = memberBL.EmailExists(email);
            if (response.Data)
                {

                response.Message = "Member Created";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "There Was Some Error";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }


        [HttpGet]
        [Route("api/member/{aadharNumber}")]
        public HttpResponseMessage GetByAadhar(string aadharNumber)
            {
            MemberBL memberBL = new MemberBL();
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = memberBL.AadharExists(aadharNumber);
            if (response.Data)
                {

                response.Message = "Member Created";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "There Was Some Error";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }

        public HttpResponseMessage Post(MemberDTO member)
            {
            MemberBL memberBL = new MemberBL();
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = memberBL.Create(member);
            if (response.Data)
                {

                response.Message = "Member Created";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "There Was Some Error";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }

        //DELETE: api/Delete
        //public HttpResponseMessage Delete(int id)
        //    {
        //    MemberBL memberBL = new MemberBL();

        //    ResponseFormat<bool> response = new ResponseFormat<bool>();
        //    response.Data = memberBL.DeleteById(id);
        //    if (response.Data)
        //        {
        //        response.Message = "Member Deleted";
        //        response.Success = true;
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    else
        //        {
        //        response.Message = "Cannot Delete";
        //        response.Success = false;
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        //        }
        //    }


        }
    }
