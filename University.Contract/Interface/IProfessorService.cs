using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;

namespace University.Contract.Interface
{
    public interface IProfessorService
    {
        public void addProfessor(ProfessorDto professorDto);
        public void delProfessor(ProfessorDto professorDto);
        public void updateProfessor(ProfessorDto professorDto);
        public void readProfessor(ProfessorDto professorDto);
        public List<ProfessorDto> GetProfessors();
    }
}
