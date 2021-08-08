using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InsuranceClaimsApp.ContextData
{
    [Table("Users")]
    public class User
    {
        public User(string username, string displayName, string password, bool isActive = true)
        {
            UserName = username;
            Password = password;
            DisplayName = displayName;
            Active = isActive;
        }
        [Key]
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string DisplayName { get; private set; }
        public bool? Active { get; private set; }

        private User()
        {

        }
    }
}
