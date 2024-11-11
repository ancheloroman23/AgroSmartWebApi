using AgroSmart.Core.Domain.Commons;

namespace AgroSmart.Core.Domain.Entities
{
    public class Calendary:BaseEntity
    {
        public string Days { get; set; }
        public string Month { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
