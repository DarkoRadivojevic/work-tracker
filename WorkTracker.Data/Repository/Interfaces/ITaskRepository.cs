using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTracker.Data.Models;

namespace WorkTracker.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository providing methods to the task entity stored in the database
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Gets a task entity from the database
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns>Returns a <see cref="TaskEntity"/></returns>
        Task<TaskEntity> GetTask(int id);

        /// <summary>
        /// Gets all task entities from the database
        /// </summary>
        /// <returns>Returns <see cref="List{TaskEntity}"/></returns>
        Task<List<TaskEntity>> GetTasks();

        /// <summary>
        /// Gets all tasks related to one project from the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns>Returns <see cref="List{TaskEntity}"/></returns>
        Task<List<TaskEntity>> GetTasks(int projectId);

        /// <summary>
        /// Add a task to the database
        /// </summary>
        /// <param name="task">Task being added</param>
        /// <returns></returns>
        Task AddTask(TaskEntity task);

        /// <summary>
        /// Updates a task in the database
        /// </summary>
        /// <param name="task">Task being updated</param>
        /// <returns></returns>
        Task UpdateTask(TaskEntity task);

        /// <summary>
        /// Deletes a task from the database
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns></returns>
        Task DeleteTask(int id);
    }
}
