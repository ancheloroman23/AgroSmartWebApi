using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Dtos.Crop
{
    public class CropDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime DateCrop { get; set; }
        public DateTime? DateHarvest { get; set; }
        public string UserId { get; set; }
    }
}
