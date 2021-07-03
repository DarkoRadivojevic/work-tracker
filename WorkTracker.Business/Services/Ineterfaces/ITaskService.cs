using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkTracker.Business.Services.Interfaces
{
    /// <summary>
    /// Service providing methods to the task object
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <returns>Returns a list of tasks</returns>
        Task<List<Models.Task>> GetTasks();

        /// <summary>
        /// Gets all tasks related to one project
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns>Returns a <see cref="List{Models.Task}"/></returns>
        Task<List<Models.Task>> GetTasks(int projectId);

        /// <summary>
        /// Gets a task by id
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns>Return a <see cref="Models.Task"/></returns>
        Task<Models.Task> GetTask(int id);

        /// <summary>
        /// Adds a task
        /// </summary>
        /// <param name="task">Id of the task</param>
        /// <returns></returns>
        Task AddTask(Models.Task task);

        /// <summary>
        /// Updates an existing task
        /// </summary>
        /// <param name="task">Task to be added</param>
        /// <returns></returns>
        Task UpdateTask(Models.Task task);

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="id">id of the task</param>
        /// <returns></returns>
        Task DeleteTask(int id);
    }
}
