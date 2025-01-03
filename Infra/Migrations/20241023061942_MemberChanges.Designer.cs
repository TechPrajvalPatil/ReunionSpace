﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241023061942_MemberChanges")]
    partial class MemberChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Admin", b =>
                {
                    b.Property<long>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AdminId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("AdminTbl");

                    b.HasData(
                        new
                        {
                            AdminId = 1L,
                            ContactNo = "8275111415",
                            EmailId = "percyakr11@gmail.com",
                            FirstName = "Abhishek",
                            LastName = "Kashid",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("Core.City", b =>
                {
                    b.Property<long>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CityId"));

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("CityTbl");

                    b.HasData(
                        new
                        {
                            CityId = 1L,
                            CityName = "Kolhapur",
                            StateId = 1L
                        });
                });

            modelBuilder.Entity("Core.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CompanyId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("CityId");

                    b.ToTable("CompanyTbl");
                });

            modelBuilder.Entity("Core.CompanyAdmin", b =>
                {
                    b.Property<long>("CompanyAdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CompanyAdminId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyAdminId");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAdminTbl");
                });

            modelBuilder.Entity("Core.Country", b =>
                {
                    b.Property<long>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CountryId"));

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("CountryTbl");

                    b.HasData(
                        new
                        {
                            CountryId = 1L,
                            CountryName = "India"
                        });
                });

            modelBuilder.Entity("Core.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EventId"));

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventMode")
                        .HasColumnType("int");

                    b.Property<string>("EventShortDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<long>("MemberLimit")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegistrationFromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegistrationToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EventId");

                    b.HasIndex("CreatedById");

                    b.ToTable("EventTbl");
                });

            modelBuilder.Entity("Core.EventRegistration", b =>
                {
                    b.Property<long>("EventRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EventRegistrationId"));

                    b.Property<long>("AcceptedById")
                        .HasColumnType("bigint");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EventRegistrationId");

                    b.HasIndex("AcceptedById");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("EventRegistrationTbl");
                });

            modelBuilder.Entity("Core.Feeds", b =>
                {
                    b.Property<long>("FeedsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FeedsId"));

                    b.Property<int>("FeedStatus")
                        .HasColumnType("int");

                    b.Property<int>("FeedType")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("FeedsId");

                    b.HasIndex("MemberId");

                    b.ToTable("FeedsTbl");
                });

            modelBuilder.Entity("Core.FeedsPhoto", b =>
                {
                    b.Property<long>("FeedsPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FeedsPhotoId"));

                    b.Property<long>("FeedsId")
                        .HasColumnType("bigint");

                    b.Property<string>("PhotoPathFile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedsPhotoId");

                    b.HasIndex("FeedsId");

                    b.ToTable("FeedsPhoto");
                });

            modelBuilder.Entity("Core.FeedsVideo", b =>
                {
                    b.Property<long>("FeedsVideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FeedsVideoId"));

                    b.Property<long>("FeedsId")
                        .HasColumnType("bigint");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedsVideoId");

                    b.HasIndex("FeedsId");

                    b.ToTable("FeedsVideo");
                });

            modelBuilder.Entity("Core.Member", b =>
                {
                    b.Property<long>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.HasIndex("CityId");

                    b.ToTable("MemberTbl");
                });

            modelBuilder.Entity("Core.MemberConnection", b =>
                {
                    b.Property<long>("MemberConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberConnectionId"));

                    b.Property<DateTime>("AcceptDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ConnectedMemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("ConnectionRequestId")
                        .HasColumnType("bigint");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("MemberConnectionId");

                    b.HasIndex("ConnectionRequestId");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberConnectionTbl");
                });

            modelBuilder.Entity("Core.MemberConnectionRequest", b =>
                {
                    b.Property<long>("MemberConnectionRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberConnectionRequestId"));

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RequestFromID")
                        .HasColumnType("bigint");

                    b.Property<string>("RequestNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<long>("RequestToID")
                        .HasColumnType("bigint");

                    b.HasKey("MemberConnectionRequestId");

                    b.ToTable("MemberConnectionRequestTbl");
                });

            modelBuilder.Entity("Core.MemberCourseDet", b =>
                {
                    b.Property<long>("MemberCourseDetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberCourseDetId"));

                    b.Property<string>("AttendedYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("MemberCourseDetId");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberCourseDetTbl");
                });

            modelBuilder.Entity("Core.MemberRequest", b =>
                {
                    b.Property<long>("MemberRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberRequestId"));

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.HasKey("MemberRequestId");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberRequestTbl");
                });

            modelBuilder.Entity("Core.Poll", b =>
                {
                    b.Property<long>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PollId"));

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PollDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PollQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PollStatus")
                        .HasColumnType("int");

                    b.HasKey("PollId");

                    b.HasIndex("CreatedById");

                    b.ToTable("PollTbl");
                });

            modelBuilder.Entity("Core.PollOption", b =>
                {
                    b.Property<long>("PollOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PollOptionId"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("Option")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PollId")
                        .HasColumnType("bigint");

                    b.HasKey("PollOptionId");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptionTbl");
                });

            modelBuilder.Entity("Core.PollResponse", b =>
                {
                    b.Property<long>("PollResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PollResponseId"));

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("PollId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PollResponseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PollResponseId");

                    b.HasIndex("MemberId");

                    b.HasIndex("PollId");

                    b.ToTable("PollResponseTbl");
                });

            modelBuilder.Entity("Core.PollResponseOption", b =>
                {
                    b.Property<long>("PollResponseOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PollResponseOptionId"));

                    b.Property<long>("PollOptionId")
                        .HasColumnType("bigint");

                    b.Property<long>("PollResponseID")
                        .HasColumnType("bigint");

                    b.HasKey("PollResponseOptionId");

                    b.HasIndex("PollOptionId");

                    b.HasIndex("PollResponseID");

                    b.ToTable("PollResponseOptionTbl");
                });

            modelBuilder.Entity("Core.State", b =>
                {
                    b.Property<long>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StateId"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("StateTbl");

                    b.HasData(
                        new
                        {
                            StateId = 1L,
                            CountryId = 1L,
                            StateName = "Maharashtra"
                        });
                });

            modelBuilder.Entity("Core.City", b =>
                {
                    b.HasOne("Core.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Core.Company", b =>
                {
                    b.HasOne("Core.City", "City")
                        .WithMany("Companies")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Core.CompanyAdmin", b =>
                {
                    b.HasOne("Core.City", "City")
                        .WithMany("CompanyAdmins")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Company", "Company")
                        .WithMany("CompanyAdmins")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Core.Event", b =>
                {
                    b.HasOne("Core.CompanyAdmin", "CompanyAdmin")
                        .WithMany("Events")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CompanyAdmin");
                });

            modelBuilder.Entity("Core.EventRegistration", b =>
                {
                    b.HasOne("Core.CompanyAdmin", "CompanyAdmin")
                        .WithMany()
                        .HasForeignKey("AcceptedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Event", "Event")
                        .WithMany("EventRegistrations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Member", "Member")
                        .WithMany("EventRegistrations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CompanyAdmin");

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Feeds", b =>
                {
                    b.HasOne("Core.Member", "Member")
                        .WithMany("Feeds")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.FeedsPhoto", b =>
                {
                    b.HasOne("Core.Feeds", "Feeds")
                        .WithMany("FeedsPhotos")
                        .HasForeignKey("FeedsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Feeds");
                });

            modelBuilder.Entity("Core.FeedsVideo", b =>
                {
                    b.HasOne("Core.Feeds", "Feeds")
                        .WithMany("FeedsVideos")
                        .HasForeignKey("FeedsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Feeds");
                });

            modelBuilder.Entity("Core.Member", b =>
                {
                    b.HasOne("Core.City", "City")
                        .WithMany("Members")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Core.MemberConnection", b =>
                {
                    b.HasOne("Core.MemberConnectionRequest", "ConnectionRequest")
                        .WithMany("MemberConnections")
                        .HasForeignKey("ConnectionRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Member", "Member")
                        .WithMany("MemberConnections")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConnectionRequest");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.MemberCourseDet", b =>
                {
                    b.HasOne("Core.Member", "Member")
                        .WithMany("MemberCourseDets")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.MemberRequest", b =>
                {
                    b.HasOne("Core.Member", "Member")
                        .WithMany("MemberRequests")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Poll", b =>
                {
                    b.HasOne("Core.CompanyAdmin", "CompanyAdmin")
                        .WithMany("Polls")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CompanyAdmin");
                });

            modelBuilder.Entity("Core.PollOption", b =>
                {
                    b.HasOne("Core.Poll", "Poll")
                        .WithMany("PollOptions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Core.PollResponse", b =>
                {
                    b.HasOne("Core.Member", "Member")
                        .WithMany("PollResponses")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Poll", "Poll")
                        .WithMany("PollResponses")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Core.PollResponseOption", b =>
                {
                    b.HasOne("Core.PollOption", "PollOption")
                        .WithMany("PollResponseOptions")
                        .HasForeignKey("PollOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.PollResponse", "PollResponse")
                        .WithMany("PollResponseOptions")
                        .HasForeignKey("PollResponseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PollOption");

                    b.Navigation("PollResponse");
                });

            modelBuilder.Entity("Core.State", b =>
                {
                    b.HasOne("Core.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.City", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("CompanyAdmins");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("Core.Company", b =>
                {
                    b.Navigation("CompanyAdmins");
                });

            modelBuilder.Entity("Core.CompanyAdmin", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Polls");
                });

            modelBuilder.Entity("Core.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Core.Event", b =>
                {
                    b.Navigation("EventRegistrations");
                });

            modelBuilder.Entity("Core.Feeds", b =>
                {
                    b.Navigation("FeedsPhotos");

                    b.Navigation("FeedsVideos");
                });

            modelBuilder.Entity("Core.Member", b =>
                {
                    b.Navigation("EventRegistrations");

                    b.Navigation("Feeds");

                    b.Navigation("MemberConnections");

                    b.Navigation("MemberCourseDets");

                    b.Navigation("MemberRequests");

                    b.Navigation("PollResponses");
                });

            modelBuilder.Entity("Core.MemberConnectionRequest", b =>
                {
                    b.Navigation("MemberConnections");
                });

            modelBuilder.Entity("Core.Poll", b =>
                {
                    b.Navigation("PollOptions");

                    b.Navigation("PollResponses");
                });

            modelBuilder.Entity("Core.PollOption", b =>
                {
                    b.Navigation("PollResponseOptions");
                });

            modelBuilder.Entity("Core.PollResponse", b =>
                {
                    b.Navigation("PollResponseOptions");
                });

            modelBuilder.Entity("Core.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
