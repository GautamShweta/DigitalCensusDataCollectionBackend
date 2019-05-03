using System.Collections.Generic;
using System.Linq;
using BL.Helper;
using DAL.Entity;
using DAL.Repository;
using Shared.DTO;

namespace BL
    {
    public class HouseBL
        {
        HouseRepository houseRepository;
        EntityToDtoMapper mapper;
        PersonRepository personRepository;

        public HouseBL()
            {
            houseRepository = new HouseRepository();
            mapper = new EntityToDtoMapper();
            personRepository = new PersonRepository();
            }


        public IEnumerable<HouseDTO> GetAll()
            {

            IEnumerable<House> houses = houseRepository.GetAll();
            if(houses==null)
                {
                return null;
                }
            return mapper.HouseToHouseDTOMapper(houses);
            }


        public HouseDTO GetById(int id)
            {

            House house = houseRepository.GetById(id);
            if (house == null)
                return null;
            else
                return mapper.HouseToHouseDTOMapper(house);
            }

        public HouseDTO Create(HouseDTO houseDTO)
            {

            if (CheckValidityOfData(houseDTO))
                {
                
                House house = houseRepository.Create(mapper.HouseDTOToHouseMapper(houseDTO));
                return (house != null) ? mapper.HouseToHouseDTOMapper(house) : null;
                }
            return null;
            }


        public bool DeleteById(int id)
            {
            bool ifDeleted = houseRepository.DeleteById(id);
            return ifDeleted;
            }

        bool CheckValidityOfData(HouseDTO houseDTO)
            {
            if (string.IsNullOrWhiteSpace(houseDTO.ApartmentNumber) || string.IsNullOrWhiteSpace(houseDTO.HeadName) ||
               string.IsNullOrWhiteSpace( (houseDTO.NumberOfRooms).ToString() )|| string.IsNullOrWhiteSpace(houseDTO.State) ||
              string.IsNullOrWhiteSpace(houseDTO.StreetName)||string.IsNullOrWhiteSpace(houseDTO.OwnershipStatus.ToString()))
                {
                return false;
                }
            else
                {
                return true;
                }
            }
        public List<int> StatePopulation()
            {
            List<string> StateArray = new List<string>() { "Andaman & Nicobar", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra & Nagar Haveli", "Daman & Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu & Kashmir", "Jharkhand", "Karnataka", "Kerala", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Orissa", "Pondicherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Tripura", "Uttar Pradesh", "Uttaranchal", "West Bengal" };
            List<int> statePopulation = new List<int>();
            foreach (string state in StateArray)
                {

                List<House> houses = houseRepository.Find(house => house.State == state).ToList();
                if (houses.Count == 0)
                    {
                    statePopulation.Add(0);
                    }
                else
                    {
                    int populationCount = 0;
                    foreach (House house in houses)
                        {
                        int counted = this.personRepository.Find(houseMember => houseMember.CensusHouseNumber == house.HouseId).ToList().Count;
                        populationCount = populationCount + counted;
                        }
                    statePopulation.Add(populationCount);


                    }
                }
            return statePopulation;



            }


        //public bool UpdateMember(int id,MemberDTO member)
        //    {
        //    bool ifUpdated = memberRepository.UpdateMember(id,member);
        //    return ifUpdated;
        //    }


        }
    }
