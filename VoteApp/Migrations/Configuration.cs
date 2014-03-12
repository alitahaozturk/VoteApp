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
            CreateTestData();
            UpdateDatase(context);
        }

        public List<User> TestUsers { get; set; }
        public List<Poll> TestPolls { get; set; }
        public List<Option> TestOptions { get; set; }
        public List<Vote> TestVotes { get; set; }

        public void CreateTestData()
        {
            TestUsers = new List<User>();
            TestPolls = new List<Poll>();
            TestOptions = new List<Option>();
            TestVotes = new List<Vote>();

            // Create some users
            TestUsers.AddRange(new List<User> 
            {
                new User{UserId=1, AspNetUserId="test1_temp",FullName="test1"},
                new User{UserId=2, AspNetUserId="test2_temp",FullName="test2"},
                new User{UserId=3, AspNetUserId="test3_temp",FullName="test3"},
                new User{UserId=4, AspNetUserId="test4_temp",FullName="test4"},
            });

            // Create some polls and options

            DateTime last = DateTime.Now.AddDays(3);

            TestPolls.Add(new Poll { PollId = 1, UserId = 1, Name = "test poll", Description = "test desc", IsHidden = false, LastVoteDate = last });
            TestOptions.AddRange(new List<Option>
            {
                new Option { OptionId = 1, PollId = 1, Value = "tp1 choice 1" },
                new Option { OptionId = 2, PollId = 1, Value = "tp1 choice 2" },
                new Option { OptionId = 3, PollId = 1, Value = "tp1 choice 3" },
                new Option { OptionId = 4, PollId = 1, Value = "tp1 choice 4" },
            });


            TestPolls.Add(new Poll { PollId = 2, UserId = 1, Name = "test poll 2", Description = "test desc 2", IsHidden = false, LastVoteDate = last });
            TestOptions.AddRange(new List<Option>
            {
                new Option { OptionId = 11, PollId = 2, Value = "tp1 choice 1" },
                new Option { OptionId = 12, PollId = 2, Value = "tp2 choice 2" },
                new Option { OptionId = 13, PollId = 2, Value = "tp3 choice 3" },
                new Option { OptionId = 14, PollId = 2, Value = "tp4 choice 4" },
            });

            // Create some Votes
            TestVotes.AddRange(new List<Vote>
            {
                //new Vote { VoteId = 1,  UserId = 2, OptionId = 3  },
                //new Vote { VoteId = 2,  UserId = 4, OptionId = 4  },
                //new Vote { VoteId = 11, UserId = 3, OptionId = 2 },
                //new Vote { VoteId = 12, UserId = 4, OptionId = 2 },
            });


        }

        public void UpdateDatase(VoteAppContext db)
        {
            TestUsers.ForEach(u => db.Users.Add(u));
            db.SaveChanges();
            TestPolls.ForEach(p => db.Polls.Add(p));
            db.SaveChanges();
            TestOptions.ForEach(o => db.Options.Add(o));
            db.SaveChanges();
            TestVotes.ForEach(v => db.Votes.Add(v));
            db.SaveChanges();
        }
    }
}



