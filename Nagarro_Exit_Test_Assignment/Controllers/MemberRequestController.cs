using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BL;
using Shared.DTO;
using Shared.Enum;

namespace Nagarro_Exit_Test_Assignment.Controllers
    {
    public class MemberRequestController : ApiController
        {
        public HttpResponseMessage Get(RequestStatus status)
            {
            MemberBL memberBL = new MemberBL();
            ResponseFormat<List<MemberRequestDTO>> response = new ResponseFormat<List<MemberRequestDTO>>();
            response.Data =memberBL.GetAllByStatus(status); 
           
            if (response.Data==null)
                {
                response.Message = "There Was some error";
                response.Success = false;

                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                for(int i=0;i<response.Data.Count();i++)
                    {
                    response.Data[i].Image = getImage(response.Data[i].Image);
                    }
                response.Success = true;
                response.Message = "Retrieved Successfully";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }

            }

        public HttpResponseMessage Get(string email)
            {
            MemberBL memberBL = new MemberBL();
            ResponseFormat<MemberRequestDTO> response = new ResponseFormat<MemberRequestDTO>();
            response.Data = memberBL.GetByEmail(email);

            if (response.Data == null)
                {
                response.Success = false;
                response.Message = "Member Not Found";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Success = true;
                response.Message = "Retrieved Successfully";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }

            }


        public HttpResponseMessage Post(AddMemberModel model)
            {
            MemberBL memberBL = new MemberBL();
            MemberDTO member = model.member;
            member.Image = saveImage(model.image, model.name);
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
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }

        public HttpResponseMessage Patch([FromBody]MemberStatusModel memberStatusModel)
            {
            MemberBL memberBL = new MemberBL();

            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = memberBL.Update(memberStatusModel.memberId, memberStatusModel.status);
            if (response.Data)
                {
                response.Message = "Updated Successfully";
                response.Success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            else
                {
                response.Message = "Cannot Update";
                response.Success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }

        public string saveImage(string image,string name)
            {
            string imageName = null;
            imageName = new string(Path.GetFileNameWithoutExtension(name).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(name);

            byte[] bytes = Convert.FromBase64String(image);
            using (Image actualImage = Image.FromStream(new MemoryStream(bytes)))
                {
                //actualImage.Save("output.jpg", ImageFormat.Jpeg); 
                actualImage.Save(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + imageName));// Or Png
                }

            return imageName;
            }


        public string getImage(string imageName)
            {
            
                string path = HttpContext.Current.Server.MapPath("~/Images/") + imageName;
                string base64String;
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
                    {
                    using (MemoryStream m = new MemoryStream())
                        {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                        }
                    }

            }

        }
    }

