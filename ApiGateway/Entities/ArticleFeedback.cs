using System;

namespace ApiGateway.Entities
{
    public partial class ArticleFeedback
    {
        public int ArticleAnswerId { get; set; }
        public int ArticleId { get; set; }
        public int Answer { get; set; }
        public string Ip { get; set; }
        public DateTime Date { get; set; }
    }
}
