using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        [Column("address")]
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Address { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(60)]
        [MinLength(8)]
        public string Password { get; set; }

        [Column("role")]
        [Required] 
        public bool? Role { get; set; }

        public User(string name, string address, string password, bool role)
        {
            Name = name.ToLower().Trim();
            Address = address.ToLower().Trim();
            Password = password;
            Role = role;
        }
    }
}