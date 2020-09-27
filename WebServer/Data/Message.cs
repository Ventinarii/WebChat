using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Data
{
    [Table("Message")]
    public class Message
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(Order = 3)]
        [ForeignKey("Server")]
        public int ServerId { get; set; }

        public User User { get; set; }
        public Server Server { get; set; }

        public string Said { get; set; }
        public string NickAtTheTime { get; set; }
    }
}
