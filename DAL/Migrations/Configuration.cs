namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entity.CensusDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entity.CensusDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var members = new List<Member> {
            new Member { Email = "admin@nagarro.com", Password = "Shweta@1234", FirstName = "Shweta", LastName = "Gautam", Image = "‪‪+91-98723190952120.jpg", AadharNumber = "012395678921", IsApprover = true },

                };



            members.ForEach(m => context.Members.AddOrUpdate(m));
            context.SaveChanges();
            }
        }
    }

