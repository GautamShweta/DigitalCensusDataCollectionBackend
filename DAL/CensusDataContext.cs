using System.Data.Entity;
namespace DAL.Entity
    {
    class CensusDataContext:DbContext
        {
        public CensusDataContext() : base("CensusDataContext")
            {
            
            }

        public DbSet<Member> Members { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<MemberRequestStatus>  MemberRequestStatus { get; set; }
        public DbSet<Person> Persons { get; set; }
        }
    }
