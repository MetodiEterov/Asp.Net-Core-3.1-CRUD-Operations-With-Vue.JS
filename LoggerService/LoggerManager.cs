using Entities.Contracts;

using NLog;

namespace LoggerService
{
    /// <summary>
    /// LoggerManager class for logging messages to log file
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
