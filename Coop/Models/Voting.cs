using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coop.Models
{
    public class Voting
    {
        public int Id { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public int TotalVotes { get; set; }

        public int? HouseId { get; set; }
        public House House { get; set; }
    }
}