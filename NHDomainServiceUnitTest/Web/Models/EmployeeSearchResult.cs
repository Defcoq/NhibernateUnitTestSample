using System;

namespace Web.Models
{
    public class EmployeeSearchResult
    {
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Designation { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime DateOfJoining { get; set; }
    }
}