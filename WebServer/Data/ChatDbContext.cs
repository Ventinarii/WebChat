using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebServer.Data
{
    public class ChatDbContext : DbContext
    {
        public static ChatDbContext Context {
            get {
                if (context == null) 
                {
                    context = new ChatDbContext();
                }

                return context;
            }
        }
        private static ChatDbContext context = null;

        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
