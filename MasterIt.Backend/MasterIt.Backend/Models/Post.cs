﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string VideoUrl { get; set; }
        public bool IsRatable { get; set; }
        public bool IsApproved { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}