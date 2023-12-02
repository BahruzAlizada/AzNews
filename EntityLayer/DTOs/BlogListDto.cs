using System;

namespace EntityLayer.DTOs
{
    public class BlogListDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Seen { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeactive { get; set; }
    }
}
