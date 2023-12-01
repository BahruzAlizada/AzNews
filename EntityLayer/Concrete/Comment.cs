using System;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeactive { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public List<Comment> Replies { get; set; } = new List<Comment>();
        public Blog Blog { get; set; }
    }

}
