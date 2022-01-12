using System;

namespace ForumService.Entities
{
    public partial class KnowedgeBaseArticleFeedback
    {
        public int Articleanswerid { get; set; }
        public int Articleid { get; set; }
        public int Answer { get; set; }
        public string Ip { get; set; }
        public DateTime Date { get; set; }
    }
}
