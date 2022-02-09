using System;
using System.Collections.Generic;
using System.Text;

namespace University.Service.nlog
{
    public interface ILoggerFactory
    {
        public ILogger Create<T>() where T : class;
    }
}
