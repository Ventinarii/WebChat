using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Data
{
    [Table("UserServerJunction")]
    public class UserServerJunction
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Server")]
        public int ServerId { get; set; }

        public User User { get; set; }
        public Server Server { get; set; }
    }
}
