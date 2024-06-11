﻿
namespace PatientManagerApp.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
        public int ClinicId { get; set; }
        
    }
}
