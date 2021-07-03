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
    /// API Controller for the task model
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, IMapper mapper, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <returns>Returns a <see cref="List{TaskModel}"/></returns>
        [HttpGet]
        [Route("/Tasks")]
        public async Task<List<TaskModel>> GetTasks()
        {
            try
            {
                return _mapper.Map<List<TaskModel>>(await _taskService.GetTasks());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Returns all tasks related to one project
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns>Return a <see cref="List{TaskModel}"/></returns>
        [HttpGet]
        [Route("/Tasks/{projectId}")]
        public async Task<List<TaskModel>> GetTasks(int projectId)
        {
            try
            {
                return _mapper.Map<List<TaskModel>>(await _taskService.GetTasks(projectId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Gets a task 
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns>Returns a <see cref="TaskModel"/></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<TaskModel> GetTask(int id)
        {
            try
            {
                return _mapper.Map<TaskModel>(await _taskService.GetTask(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Adds a tasks
        /// </summary>
        /// <param name="task">Task to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddTask(TaskModel task)
        {
            try
            {
                await _taskService.AddTask(_mapper.Map<Business.Models.Task>(task));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteTask(int id)
        {
            try
            {
                await _taskService.DeleteTask(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Updates a tasks
        /// </summary>
        /// <param name="task">Task to be updated</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task UpdateTask(TaskModel task)
        {
            try
            {
                await _taskService.UpdateTask(_mapper.Map<Business.Models.Task>(task));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
