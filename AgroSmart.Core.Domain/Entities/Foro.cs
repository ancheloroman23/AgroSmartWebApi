using AgroSmart.Core.Domain.Commons;


namespace AgroSmart.Core.Domain.Entities
{
    public class Foro:BaseEntity
    {
        public string Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public Category Category { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
