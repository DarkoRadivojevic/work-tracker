using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTracker.Data.Infrastructure;
using WorkTracker.Data.Models;
using WorkTracker.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace WorkTracker.Data.Repository.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly WorkDbContext _dbContext;

        public ProjectRepository(WorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProject(ProjectEntity project)
        {
            await _dbContext.ProjectEntities
                .AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            _dbContext.ProjectEntities
                .Remove(new ProjectEntity() { Id = id });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProjectEntity> GetProject(int id)
        {
            return await _dbContext.ProjectEntities
                .FindAsync(id);
        }

        public async Task<List<ProjectEntity>> GetProjects()
        {
            return await _dbContext.ProjectEntities
                .ToListAsync();
        }

        public IQueryable<ProjectEntity> GetFilteredProjects(Expression<Func<ProjectEntity, bool>> expression)
        {
            return _dbContext.ProjectEntities
                .Where(expression)
                .AsQueryable();
        }
        public async Task UpdateProject(ProjectEntity project)
        {
            _dbContext.ProjectEntities
                .Update(project);

            await _dbContext.SaveChangesAsync();
        }
    }
}
