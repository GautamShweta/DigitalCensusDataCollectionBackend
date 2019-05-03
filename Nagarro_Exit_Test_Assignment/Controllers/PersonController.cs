using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Shared.DTO;

namespace Nagarro_Exit_Test_Assignment.Controllers
{
    public class PersonController : ApiController
    {
        //public HttpResponseMessage GetAll()
        //    {
        //    PersonBL personBL = new PersonBL();
        //    ResponseFormat<IEnumerable<PersonDTO>> response = new ResponseFormat<IEnumerable<PersonDTO>>();
        //    response.Data = personBL.GetAll();
        //    if (response.Data==null)
        //        {
        //        response.Message = "There was some error";
        //        response.Success = false;

        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    else if (response.Data.Count() == 0)
        //        {
        //        response.Message = "Empty List";
        //        response.Success = false;

        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    else
        //        {
        //        response.Message = "Retrieved Successfully";
        //        response.Success = false;

        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }

        //    }


        //public HttpResponseMessage Get(int id)
        //    {
        //    PersonBL personBL = new PersonBL();
        //    ResponseFormat<PersonDTO> response = new ResponseFormat<PersonDTO>();
        //    response.Data = personBL.GetById(id);

        //    if (response.Data == null)
        //        {
        //        response.Success = false;
        //        response.Message = "Person Not Found";
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    else
        //        {
        //        response.Success = true;
        //        response.Message = "Retrieved Successfully";
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }

        //    }


        [HttpGet]
        [Route("api/person/{censusHouseNumber}")]
        public HttpResponseMessage HouseNumberExists(int censusHouseNumber)
            {
            PersonBL personBL = new PersonBL();
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = personBL.CensusHouseNumberExists(censusHouseNumber);
            if (response.Data)
                {

                response.Message = "House Number Exists";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "House Number Do Not Exists";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
        // POST: api/Home
        public HttpResponseMessage Post(PersonDTO person)
            {
            PersonBL personBL = new PersonBL();
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = personBL.Create(person);
            if (response.Data)
                {

                response.Message = "Person Created";
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

        //DELETE: api/Delete
        //public HttpResponseMessage Delete(int id)
        //    {
        //    PersonBL personBL = new PersonBL();

        //    ResponseFormat<bool> response = new ResponseFormat<bool>();
        //    response.Data = personBL.DeleteById(id);
        //    if (response.Data)
        //        {
        //        response.Message = "Person Deleted";
        //        response.Success = true;
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    else
        //        {
        //        response.Message = "Cannot Delete";
        //        response.Success = false;
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //    }

        

        }
    }
