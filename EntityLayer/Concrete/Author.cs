using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
        public bool IsDeactive { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
