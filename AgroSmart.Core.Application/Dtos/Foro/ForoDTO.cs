using AgroSmart.Core.Application.Dtos.Comments;
using AgroSmart.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Dtos.Foro
{
    public class ForoDTO
    {
        public string Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public bool HasError { get; set; } = false;
        public string? Message { get; set; }
        public List<CommentsDTO> Comments { get; set; }
    }
}
