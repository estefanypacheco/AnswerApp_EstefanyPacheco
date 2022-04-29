using System;
using System.Collections.Generic;
using System.Text;

namespace AnswerAPP_EstefanyPacheco.Models
{
    public partial class Like
    {
        public long LikeId { get; set; }
        public int UserId { get; set; }
        public long AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual User User { get; set; }
    }
}
