using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Repository
    {
    public class PersonRepository
        {

        public IEnumerable<Person> GetAll()
            {
            try
                {
                using (CensusDataContext context = new CensusDataContext())
                    {
                    IEnumerable<Person> persons = (from p in context.Persons
                                                   select p).ToList();
                    return persons;
                    }
                }
            catch
                {
                return null;
                }

            }
        
        public bool Create(Person person)
            {

            using (CensusDataContext context = new CensusDataContext())
                {


                try
                    {
                     var result= (from h in context.House
                                 where h.HouseId==person.CensusHouseNumber
                                 select h).Single();
                    if (result == null)
                        throw new Exception();

                    context.Persons.Add(person);
                    context.SaveChanges();
                    return true;
                    }
                catch(Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    return false;
                    }

                }

            }

        public IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate)
            {
                CensusDataContext context = new CensusDataContext();
                
                return context.Persons.Where(predicate);
                
            }

        //public bool DeleteById(int id)
        //    {
        //    try
        //        {
        //        using (CensusDataContext context = new CensusDataContext())
        //            {
        //            var result = (from p in context.Persons
        //                          where p.PersonId == id
        //                          select p).ToList().First();

        //            context.Persons.Remove(result);
        //            context.SaveChanges();
        //            return true;
        //            }
        //        }
        //    catch
        //        {
        //        return false;
        //        }
        //    }

        //public Person GetById(int id)
        //    {

        //    using (CensusDataContext context = new CensusDataContext())
        //        {
        //        try
        //            {
        //            Person person = (from p in context.Persons
        //                             where p.PersonId== id
        //                             select p).Single();
        //            return person;
        //            }
        //        catch
        //            {
        //            return null;
        //            }

        //        }

        //    }

        }

    }
