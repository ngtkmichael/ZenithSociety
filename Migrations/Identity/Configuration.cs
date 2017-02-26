namespace ZenithWebSite.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (userManager.FindByEmail("a@a.a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a@a.a",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            if (userManager.FindByEmail("m@m.m") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m@m.m",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
            }

            if (userManager.FindByEmail("doe1@Zenith.org") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "doe1@Zenith.org",
                    UserName = "doe1@Zenith.org",
                };
                var result = userManager.Create(user, "jdoe1@Zenith");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            // Activities & Events
            context.Activities.AddOrUpdate(
                a => new { a.ActivityDescription, a.CreationDate }, ApplicationDbContext.getActivities().ToArray());
            
            context.Events.AddOrUpdate(
                e => new { e.EventFromDatetime, e.EventToDatetime, e.CreationUsername, e.CreationDate, e.IsActive }, ApplicationDbContext.getEvents(context).ToArray());

        }
    }
}
