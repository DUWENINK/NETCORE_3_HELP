﻿using log4net;

namespace DUWENINK.Core.Infrastructure.Utilities
{
    public class Log
    {
        public static ILog Logger = LogManager.GetLogger(Constants.Log4net.RepositoryName, Constants.Log4net.LoggerName);
    }
}
