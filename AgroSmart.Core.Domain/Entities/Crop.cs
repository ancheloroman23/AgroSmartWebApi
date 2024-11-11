using AgroSmart.Core.Domain.Commons;

namespace AgroSmart.Core.Domain.Entities
{
    public class Crop:BaseEntity
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime DateCrop { get; set; }
        public DateTime? DateHarvest { get; set; }
        public string UserId { get; set; }
    }
}
