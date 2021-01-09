using AutoMapper;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using System.Linq;

namespace Human.Resources.Service.Automapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(entity => entity.GenderId, opt => opt.MapFrom(model => model.Gender.Id))
                .ForMember(entity => entity.EmployeeSkills, opt => opt.MapFrom(model => model.Skills))
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .AfterMap((model, entity) =>
                {
                    foreach (var employeeSkill in entity.EmployeeSkills)
                    {
                        employeeSkill.EmployeeId = entity.Id;
                    }
                });

            CreateMap<GenderDto, Gender>();
            
            CreateMap<SkillDto, Skill>();

            CreateMap<SkillDto, EmployeeSkill>()
                .ForMember(entity => entity.SkillId, opt => opt.MapFrom(model => model.Id));

            CreateMap<EmployeeDto, EmployeeSkill>()
            .ForMember(entity => entity.EmployeeId, opt => opt.MapFrom(model => model.Id));

        }
    }
}
