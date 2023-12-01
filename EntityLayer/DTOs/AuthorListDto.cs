using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class AuthorListDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
        public int BlogCount { get; set; }
        public bool IsDeactive { get; set; }
    }
}
