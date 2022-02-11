using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Entity.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }      
    }
}
