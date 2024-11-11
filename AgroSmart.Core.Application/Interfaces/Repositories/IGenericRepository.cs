
using AgroSmart.Core.Domain.Entities;
using Ardalis.Specification;

namespace AgroSmart.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        Task<List<Comments>> GetAllCommentOfForo(int foroId);
    }
}
