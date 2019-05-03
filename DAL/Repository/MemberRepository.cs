using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;

namespace DAL.Repository
    {
    public class MemberRepository
        {


         public List<Member> GetAll()
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                      List<Member> members = (from m in context.Members
                                                   select m).ToList();
                    return members;
                    }
                }
            catch
                {
                return null;
                }

            }
         public Member GetById(int id)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    Member member = (from m in context.Members
                                     where m.MemberId == id
                                     select m).Single();
                    return member;
                    }
                catch
                    {
                    return null;
                    }
               
                }

            }
        public Member GetByEmail(string email)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    Member member = (from m in context.Members
                                     where m.Email == email
                                     select m).Single();
                    return member;
                    }
                catch
                    {
                    return null;
                    }

                }

            }
        public bool Create(Member member)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    context.Members.Add(member);
                    context.SaveChanges();
                    if(new MemberRequestStatusRepository().Create(member.MemberId))
                        {

                        return true;
                        }
                    context.Members.Remove(member);
                    context.SaveChanges();
                    return false;
                    }
                catch
                    {
                    return false;
                    }

                }

            }

        //public bool UpdateMember(Member member)
        //    {
        //    try
        //        {
        //        using (CensusDataContext context = new CensusDataContext())
        //            {
        //            context.Entry(member).State = EntityState.Modified;
        //            context.SaveChanges();
        //            return true;
        //            }
        //        }
        //    catch
        //        {
        //        return false;
        //        }

        //    }

        public bool DeleteById(int id)
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                    var memberEntry = (from m in context.Members
                                  where m.MemberId == id
                                  select m).ToList().First();

                    var requestStatusEntry = (from r in context.MemberRequestStatus
                                              where r.MemberId == id
                                              select r).ToList().First();

                    context.Members.Remove(memberEntry);
                    context.MemberRequestStatus.Remove(requestStatusEntry);
                    context.SaveChanges();
                    return true;
                    }
                }
            catch
                {
                return false;
                }
            }


        }
    }
