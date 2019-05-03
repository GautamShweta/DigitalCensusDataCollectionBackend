using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Enum;
using DAL.Entity;
using System.Data.Entity;

namespace DAL.Repository
    {
    public class MemberRequestStatusRepository
        {

        public MemberRequestStatus GetById(int id)
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                    MemberRequestStatus requestStatus = (from r in context.MemberRequestStatus
                                                         where r.MemberId == id
                                                         select r).Single();
                    return requestStatus;
                    }
                }
            catch
                {
                return null;
                }

            }

        public bool Create(int id)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    MemberRequestStatus requestStatus = new MemberRequestStatus();
                    requestStatus.MemberId = id;
                    requestStatus.Status = RequestStatus.PENDING;
                    context.MemberRequestStatus.Add(requestStatus);
                    context.SaveChanges();
                    return true;
                    }
                catch
                    {
                    return false;
                    }

                }

            }

        public bool Update(int id, RequestStatus status)
            {
            try
                {

                using (CensusDataContext context = new CensusDataContext())
                    {

                    MemberRequestStatus requestStatus = GetById(id);
                    if (requestStatus != null)
                        {
                        context.MemberRequestStatus.Attach(requestStatus);
                        requestStatus.Status = status;
                        context.SaveChanges();
                        return true;
                        }
                    else
                        return false;
                    }


                }
            catch
                {
                return false;
                }
            }

        //public IEnumerable<MemberRequestStatus> GetAll()
        //    {
        //    try
        //        {
        //        using (CensusDataContext context = new CensusDataContext())
        //            {
        //            IEnumerable<MemberRequestStatus> result = (from r in context.MemberRequestStatus
        //                                                       select r).ToList();
        //            return result;
        //            }
        //        }
        //    catch
        //        {
        //        return null;
        //        }

        //    }

        public List<MemberRequestStatus> GetByRequestStatus(RequestStatus requestStatus)
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                    List<MemberRequestStatus> result = (from r in context.MemberRequestStatus
                                                               where r.Status == requestStatus
                                                               select r).ToList();
                    return result;
                    }
                }
            catch
                {
                return null;
                }

            }
        }
    }
