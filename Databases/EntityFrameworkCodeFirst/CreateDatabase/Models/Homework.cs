﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CreateDatabase.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
