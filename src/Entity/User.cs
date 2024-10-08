using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class User
    {
        public Guid UserId { get; set; }
        
        [StringLength(14, MinimumLength = 3, 
        ErrorMessage = "Username should be less than 15 letters & more than 2!")]
        public string Username { get; set; }
        // public int Score { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        public byte[]? Salt { get; set; }
    }
}