using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;
using University.Db.Model;

namespace University.Contract.Interface
{
    public interface IStudentService
    {
        public void AddStudent(StudentDto studentDto);
        public void dellStudent(StudentDto studentDto);
        public void updateStudent(StudentDto studentDto);
        public void readStudent(StudentDto studentDto);
        public List<StudentDto> GetStudents();
    }
}
