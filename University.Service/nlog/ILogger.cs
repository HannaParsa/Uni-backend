using System;
using System.Collections.Generic;
using System.Text;

namespace University.Service.nlog
{
    public interface ILogger
    {
        public string Name { get; }
        public void Debug(string message);
        public void Info(string message);
    }
}
