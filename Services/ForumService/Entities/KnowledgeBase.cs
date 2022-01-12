using System;

namespace ForumService.Entities
{
    public partial class KnowledgeBase
    {
        public int Articleid { get; set; }
        public int Articlegroup { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public sbyte Active { get; set; }
        public DateTime Datecreated { get; set; }
        public int ArticleOrder { get; set; }
        public int StaffArticle { get; set; }
    }
}
