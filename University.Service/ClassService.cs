using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.Contract.Dto;
using University.Contract.Interface;
using University.Db;
using University.Db.Model;

namespace University.Service
{
    public class ClassService : IClassService
    {
        public void addClass(ClassDto classDto)
        {
            using (var context = new UniversityDbContext()) {
                var cl = classDto.Adapt<Class>();
                context.Classes.Add(cl);
                context.SaveChanges();
            }
        }

        public void delClass(ClassDto classDto)
        {
            using (var context = new UniversityDbContext())
            {
                var cl = classDto.Adapt<Class>();
                context.Classes.Remove(cl);
                context.SaveChanges();
            }
        }

        public void readClass(ClassDto classDto)
        {
            using (var context = new UniversityDbContext())
            {
                var Class = context.Set<Class>().Where(a => a.ClassName.Equals(classDto.ClassName)).FirstOrDefault();
                var ss = Class.Adapt<ClassDto>();
                Console.WriteLine("class id : {0}, class name: {1} ", ss.ClassId, ss.ClassName);
            }
        }

        public void updateClass(ClassDto classDto)
        {
            using (var context = new UniversityDbContext())
            {
                var cl = classDto.Adapt<Class>();
                context.Classes.Update(cl);
                context.SaveChanges();
            }
        }
        public List<ClassDto> GetClasses()
        {
            using (var context = new UniversityDbContext())
            {
                var classes = context.Set<Class>();
                var list = classes.Adapt<List<ClassDto>>();
                string s = JsonConvert.SerializeObject(list);
                Console.WriteLine(s);
            }
            return null;
        }
    }
}
