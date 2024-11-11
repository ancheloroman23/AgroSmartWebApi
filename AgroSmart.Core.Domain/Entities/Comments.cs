using AgroSmart.Core.Domain.Commons;

namespace AgroSmart.Core.Domain.Entities
{
    public class Comments:BaseEntity
    {
        public int ForoId { get; set; }
        public Foro Foro { get; set; }
        public string Content { get; set; }
        public string? UserId { get; set; }
    }
}
