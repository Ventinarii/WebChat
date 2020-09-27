using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace WebServer.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserServerJunction> IsOnServers { get; set; }

        public void AddUserServerJunction(Server server) {
            if (IsOnServers == null)
                IsOnServers = new List<UserServerJunction>();
            if (server.AreOnServer == null)
                server.AreOnServer = new List<UserServerJunction>();
            //null poiter exception fix

            if (IsOnServers.Exists(
                junction => junction.Server.Id==server.Id)
                ) 
            {
                return;
            }
            //this connection already exists

            var junction = new UserServerJunction()
            {
                User = this,
                Server = server
            };
            //create new junction

            IsOnServers.Add(junction);
            server.AreOnServer.Add(junction);
        }
        public void RemoveUserServerJunction(Server server)
        {
            IsOnServers.RemoveAt(
                IsOnServers.FindIndex(
                    junction => junction.Server.Id == server.Id
                    )
            );

            server.AreOnServer.RemoveAt(
                server.AreOnServer.FindIndex(
                    junction => junction.User.Id == Id
                    )
            );
        }
    }
}
