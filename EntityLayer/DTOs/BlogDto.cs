using System;


namespace EntityLayer.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
    }
}
