using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Entity;

namespace DAL.Repository
    {
    public class HouseRepository
        {


        public IEnumerable<House> GetAll()
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                    IEnumerable<House> houses = (from h in context.House
                                                 select h).ToList();
                    return houses;
                    }
                }
            catch
                {
                return null;
                }

            }


        public House GetById(int id)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    House house = (from h in context.House
                                   where h.HouseId == id
                                   select h).Single();
                    return house;
                    }
                catch
                    {
                    return null;
                    }
                }

            }
        public House Create(House house)
            {

            using (CensusDataContext context = new CensusDataContext())
                {
                try
                    {
                    context.House.Add(house);
                    context.SaveChanges();
                    return house;
                    }
                catch
                    {
                    return null;
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
                    var result = (from m in context.House
                                  where m.HouseId == id
                                  select m).ToList().First();

                    context.House.Remove(result);
                    context.SaveChanges();
                    return true;
                    }
                }
            catch
                {
                return false;
                }
            }

        public IEnumerable<House> Find(Expression<Func<House, bool>> predicate)
            {
                   CensusDataContext context = new CensusDataContext();
                
                   return context.House.Where(predicate);

                
            }

        }
    }
    
