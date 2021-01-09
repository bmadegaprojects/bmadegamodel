using AutoMapper;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using System;
using System.Linq;

namespace Human.Resources.Service.Automapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Skills, 
                    opt => opt.MapFrom(entity => entity.EmployeeSkills.Select(s => s.Skill).ToList()))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(dto => dto.Age,
                    opt => opt.MapFrom(entity => DateTime.UtcNow.Year - entity.BirthDate.Year ));

            CreateMap<Gender, GenderDto>()
                .ForMember(g => g.Id,
                   opt => opt.MapFrom(g => g.Id));

            CreateMap<Skill, SkillDto>()
                .ForMember(g => g.Id,
                   opt => opt.MapFrom(g => g.Id));
        }
    }
}
