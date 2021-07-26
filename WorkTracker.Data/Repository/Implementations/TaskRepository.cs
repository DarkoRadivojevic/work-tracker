using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTracker.Data.Infrastructure;
using WorkTracker.Data.Models;
using WorkTracker.Data.Repository.Interfaces;

namespace WorkTracker.Data.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly WorkDbContext _dbContext;

        public TaskRepository(WorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTask(TaskEntity task)
        {
            await _dbContext.TaskEntities
                .AddAsync(task);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            _dbContext.Remove(new TaskEntity() { Id = id });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskEntity> GetTask(int id)
        {
            return await _dbContext.TaskEntities
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskEntity>> GetTasks()
        {
            return await _dbContext.TaskEntities.ToListAsync();
        }

        public async Task<List<TaskEntity>> GetTasks(int projectId)
        {
            return await _dbContext
                .TaskEntities
                .Where(x => x.ProjectId.Equals(projectId))
                .ToListAsync();
        }

        public async Task UpdateTask(TaskEntity task)
        {
            _dbContext.Update(task);

            await _dbContext.SaveChangesAsync();
        }
    }
}
