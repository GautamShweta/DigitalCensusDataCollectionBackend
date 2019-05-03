using System.Collections.Generic;
using BL;
using Shared.DTO;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace Nagarro_Exit_Test_Assignment.Controllers
{
    public class HouseController : ApiController
    {
        public HttpResponseMessage GetAll()
            {
            HouseBL houseBL = new HouseBL();
            
            ResponseFormat<IEnumerable<HouseDTO>> response = new ResponseFormat<IEnumerable<HouseDTO>>();
            response.Data = houseBL.GetAll();

            if(response.Data==null)
                {
                response.Message = "there was some error";
                response.Success = false;

                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
           else if (response.Data.Count()==0)
                {
                response.Message = "Empty List";
                response.Success = false;

                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "Retrieved Successfully";
                response.Success = true;

                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }

        [Route("api/house/state")]
        public HttpResponseMessage GetStateReport(string state)
            {
               HouseBL houseBL = new HouseBL();
               ResponseFormat<List<int>> response = new ResponseFormat<List<int>>();
            response.Data = houseBL.StatePopulation();
            response.Message= "Retrieved Successfully";
            response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }

        public HttpResponseMessage Get(int id)
            {
            HouseBL houseBL = new HouseBL();
            ResponseFormat<HouseDTO> response = new ResponseFormat<HouseDTO>();
            response.Data = houseBL.GetById(id);

            if (response.Data == null)
                {
                response.Success = false;
                response.Message = "House Not Found";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Success = true;
                response.Message = "Retrieved Successfully";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }

            }

        // POST: api/Home
        public HttpResponseMessage Post(HouseDTO house)
            {
            HouseBL houseBL = new HouseBL();
            ResponseFormat<HouseDTO> response = new ResponseFormat<HouseDTO>();
            response.Data = houseBL.Create(house);
            if (response.Data!=null)
                {

                response.Message = "House Created";
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
        public HttpResponseMessage Delete(int id)
            {
            HouseBL houseBL = new HouseBL();

            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = houseBL.DeleteById(id);
            if (response.Data)
                {
                response.Message = "House Deleted";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "Cannot Delete";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }

        ////Update:
        //public void Put(int id, [FromBody]MemberDTO member)
        //    {


        //    }


        }

    }

