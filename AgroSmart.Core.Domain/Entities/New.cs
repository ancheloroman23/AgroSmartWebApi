using AgroSmart.Core.Domain.Commons;

namespace AgroSmart.Core.Domain.Entities
{
    public class New:BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CompleteDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
