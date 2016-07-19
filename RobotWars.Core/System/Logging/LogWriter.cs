using System;
using log4net;

namespace RobotWars.Core.System.Logging
{
    public class LogWriter : ILogWriter
    {
        private static readonly ILog _log = LogManager.GetLogger("RobotWars");

        public void LogError(object msg, Exception exception)
        {
            _log.Error(msg, exception);
        }

        public void LogErrorFormat(string msg, params object[] args)
        {
            _log.ErrorFormat(msg, args);            
        }

        public void LogDebug(object msg, Exception exception)
        {
            _log.Debug(msg, exception);
        }

        public void LogDebugFormat(string msg, params object[] args)
        {
            _log.DebugFormat(msg, args);
        }

        public void LogInfo(object msg, Exception exception)
        {
            _log.Info(msg, exception);
        }

        public void LogInfoFormat(string msg, params object[] args)
        {
            _log.InfoFormat(msg, args);
        }
    }
}
