using System;

namespace RobotWars.Core.System.Logging
{
    public interface ILogWriter
    {
        void LogError(object msg, Exception exception);
        void LogErrorFormat(string msg, params object[] args);
        void LogDebug(object msg, Exception exception);
        void LogDebugFormat(string msg, params object[] args);
        void LogInfo(object msg, Exception exception);
        void LogInfoFormat(string msg, params object[] args);
    }
}
