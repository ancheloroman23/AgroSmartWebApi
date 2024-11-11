using AgroSmart.Core.Domain.Commons;

namespace AgroSmart.Core.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<New> News { get; set; }
        public List<Foro> Foros { get; set; }
    }
}
