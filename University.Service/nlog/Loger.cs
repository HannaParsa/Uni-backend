using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.Service.nlog
{
    public class Loger:ILogger
    {
        private readonly NLog.Logger _logger;
        public Loger(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            _logger = LogManager.GetCurrentClassLogger();
        }

        public string Name
        {
            get { return _logger.Name; }
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}
