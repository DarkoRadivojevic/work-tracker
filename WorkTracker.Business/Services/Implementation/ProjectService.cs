using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTracker.Business.Services.Interfaces;
using WorkTracker.Data.Models;
using WorkTracker.Data.Repository.Interfaces;

namespace WorkTracker.Business.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task AddProject(Models.Project project)
        {
            await _projectRepository.AddProject(_mapper.Map<ProjectEntity>(project));
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepository.DeleteProject(id);
        }

        public async Task<Models.Project> GetProject(int id)
        {
            return _mapper.Map<Models.Project>(await _projectRepository.GetProject(id));
        }

        public async Task<List<Models.Project>> GetProjects()
        {
            return _mapper.Map<List<Models.Project>>(await _projectRepository.GetProjects());
        }

        public async Task UpdateProject(Models.Project project)
        {
            await _projectRepository.UpdateProject(_mapper.Map<ProjectEntity>(project));
        }
    }
}