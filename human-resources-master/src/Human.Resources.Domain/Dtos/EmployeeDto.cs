
using Human.Resources.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Human.Resources.Domain.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public GenderDto Gender { get; set; }

        public IEnumerable<SkillDto> Skills { get; set; }
    }
}