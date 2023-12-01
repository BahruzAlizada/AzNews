using CoreLayer.Entity;
using System;
namespace EntityLayer.Concrete
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeactive { get; set; }

        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}
