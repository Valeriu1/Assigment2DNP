using System.ComponentModel.DataAnnotations;

namespace Assigment3WebApiDatabase.Models
{
    public class User {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        // public string Role { get; set; }
        // public int SecurityLevel { get; set; }

    }
}