using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public Friendship Friendship { get; set; }
        public int? AuthorId { get; set; }
        public User Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }
        public Nullable<DateTime> SeenOn { get; set; }
    }
}
