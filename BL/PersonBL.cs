using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Helper;
using DAL.Entity;
using DAL.Repository;
using Shared.DTO;

namespace BL
    {
    public class PersonBL
        {
        PersonRepository personRepository;
        EntityToDtoMapper mapper;

        public PersonBL()
            {
            personRepository = new PersonRepository();
            mapper = new EntityToDtoMapper();
            }


        public IEnumerable<PersonDTO> GetAll()
            {

            IEnumerable<Person> persons = personRepository.GetAll();
            if (persons == null)
                return null;
            return mapper.PersonToPersonDTOMapper(persons);
            }

        public bool CensusHouseNumberExists(int houseNumber)
            {
            IEnumerable<House> houses = new HouseRepository().GetAll();
            var result = (from h in houses
                          where h.HouseId == houseNumber
                          select h).ToList();
            if (result.Count == 0)
                return false;
            else
                return true;
            }

        public bool Create(PersonDTO personDTO)
            {
            bool ifAdded = false;

            if (CensusHouseNumberExists(personDTO.CensusHouseNumber) && CheckValidityOfData(personDTO))
                {
                Person person = mapper.PersonDTOToPersonMapper(personDTO);

                ifAdded = personRepository.Create(person);
                }
            return ifAdded;
            }

        bool CheckValidityOfData(PersonDTO person)
            {
            if (string.IsNullOrWhiteSpace(person.FullName) || string.IsNullOrWhiteSpace(person.AgeAtMarriage.ToString())
                || string.IsNullOrWhiteSpace(person.BirthDate.ToString()) || string.IsNullOrWhiteSpace(person.Gender.ToString())
                || string.IsNullOrWhiteSpace(person.MaritalStatus.ToString()) || string.IsNullOrWhiteSpace(person.NatureOfOccupation.ToString())
                || string.IsNullOrWhiteSpace(person.Occupation.ToString()) || string.IsNullOrWhiteSpace(person.RelToHead.ToString()))
                {
                return false;
                }
            else
                {
                return true;
                }
            }

        //public PersonDTO GetById(int id)
        //    {

        //    Person person = personRepository.GetById(id);
        //    if (person == null)
        //        return null;
        //    else
        //        return mapper.PersonToPersonDTOMapper(person);
        //    }

        


        //public bool DeleteById(int id)
        //    {
        //    bool ifDeleted = personRepository.DeleteById(id);
        //    return ifDeleted;
        //    }

       
       


        //public bool UpdateMember(int id,MemberDTO member)
        //    {
        //    bool ifUpdated = memberRepository.UpdateMember(id,member);
        //    return ifUpdated;
        //    }
        }
    }
