using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Data
{
    [Table("Server")]
    public class Server
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserServerJunction> AreOnServer { get; set; }

        public void AddUserServerJunction(User user)
        {
            if (user.IsOnServers == null)
                user.IsOnServers = new List<UserServerJunction>();
            if (AreOnServer == null)
                AreOnServer = new List<UserServerJunction>();
            //null poiter exception fix

            if (AreOnServer.Exists(
                junction => junction.User.Id == user.Id)
                )
            {
                return;
            }
            //this connection already exists

            var junction = new UserServerJunction()
            {
                User = user,
                Server = this
            };
            //create new junction

            user.IsOnServers.Add(junction);
            AreOnServer.Add(junction);
        }
        public void RemoveUserServerJunction(User user)
        {
            user.IsOnServers.RemoveAt(
                user.IsOnServers.FindIndex(
                    junction => junction.Server.Id == Id
                    )
            );

            AreOnServer.RemoveAt(
                AreOnServer.FindIndex(
                    junction => junction.User.Id == user.Id
                    )
            );
        }
    }
}
