using System;


namespace EntityLayer.DTOs
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogCount { get; set; }
        public bool IsDeactive { get; set; }
    }
}
