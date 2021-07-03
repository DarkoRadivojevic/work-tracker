using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkTracker.Data.Models;

namespace WorkTracker.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository providing methods to the project entity stored in a database
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Gets a project entity from the database
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns>Returns a <see cref="ProjectEntity"/> if found otherwise returns null</returns>
        Task<ProjectEntity> GetProject(int id);

        /// <summary>
        /// Gets all project entities from the database
        /// </summary>
        /// <returns>Returns a <see cref="List{ProjectEntity}"/></returns>
        Task<List<ProjectEntity>> GetProjects();

        /// <summary>
        /// Gets all projects filtered by passed expression
        /// </summary>
        /// <param name="expression">Expression passed</param>
        /// <returns>Returns <see cref="IQueryable{ProjectEntity}"/></returns>
        IQueryable<ProjectEntity> GetFilteredProjects(Expression<Func<ProjectEntity, bool>> expression);

        /// <summary>
        /// Adds a project to the database
        /// </summary>
        /// <param name="project">ProjectEntity being added</param>
        /// <returns></returns>
        Task AddProject(ProjectEntity project);

        /// <summary>
        /// Updates a project in the database
        /// </summary>
        /// <param name="project">Project being updates</param>
        /// <returns></returns>
        Task UpdateProject(ProjectEntity project);

        /// <summary>
        /// Deletes a project from the database
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns></returns>
        Task DeleteProject(int id);
    }
}
