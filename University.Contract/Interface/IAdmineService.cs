using System;
using System.Collections.Generic;
using System.Text;
using University.Contract.Dto;

namespace University.Contract.Interface
{
    public interface IAdmineService
    {
        public void addAdmine(AdmineDto admineDto);
        public void delAdmine(AdmineDto admineDto);
        public void updateAdmine(AdmineDto admineDto);
        public void readAdmine(AdmineDto admineDto);
        public List<AdmineDto> GetAdmines();
    }
}
