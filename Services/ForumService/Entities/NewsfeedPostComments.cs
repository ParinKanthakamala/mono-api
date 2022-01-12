using System;

namespace ForumService.Entities
{
    public partial class NewsfeedPostComments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Userid { get; set; }
        public int Postid { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
