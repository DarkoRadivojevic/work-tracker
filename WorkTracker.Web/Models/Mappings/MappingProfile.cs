using AutoMapper;
using WorkTracker.Data.Models;

namespace WorkTracker.Web.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            TaskEntityMappings();
            ProjectEntityMappings();
        }

        public void TaskEntityMappings()
        {
            CreateMap<Business.Models.Task, TaskModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.TaskDescription, opt => opt.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<TaskModel, Business.Models.Task>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.TaskDescription, opt => opt.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<Business.Models.Task, TaskEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.TaskDescription, opt => opt.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<TaskEntity, Business.Models.Task>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.TaskDescription, opt => opt.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));
        }

        public void ProjectEntityMappings()
        {
            CreateMap<Business.Models.Project, ProjectModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<ProjectModel, Business.Models.Project>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<Business.Models.Project, ProjectEntity>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<ProjectEntity, Business.Models.Project>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
        }
    }
}