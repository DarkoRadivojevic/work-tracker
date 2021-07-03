using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTracker.Business.Services.Interfaces;
using WorkTracker.Data.Models;
using WorkTracker.Data.Repository.Interfaces;

namespace WorkTracker.Business.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task AddTask(Models.Task task)
        {
            await _taskRepository.AddTask(_mapper.Map<TaskEntity>(task));
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }

        public async Task<Models.Task> GetTask(int id)
        {
            return _mapper.Map<Models.Task>(await _taskRepository.GetTask(id));
        }

        public async Task<List<Models.Task>> GetTasks()
        {
            return _mapper.Map<List<Models.Task>>(await _taskRepository.GetTasks());
        }

        public async Task<List<Models.Task>> GetTasks(int projectId)
        {
            return _mapper.Map<List<Models.Task>>(await _taskRepository.GetTasks(projectId));
        }

        public async Task UpdateTask(Models.Task task)
        {
            await _taskRepository.UpdateTask(_mapper.Map<TaskEntity>(task));
        }
    }
}
