using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTracker.Business.Services.Interfaces;
using WorkTracker.Web.Models;

namespace WorkTracker.Web.Controllers
{
    /// <summary>
    /// API Controller for the project model
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, IMapper mapper, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns>Returns <see cref="List{ProjectModel}"/></returns>
        [HttpGet]
        [Route("/Projects")]
        public async Task<List<ProjectModel>> GetProjects()
        {
            try
            {
                return _mapper.Map<List<ProjectModel>>(await _projectService.GetProjects());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Gets a project
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns>Returns <see cref="ProjectModel"/></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ProjectModel> GetProject(int id)
        {
            try
            {
                return _mapper.Map<ProjectModel>(await _projectService.GetProject(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Adds a project
        /// </summary>
        /// <param name="project">Project to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddProject(ProjectModel project)
        {
            try
            {
                await _projectService.AddProject(_mapper.Map<Business.Models.Project>(project));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Deletes a project
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteProject(int id)
        {
            try
            {
                await _projectService.DeleteProject(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Updates a project
        /// </summary>
        /// <param name="project">Project to be updated</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task UpdateProject(ProjectModel project)
        {
            try
            {
                await _projectService.UpdateProject(_mapper.Map<Business.Models.Project>(project));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
