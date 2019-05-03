using System.Collections.Generic;
using AutoMapper;
using DAL.Entity;
using Shared.DTO;
namespace BL.Helper
    {
    public class EntityToDtoMapper
        {
         IMapper Mapper;
        public EntityToDtoMapper()
            {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDTO>().ReverseMap();
                cfg.CreateMap<House, HouseDTO>().ReverseMap();
                cfg.CreateMap<Person, PersonDTO>().ReverseMap();

            });
            Mapper = config.CreateMapper();
            }
         
        public Member MemberDTOToMemberMapper(MemberDTO memberDTO)
            {
            return Mapper.Map<Member>(memberDTO);

            }

        public IEnumerable<Member> MemberDTOToMemberMapper(IEnumerable<MemberDTO> memberDTOS)
            {

            return Mapper.Map<IEnumerable<Member>>(memberDTOS);
            }


        public MemberDTO MemberToMemberDTOMapper(Member member)
            {
            return Mapper.Map<MemberDTO>(member);

            }

        public IEnumerable<MemberDTO> MemberToMemberDTOMapper(IEnumerable<Member> members)
            {
              return Mapper.Map<IEnumerable<MemberDTO>>(members);

            }


        //*****************************************************************//
        public House HouseDTOToHouseMapper(HouseDTO houseDTO)
            {
            return Mapper.Map<House>(houseDTO);

            }

        public IEnumerable<House> HouseDTOToHouseMapper(IEnumerable<HouseDTO> houseDTOS)
            {

            return Mapper.Map<IEnumerable<House>>(houseDTOS);
            }


        public HouseDTO HouseToHouseDTOMapper(House house)
            {
            return Mapper.Map<HouseDTO>(house);

            }

        public IEnumerable<HouseDTO> HouseToHouseDTOMapper(IEnumerable<House> houses)
            {
            return Mapper.Map<IEnumerable<HouseDTO>>(houses);

            }
        //************************************************************//
        public Person PersonDTOToPersonMapper(PersonDTO personDTO)
            {
            return Mapper.Map<Person>(personDTO);

            }

        public IEnumerable<Person> PersonDTOToPersonMapper(IEnumerable<PersonDTO> personDTOS)
            {

            return Mapper.Map<IEnumerable<Person>>(personDTOS);
            }


        public PersonDTO PersonToPersonDTOMapper(Person person)
            {
            return Mapper.Map<PersonDTO>(person);

            }

        public IEnumerable<PersonDTO> PersonToPersonDTOMapper(IEnumerable<Person> persons)
            {
            return Mapper.Map<IEnumerable<PersonDTO>>(persons);

            }


        }
    }


