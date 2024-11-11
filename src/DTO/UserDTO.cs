using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;

namespace ganbare.src.DTO
{
    public class UserDTO
    {
        public class UserCreateDto
        {
            [StringLength(14, MinimumLength = 3,
            ErrorMessage = "Username should be less than 15 letters & more than 2!")]
            public required string Username { get; set; }

            [EmailAddress, Required]
            public string Email { get; set; }

            public Role Role { get; set; } = Role.Customer;


            [DataType(DataType.Password), Required]
            public string Password { get; set; }
        }

        public class UserSigninDto
        {
            [EmailAddress, Required]
            public string Email { get; set; }

            [DataType(DataType.Password), Required]
            public string Password { get; set; }

            public Role Role { get; set; }

        }

        public class UserReadDto
        {
            public Guid UserId { get; set; }
            public required string Username { get; set; }
            public string Email { get; set; }
            public Role Role { get; set; }

        }

        public class UserUpdateDto
        {
            [StringLength(14, MinimumLength = 3,
            ErrorMessage = "Username should be less than 15 letters & more than 2!")]
            public required string Username { get; set; }
            public string? Email { get; set; }
            // public string? Password { get; set; }
            // public byte[]? Salt { get; set; }
        }
    }
}