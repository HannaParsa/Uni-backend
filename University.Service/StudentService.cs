using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Contract.Dto;
using University.Contract.Interface;
using University.Db;
using University.Db.Model;
using NLog;
using Newtonsoft.Json;

namespace University.Service
{
    public class StudentService : IStudentService
    {
        
        private static readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();
      
        public void AddStudent(StudentDto studentDto)
        {
            logger.Info("add student");
            using (var context = new UniversityDbContext())
            {
                var ss = studentDto.Adapt<Student>();
                context.Students.Add(ss);
                context.SaveChanges();
            }
            logger.Info("end adding student");

        }
        public void dellStudent(StudentDto studentDto)
        {
            logger.Info("delete student");
            using (var context = new UniversityDbContext())
            {
                var ss = studentDto.Adapt<Student>();
                context.Students.Remove(ss);
                context.SaveChanges();
            }
            logger.Info("end delete student");

        }
        public void updateStudent(StudentDto studentDto)
        {
            logger.Info("update student");
            using (var context = new UniversityDbContext())
            {
                var ss = studentDto.Adapt<Student>();
                context.Students.Update(ss);
                context.SaveChanges();
            }
            logger.Info("end update student");

        }
        public void readStudent(StudentDto studentDto)
        {
            using (var context = new UniversityDbContext())
            {
                var student = context.Set<Student>().Where(a => a.StudentName.Equals(studentDto.StudentName)).FirstOrDefault();
                var ss = student.Adapt<StudentDto>();
                logger.Info($"student name {ss.StudentName} student id {ss.StudentId}");
            }

        }

        public List<StudentDto> GetStudents()
        {
            using (var context = new UniversityDbContext())
            {
                var students = context.Set<Student>();
                var list =  students.Adapt<List<StudentDto>>();
                string s = JsonConvert.SerializeObject(list);
                Console.WriteLine(s);
            }
            return null;
        }
    }
}
