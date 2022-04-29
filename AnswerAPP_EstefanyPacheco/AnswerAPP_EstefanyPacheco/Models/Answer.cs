using System;
using System.Collections.Generic;
using System.Text;

namespace AnswerAPP_EstefanyPacheco.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Likes = new HashSet<Like>();
        }

        public long AnswerId { get; set; }
        public int UserId { get; set; }
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Answer1 { get; set; }
        public bool? SetAsCorrect { get; set; }
        public bool? IsStrike { get; set; }

        public virtual Ask Ask { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
