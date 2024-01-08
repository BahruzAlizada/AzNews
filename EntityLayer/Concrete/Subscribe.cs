
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Subscribe : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
