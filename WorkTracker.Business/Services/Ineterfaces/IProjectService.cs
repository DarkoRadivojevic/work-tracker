using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkTracker.Business.Services.Interfaces
{
    /// <summary>
    /// Service providing methods to the project object
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Gets a project by passed id
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns>Returns <see cref="Models.Project"/> if it exists if not retruns null</returns>
        Task<Models.Project> GetProject(int id);

        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns>Returns a <see cref="List{Models.Project}"/></returns>
        Task<List<Models.Project>> GetProjects();

        /// <summary>
        /// Adds a project
        /// </summary>
        /// <param name="project">Project to be added</param>
        /// <returns></returns>
        Task AddProject(Models.Project project);

        /// <summary>
        /// Updates and existing project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task UpdateProject(Models.Project project);

        /// <summary>
        /// Removes the projects 
        /// </summary>
        /// <param name="id">Id of the project being removed</param>
        /// <returns></returns>
        Task DeleteProject(int id);
    }
}
