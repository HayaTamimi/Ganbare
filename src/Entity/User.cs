using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ganbare.src.Entity
{
    public class User
    {
        public Guid UserId { get; set; }

        [StringLength(14, MinimumLength = 3,
        ErrorMessage = "Username should be less than 15 letters & more than 2!"), Required]
        public required string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        public byte[]? Salt { get; set; }
        public Role Role { get; set; } = Role.Customer;

        // the quiz list can make us do a lot of things
        public List<Quiz> Quizzes { get; set; } // if it's array it's ok to be without ?
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Role
    {
        Admin,
        Customer,
    }
}