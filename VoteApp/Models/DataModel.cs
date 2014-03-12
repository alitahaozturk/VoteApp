using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VoteApp.Models
{

    public class VoteAppContext : DbContext
    {

        public VoteAppContext()
         : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //}
    }
    
    public class Poll
    {
        public int PollId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastVoteDate { get; set; }
        public bool IsHidden { get; set; }
        public virtual ICollection<Option> Options { get; set; }
   }

    public class Option
	{
        public int OptionId { get; set; }
        public int PollId { get; set; }
        public string Value { get; set; }
        public virtual Poll Poll { get; set; }
	}

    public class User 
    {
        public int UserId { get; set; }
        public string AspNetUserId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Poll> PollsCreated { get; set; }
        public virtual ICollection<Option> OptionsVotedFor { get; set; }
    
    }

    public class Vote
    {
        public int VoteId { get; set; }
        //public int UserId { get; set; }
        public int? Temp { get; set; }
        public int OptionId { get; set; }
        public DateTime VoteDate { get; set; }
        public bool IsValid { get; set; }
        public virtual User User { get; set;}
        public virtual Option Option { get; set;}
    }

}