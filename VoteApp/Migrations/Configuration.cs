using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;
using VoteApp.Models;

namespace VoteApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VoteApp.Models.VoteAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "VoteApp.Models.VoteAppContext";
        }

        protected override void Seed(VoteApp.Models.VoteAppContext context)
        {
            new TestSeeder(context).Seed();
        }
    }
}



