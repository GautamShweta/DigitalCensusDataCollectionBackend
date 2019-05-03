using DAL.Repository;
using Shared.DTO;
using BL.Helper;
using System.Collections.Generic;
using DAL.Entity;
using System.Linq;
using Shared.Enum;
using System.Web;

namespace BL
    {
    public class MemberBL
        {
        MemberRepository memberRepository;
        MemberRequestStatusRepository statusRepository;
        EntityToDtoMapper mapper;

        public object HttpContext { get; private set; }

        public MemberBL()
            {
            memberRepository = new MemberRepository();
            mapper = new EntityToDtoMapper();
            statusRepository = new MemberRequestStatusRepository();
            }


        public IEnumerable<MemberDTO> GetAll()
            {

            IEnumerable<Member> members = memberRepository.GetAll();
            if (members == null)
                return null;
            else
                return mapper.MemberToMemberDTOMapper(members);
            }


        public List<MemberRequestDTO> GetAllByStatus(RequestStatus status)
            {

            List<Member> members = memberRepository.GetAll();
            if (members == null || members.Count() == 0)
                return null;
            else
                {

                List<MemberRequestStatus> statuses = statusRepository.GetByRequestStatus(status);
                if (statuses == null || statuses.Count() == 0)
                    return null;
                else
                    {
                    List<MemberRequestDTO> memberRequestDTOs = (from m in members
                                                                       join s in statuses
                                                                       on m.MemberId equals s.MemberId

                                                                       select new MemberRequestDTO
                                                                           {
                                                                           MemberId = m.MemberId,
                                                                           AadharNumber = m.AadharNumber,
                                                                           IsApprover = m.IsApprover,
                                                                           Status = s.Status.ToString(),
                                                                           FullName = m.FirstName +" "+ m.LastName,
                                                                           Email = m.Email,
                                                                           Image = m.Image,
                                                                           Password = m.Password
                                                                           }).ToList();
                    return (memberRequestDTOs);
                    }
                }
            }

        
        public MemberRequestDTO GetByEmail(string email)
            {

            Member member = memberRepository.GetByEmail(email);
            if (member == null)
                return null;
            else
                {
                MemberRequestStatus requestStatus = statusRepository.GetById(member.MemberId);



                //MemberRequestDTO result = new MemberRequestDTO();
                return new MemberRequestDTO
                    {
                    MemberId = member.MemberId,
                    Email = member.Email,
                    AadharNumber = member.AadharNumber,
                    FullName = member.FirstName + " " + member.LastName,
                    Password = member.Password,
                    IsApprover = member.IsApprover,
                    Status = (requestStatus == null) ? "" : (requestStatus.Status.ToString()),
                    };
                }

            }

        public bool Create(MemberDTO memberDTO)
            {
            bool ifAdded = false;

            if (CheckValidityOfData(memberDTO))
                {
                Member member = mapper.MemberDTOToMemberMapper(memberDTO);
                if (EmailExists(member.Email) && AadharExists(member.AadharNumber))
                    {
                    return ifAdded;
                    }
                ifAdded = memberRepository.Create(member);
                }
            return ifAdded;
            }

        public bool EmailExists(string email)
            {
            IEnumerable<Member> members = memberRepository.GetAll();
            var result = (from m in members
                          where m.Email == email
                          select m).ToList();
            if (result.Count == 0)
                return false;
            else
                return true;
            }


        public bool AadharExists(string aadharNumber)
            {
            IEnumerable<Member> members = memberRepository.GetAll();
            var result = (from m in members
                          where m.AadharNumber == aadharNumber
                          select m).ToList();
            if (result.Count == 0)
                return false;
            else
                return true;
            }

        bool CheckValidityOfData(MemberDTO member)
            {
            if (string.IsNullOrWhiteSpace(member.AadharNumber) || string.IsNullOrWhiteSpace(member.Email) ||
              string.IsNullOrWhiteSpace(member.FirstName) || string.IsNullOrWhiteSpace(member.Image) ||
              string.IsNullOrWhiteSpace(member.LastName) || string.IsNullOrWhiteSpace(member.Password))
                {
                return false;
                }
            else
                {
                return true;
                }
            }





        public bool Update(int id, RequestStatus status)
            {
            bool ifUpdated = statusRepository.Update(id, status);
            return ifUpdated;
            }

        public bool DeleteById(int id)
            {
            bool ifDeleted = memberRepository.DeleteById(id);
            return ifDeleted;
            }

        //public MemberDTO GetByEmail(string email)
        //    {

        //    Member member = memberRepository.GetByEmail(email);
        //    if (member == null)
        //        return null;
        //    else


        //        return mapper.MemberToMemberDTOMapper(member);

        //    }

        //public IEnumerable<MemberRequestDTO> GetAllByStatus()
        //    {

        //    IEnumerable<Member> members = memberRepository.GetAll();
        //    IEnumerable<MemberRequestStatus> statuses = statusRepository.GetAll();
        //    if (members == null)
        //        return null;
        //    else
        //        {
        //        IEnumerable<MemberRequestDTO> memberRequestDTOs= (from m in members
        //                      join s in statuses
        //                      on m.MemberId equals s.MemberId
        //                      select new MemberRequestDTO
        //                          {
        //                          MemberId = m.MemberId,
        //                          AadharNumber = m.AadharNumber,
        //                          IsApprover=m.IsApprover,
        //                          Status=s.Status.ToString(),
        //                          FullName = m.FirstName + m.LastName,
        //                          Email = m.Email,
        //                          Image = m.Image,
        //                          Password = m.Password,
        //                          MemberRequestStatusId = s.MemberRequestStatusId,
        //                          });
        //        return (memberRequestDTOs);
        //        }
        //    }    



        //public string Create(MemberDTO memberDTO)
        //{
        //if (CheckValidityOfData(memberDTO))
        //    {
        //    Member member = mapper.MemberDTOToMemberMapper(memberDTO);
        //    if (EmailExists(member.Email))
        //        {
        //        return "Email Already Exists";

        //        }
        //    else
        //        {
        //        if (AadharExists(member.AadharNumber))
        //            return "AadharNumber Already Exists";
        //        else
        //            {
        //            memberRepository.Create(member);
        //            return "Member Created successfully";
        //            }
        //        }

        //    }
        //return "Invalid data";
        //}


        //public MemberDTO GetById(int id)
        //    {

        //    Member member = memberRepository.GetById(id);
        //    if (member == null)
        //        return null;
        //    else
        //        return mapper.MemberToMemberDTOMapper(member);
        //    }


        }

    }
