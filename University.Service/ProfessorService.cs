using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;
using University.Contract.Interface;
using University.Db;
using University.Db.Model;
using Mapster;
using System.Linq;
using Newtonsoft.Json;

namespace University.Service
{
    public class ProfessorService : IProfessorService
    {
        public void addProfessor(ProfessorDto professorDto)
        {
            using (var context = new UniversityDbContext())
            {
                var pp = professorDto.Adapt<Professor>();
                context.Professors.Add(pp);
                context.SaveChanges();
            }
        }

        public void delProfessor(ProfessorDto professorDto)
        {
            using (var context = new UniversityDbContext())
            {
                var pp = professorDto.Adapt<Professor>();
                context.Professors.Remove(pp);
                context.SaveChanges();
            }
        }

        public void readProfessor(ProfessorDto professorDto)
        {
            using (var context = new UniversityDbContext())
            {
                var professor = context.Set<Professor>().Where(a => a.ProfessorName.Equals(professorDto.ProfessorName)).FirstOrDefault();
                var ss = professor.Adapt<ProfessorDto>();
                Console.WriteLine("professor name: {0} , profesoor id: {1}", ss.ProfessorName, ss.ProfessorId);
            }

        }

        public void updateProfessor(ProfessorDto professorDto)
        {
            using (var context = new UniversityDbContext())
            {
                var pp = professorDto.Adapt<Professor>();
                context.Professors.Update(pp);
                context.SaveChanges();
            }
        }
        public List<ProfessorDto> GetProfessors()
        {
            using (var context = new UniversityDbContext())
            {
                var professors = context.Set<Professor>();
                var list = professors.Adapt<List<ProfessorDto>>();
                string s = JsonConvert.SerializeObject(list);
                Console.WriteLine(s);
            }
            return null;
        }
    }
}
