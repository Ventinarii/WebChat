using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebServer.Data;

namespace WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChatDbContext.Context.Users.RemoveRange(ChatDbContext.Context.Users.ToList());
            ChatDbContext.Context.Servers.RemoveRange(ChatDbContext.Context.Servers.ToList());

            ChatDbContext.Context.Users.Add(new User() { Name = "Tom" });
            ChatDbContext.Context.Servers.Add(new Server() { Name = "Tom" });

            ChatDbContext.Context.SaveChanges();

            ChatDbContext.Context.Users.ToList()[0].AddUserServerJunction(ChatDbContext.Context.Servers.ToList()[0]);

            ChatDbContext.Context.SaveChanges();

            List<User> value1 = ChatDbContext.Context.Users.ToList();
            List<Server> value2 = ChatDbContext.Context.Servers.ToList();
            var x = 2 + 3;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
