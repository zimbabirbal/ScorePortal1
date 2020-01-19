using System;
using System.Collections.Generic;
using System.Text;

namespace SportNews.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
