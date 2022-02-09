using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;

namespace University.Contract.Interface
{
    public interface IClassService
    {
        public void addClass(ClassDto classDto);
        public void delClass(ClassDto classDto);
        public void updateClass(ClassDto classDto);
        public void readClass(ClassDto classDto);
        public List<ClassDto> GetClasses();
    }
}
