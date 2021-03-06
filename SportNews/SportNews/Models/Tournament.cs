﻿ using System;
using System.Collections.Generic;
using System.Text;

namespace SportNews.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public string Name { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
