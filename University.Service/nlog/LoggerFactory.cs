using System;
using System.Collections.Generic;
using System.Text;

namespace University.Service.nlog
{
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger Create<T>() where T : class
        {
            return new Loger(typeof(T));
        }

    }
}
