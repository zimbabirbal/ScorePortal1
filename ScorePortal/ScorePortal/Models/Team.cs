using System;
using System.Collections.Generic;
using System.Text;

namespace ScorePortal.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string SportId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
