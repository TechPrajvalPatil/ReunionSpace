using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }



            modelBuilder.Entity<Admin>().HasData(
                new Admin()
                {
                    AdminId = 1,
                    FirstName="Abhishek",
                    LastName="Kashid",
                    ContactNo="8275111415",
                    EmailId="percyakr11@gmail.com",
                    Password="1234"
                }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country() { CountryId = 1,CountryName="India" }
                );

            modelBuilder.Entity<State>().HasData(
                new State() { StateId=1,StateName="Maharashtra",CountryId=1}
                );

            modelBuilder.Entity<City>().HasData(
                new City() { CityId=1,CityName="Kolhapur",StateId=1}
                );
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAdmin> CompanyAdmins { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistrations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberConnection> MemberConnections { get; set; }
        public DbSet<MemberConnectionRequest> MemberConnectionsRequest { get; set; }
        public DbSet<MemberRequest> MembersRequests { get; set; }
        public DbSet<MemberCourseDet> MemberCourseDets { get; set; }
        public DbSet<Feeds> Feeds { get; set; }
        public DbSet<FeedsPhoto> FeedsPhotos { get; set; }
        public DbSet<FeedsVideo> FeedsVideos { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollsOptions { get; set; }
        public DbSet<PollResponse> PollsResponses { get; set; }
        public DbSet<PollResponseOption> PollsResponsesOptions { get; set; }  
        public DbSet<Job> Jobs { get; set; }
        public DbSet<MemberEducation> MemberEducations { get; set; }
        public DbSet<MemberExperience> MemberExperiences { get; set; }
        public DbSet<MemberResume> MemberResumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MemberSkills> MemberSkills { get; set; }   

        
    }
}
