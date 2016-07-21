using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;
        private string author;

        public Comment(string content, string author)
        {
            this.Content = content;
            this.Author = author;
        }

        public Comment(string content)
        {
            this.content = content;
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                Validator.ValidateNull(value, "Author cannot be null!");
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            protected set
            {
                Validator.ValidateNull(value, "Content cannot be null!");
                this.content = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{{0}}", this.Content);
        }
    }
}
