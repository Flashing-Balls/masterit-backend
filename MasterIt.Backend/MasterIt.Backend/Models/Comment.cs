using System;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
    }
}