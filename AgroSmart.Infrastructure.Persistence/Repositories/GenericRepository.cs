using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Domain.Entities;
using AgroSmart.Infraestructure.Persistence.Context;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroSmart.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : RepositoryBase<Entity>, IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbContext;

        //protected DbSet<Entity> Entities => _dbContext.Set<Entity>();

        public GenericRepository(ApplicationContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Comments>> GetAllCommentOfForo(int foroId)
        {
            return await _dbContext.Set<Comments>().Where(e => e.ForoId == foroId).ToListAsync();
        }

    }
}
