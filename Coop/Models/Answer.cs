using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        
        public int? RoomerId { get; set; }
        public Roomer Roomer { get; set; }

        public int? VotingId { get; set; }
        public Voting Voting { get; set; }
    }
}