using System;


namespace EntityLayer.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
        public bool IsDeactive { get; set; }

    }
}
