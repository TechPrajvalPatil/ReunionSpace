using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberTbl")]
    public class Member
    {
        [Key]
        public Int64 MemberId {  get; set; }
        public string FirstName { get; set; }
        public string LastName {  get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string MobileNo {  get; set; }
        public string Address {  get; set; }
        [ForeignKey("City")]
        public Int64 CityId {  get; set; }
        public virtual City City { get; set; }
        public string DateOfBirth {  get; set; }
        public GenderEnum Gender { get; set; }
        [NotMapped]
        public IFormFile ProfileFile { get; set; }
        public string ProfilePicture {  get; set; }
        public string EmailId {  get; set; }
        public string Password {  get; set; }
        public bool IsActive {  get; set; }
        public virtual List<MemberRequest> MemberRequests { get; set; }
        public virtual List<MemberCourseDet> MemberCourseDets { get; set; }
        public virtual List<MemberConnection> MemberConnections { get; set; }  
        public virtual List<EventRegistration> EventRegistrations { get; set; }
        public virtual List<PollResponse> PollResponses { get; set; }
        public virtual List<Feeds> Feeds { get; set; }
        public virtual List<MemberEducation> MemberEducations { get; set; } 
        public virtual List<MemberExperience> MemberExperiences { get; set; }
        public virtual List<MemberResume> MemberResumes { get; set; }
        
        public Member()
        {
            MemberRequests = new List<MemberRequest>();
            MemberCourseDets = new List<MemberCourseDet>();
        }

    }
}
