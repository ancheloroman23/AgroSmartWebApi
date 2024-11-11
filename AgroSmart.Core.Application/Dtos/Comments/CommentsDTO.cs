

namespace AgroSmart.Core.Application.Dtos.Comments
{
    public class CommentsDTO
    {
        public int ForoId { get; set; }
        public string Content { get; set; }
        public string? UserId { get; set; }
        public string? CommentedBy { get; set; }
        public string? CommentedByImage { get; set; }
    }
}
