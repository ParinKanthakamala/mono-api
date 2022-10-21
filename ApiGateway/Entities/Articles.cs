using System;

namespace ApiGateway.Entities
{
    public partial class Articles
    {
        public int ArticleId { get; set; }
        public int ArticleGroup { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public int ArticleOrder { get; set; }
        public int StaffArticle { get; set; }
    }
}
