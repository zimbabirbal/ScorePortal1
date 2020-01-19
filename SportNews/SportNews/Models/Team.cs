using System;
using System.Collections.Generic;
using System.Text;

namespace SportNews.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
